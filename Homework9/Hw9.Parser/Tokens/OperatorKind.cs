namespace Hw9.Parser.Tokens;

/// <summary>
/// Тип оператора
/// </summary>
[Flags]
public enum OperatorKind
{
    Binary = 0,
    Unary = 1,
}