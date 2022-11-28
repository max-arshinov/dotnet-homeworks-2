using Hw9.ErrorMessages;
using Hw9.Parser.ErrorMessages;
using Hw9.Parser.Nodes;
using Hw9.Parser.Tokens;

namespace Hw9.Parser.Parser;

public class BinaryOperatorParser: IInfixParser
{
    private readonly Func<NodeBase, NodeBase, NodeBase> _makeNode;
    public Priority Priority { get; }

    public BinaryOperatorParser(Priority priority, Func<NodeBase, NodeBase, NodeBase> makeNode)
    {
        _makeNode = makeNode;
        Priority = priority;
    }

    public NodeBase Parse(Parser parser, NodeBase left, Token token)
    {
        var laNode = parser.LookAhead();
        
        if (laNode is null)
            throw new InvalidMathSyntaxError(MathErrorMessager.EndingWithOperation, token);

        try
        {
            return _makeNode(left, parser.Parse((int)Priority));
        }
        catch (ParsingError e)
            when (e.Message == MathErrorMessager.StartingWithOperation)
        {
            if(laNode.Type == TokenTypes.BraceClose)
                throw new InvalidMathSyntaxError(MathErrorMessager.OperationBeforeParenthesisMessage(token.Value), token);
            throw new InvalidMathSyntaxError(MathErrorMessager.TwoOperationInRowMessage(token.Value, laNode.Value), token);
        }
    }
}