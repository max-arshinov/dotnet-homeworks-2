using Hw9.Parser.Utils;

namespace Hw9.Parser.Tokens;

public class Tokenizer
{
    public TokenPipe TokenPipe { get; set; } = new();

    private string _lexeme = "";
    private int _lexemeStart;
    private int _currentPosition;
    private int _ambigiousPosition;
    
    public TokenPipe Tokenize(string input)
    {
        TokenPipe = new TokenPipe();

        _lexeme = "";
        _lexemeStart = 0;

        for (int index = 0; index < input.Length; index++)
        {
            char c = input[index];
            _currentPosition = index;
            
            var validCurrent = ValidTokens(_lexeme);
            var validNext = ValidTokens(_lexeme + c);
            var wasFinished = false;
            var shouldSkip = false;
            
            if (_lexeme == "")
                _lexeme += c;
            else if (c.IsWhitespace())
            {
                FinishToken(validCurrent.FirstOrDefault());
                wasFinished = true;
                shouldSkip = true;
            }
            else if (validCurrent.Count == 1 && validNext.Count == 0)
            {
                FinishToken(validCurrent.FirstOrDefault());
                wasFinished = true;
            }
            else if (validNext.Count >= 0 || validCurrent.Count == 0)
            {
                if (validNext.Count == 0 && _ambigiousPosition == -1)
                    _ambigiousPosition = _currentPosition - 1;
                _lexeme += c;
            }

            if (wasFinished)
            {
                _ambigiousPosition = -1;
                if(!shouldSkip)
                    _lexeme = c.ToString();
            }

            if (index == input.Length - 1 && _ambigiousPosition >= 0)
            {
                _lexeme = input[_ambigiousPosition].ToString();
                FinishToken(null);
                index = _ambigiousPosition++;
                _ambigiousPosition = -1;
            }
        }

        FinishToken(ValidTokens(_lexeme).FirstOrDefault());
        
        return TokenPipe;
    }

    private void FinishToken(TokenType? token)
    {
        if (token is null)
            token = TokenTypes.Unknown;

        TokenPipe.Add(new Token(token, _lexeme, _lexemeStart, _currentPosition));
        _lexemeStart = _currentPosition + 1;
        _lexeme = "";
    }

    private static List<TokenType> ValidTokens(string lexeme)
    {
        if (lexeme == "")
            return TokenRegistry.Tokens;

        return TokenRegistry.Tokens
            .Where(token => token.Matches(lexeme))
            .ToList();
    }
}