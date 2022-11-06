namespace Hw9.Parser.Tokens;

public class TokenTypeOperatorMinus : TokenTypeOperator
{
    public override string StringRepresentation => "-";
    
    public override OperatorKind OperatorKind => OperatorKind.Binary | OperatorKind.Unary;
}