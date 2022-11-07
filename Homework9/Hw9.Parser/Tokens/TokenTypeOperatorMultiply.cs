namespace Hw9.Parser.Tokens;

public class TokenTypeOperatorMultiply : TokenTypeOperator
{
    public override string StringRepresentation => "*";

    public override OperatorKind OperatorKind => OperatorKind.Binary;
}