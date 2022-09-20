.class public abstract sealed auto ansi beforefieldinit
  Hw2.Parser extends [System.Runtime]System.Object
{
    .method private static void IsArgsValidLength(string[] args) cil managed
    {
        .maxstack 2
        ldarg args
        ldlen
        ldc.i4.3
        beq IF_OK
        ldstr "Invalid number of arguments"
        ldstr "args"
        newobj instance void [System.Runtime]System.ArgumentException::.ctor(string, string)
        throw
        IF_OK: ret
    }

    .method public static valuetype Hw2.CalculatorOperation GetOperation(string op)
    {
        .maxstack 4

        ldarg op
        ldstr "+"
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brtrue CASE_PLUS

        ldarg op
        ldstr "-"
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brtrue CASE_MINUS

        ldarg op
        ldstr "*"
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brtrue CASE_MULTIPLY

        ldarg op
        ldstr "/"
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brtrue CASE_DIVIDE

        // CASE_UNDEFINED
        ldc.i4.4
        ret

        CASE_PLUS:
        ldc.i4.0
        ret

        CASE_MINUS:
        ldc.i4.1
        ret

        CASE_MULTIPLY:
        ldc.i4.2
        ret

        CASE_DIVIDE:
        ldc.i4.3
        ret
    }

    .method public static
        void ParseCalcArguments (
            string[] args,
            [out] float64& val1,
            [out] valuetype Hw2.CalculatorOperation& op,
            [out] float64& val2
        ) cil managed
    {
        .maxstack 6

        ldarg args
        call void Hw2.Parser::IsArgsValidLength(string[])

        ldarg op
        ldarg args
        ldc.i4.1
        ldelem.ref
        call valuetype Hw2.CalculatorOperation Hw2.Parser::GetOperation(string)
        stind.i4

        ldarg args
        ldc.i4.0
        ldelem.ref
        ldarg val1
        call bool [System.Runtime]System.Double::TryParse(string, float64&)
        brfalse CASE_INVALID

        ldarg args
        ldc.i4.2
        ldelem.ref
        ldarg val2
        call bool [System.Runtime]System.Double::TryParse(string, float64&)
        brfalse CASE_INVALID

        ret

        CASE_INVALID:
        ldstr "Invalid number"
        newobj instance void [System.Runtime]System.ArgumentException::.ctor(string)
        throw
    }
}


