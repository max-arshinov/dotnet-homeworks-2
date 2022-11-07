namespace Hw9.Parser.Tokens;

public class TokenTypeOperatorDivide : TokenTypeOperator
{
    public override string StringRepresentation => "/";

    public override OperatorKind OperatorKind => OperatorKind.Binary;
}