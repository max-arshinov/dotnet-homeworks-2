using Hw9.ErrorMessages;
using Hw9.Parser.ErrorMessages;
using Hw9.Parser.Nodes;
using Hw9.Parser.Tokens;

namespace Hw9.Parser.Parser;

public class Parser
{
    private TokenPipe _tokenPipe;
    private readonly IParserProvider _parserProvider;
    
    public IParserProvider ParserProvider => _parserProvider;

    private readonly List<Token> _tokenCache = new();

    public Parser(TokenPipe pipe, IParserProvider parserProvider)
    {
        _tokenPipe = pipe;
        _parserProvider = parserProvider;
    }

    public Parser(IParserProvider parserProvider)
    {
        _parserProvider = parserProvider;
        _tokenPipe = new TokenPipe();
    }

    internal NodeBase Parse(int priority = 0)
    {
        var token = TakeToken();
        var node = _parserProvider
                       .GetPrefixParser(token.Type)
                       ?.Parse(this, token)
                   ?? throw new ParsingError(MathErrorMessager.StartingWithOperation);

        while (priority < GetPrecedence())
        {
            token = TakeToken()
                    ?? throw new ParsingError(MathErrorMessager.IncorrectBracketsNumber);
            
            if(token.Type == TokenTypes.Unknown)
                throw new ParsingError(MathErrorMessager.UnknownCharacterMessage(token.Value[0]), token);

            node = (_parserProvider.GetInfixParser(token.Type)
                    ?? throw new InvalidOperationException($"Нет парсера для токена {token.Type}")
                ).Parse(this, node, token);
        }

        return node;
    }

    public NodeBase Parse(TokenPipe pipe)
    {
        _tokenPipe = pipe;
        return Parse();
    }

    public int GetPrecedence()
    {
        var token = LookAhead();
        return (int)(token == null
            ? 0
            : _parserProvider.GetInfixParser(token.Type)?.Priority
              ?? 0);
    }

    public Token TakeToken(TokenType expectedType)
        => LookAhead()?.Type != expectedType
            ? throw new InvalidOperationException($"Неожиданный токен {expectedType}, встречен {LookAhead()?.Type}")
            : TakeToken();

    public bool Match(TokenType ex)
    {
        if (LookAhead()?.Type == ex)
        {
            TakeToken();
            return true;
        }

        return false;
    }

    public Token TakeToken()
    {
        LookAhead();

        var res = _tokenCache[0];
        _tokenCache.RemoveAt(0);
        return res;
    }

    public Token? LookAhead(int fetchCount = 0)
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