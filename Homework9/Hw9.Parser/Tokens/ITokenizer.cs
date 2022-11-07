namespace Hw9.Parser.Tokens;

public interface ITokenizer
{
    TokenPipe Tokenize(string input);
}