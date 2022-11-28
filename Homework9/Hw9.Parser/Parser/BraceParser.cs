using Hw9.ErrorMessages;
using Hw9.Parser.ErrorMessages;
using Hw9.Parser.Nodes;
using Hw9.Parser.Tokens;

namespace Hw9.Parser.Parser;

public class BraceParser : IPrefixParser
{
    public NodeBase Parse(Parser parser, Token token)
    {
        var laNode = parser.LookAhead();

        try
        {
            var node = parser.Parse();
            if (!parser.Match(TokenTypes.BraceClose))
                throw new InvalidMathSyntaxError(MathErrorMessager.IncorrectBracketsNumber);

            return node;
        }
        catch (ParsingError e)
        {
            if (e.Message == MathErrorMessager.StartingWithOperation)
                throw new InvalidMathSyntaxError(MathErrorMessager.InvalidOperatorAfterParenthesisMessage(laNode!.Value), laNode);
            if (e.Message == MathErrorMessager.EndingWithOperation)
                throw new InvalidMathSyntaxError(MathErrorMessager.OperationBeforeParenthesisMessage(e.ErrorAt?.Value!),
                    e.ErrorAt);
            throw;
        }
    }
}