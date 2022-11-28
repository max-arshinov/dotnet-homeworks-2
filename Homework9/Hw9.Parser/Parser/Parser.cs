using Hw9.ErrorMessages;
using Hw9.Parser.ErrorMessages;
using Hw9.Parser.Nodes;
using Hw9.Parser.Tokens;

namespace Hw9.Parser.Parser;

public class Parser : IParser
{
    private TokenPipe _tokenPipe;
    private readonly IParserProvider _parserProvider;

    private readonly List<Token> _tokenCache = new();

    public Parser(IParserProvider parserProvider)
    {
        _parserProvider = parserProvider;
        _tokenPipe = new TokenPipe();
    }

    internal NodeBase Parse(int priority = 0)
    {
        var token = TakeToken();

        CheckForUnknown(token);

        var node = _parserProvider
                       .GetPrefixParser(token.Type)
                       ?.Parse(this, token)
                   ?? throw new InvalidMathSyntaxError(MathErrorMessager.StartingWithOperation);

        while (priority < GetPrecedence())
        {
            token = TakeToken()
                    ?? throw new InvalidMathSyntaxError(MathErrorMessager.IncorrectBracketsNumber);
            
            CheckForUnknown(token);

            node = (_parserProvider.GetInfixParser(token.Type)
                    ?? throw new InvalidOperationException($"Нет парсера для токена {token.Type}")
                ).Parse(this, node, token);
        }

        return node;
    }

    private void CheckForUnknown(Token token)
    {
        if (token.Type == TokenTypes.Unknown)
            throw new InvalidMathSymbolError(MathErrorMessager.UnknownCharacterMessage(token.Value[0]), token);
    }

    public NodeBase Parse(TokenPipe pipe)
    {
        _tokenPipe = pipe;
        _tokenCache.Clear();
        var result = Parse();

        if (LookAhead() is { } token)
        {
            CheckForUnknown(token);
            throw new InvalidMathSyntaxError(MathErrorMessager.IncorrectBracketsNumber, token);
        }

        return result;
    }

    internal int GetPrecedence()
    {
        var token = LookAhead();
        return (int)(token == null
            ? 0
            : _parserProvider.GetInfixParser(token.Type)?.Priority
              ?? 0);
    }

    internal bool Match(TokenType ex)
    {
        if (LookAhead()?.Type == ex)
        {
            TakeToken();
            return true;
        }

        return false;
    }

    internal Token TakeToken()
    {
        LookAhead();

        var res = _tokenCache[0];
        _tokenCache.RemoveAt(0);
        return res;
    }

    internal Token? LookAhead(int fetchCount = 0)
    {
        while (fetchCount >= _tokenCache.Count)
        {
            var next = _tokenPipe.Next();

            if (next == null)
                return null;

            _tokenCache.Add(next);
        }

        return _tokenCache[fetchCount];
    }
}