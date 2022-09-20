.class public abstract sealed auto ansi beforefieldinit
  Hw2.Calculator extends System.Object
{

    .method public static hidebysig float64 Calculate(
        float64 value1,
        float64 value2,
        valuetype Hw2.CalculatorOperation operation
    ) cil managed{
        ldarg operation
        switch (PLUS, MINUS, MULTIPLY, DIVIDE)
        br UNKNOWN

        PLUS:
        ldarg value1
        ldarg value2
        add
        ret

        MINUS:
        ldarg value1
        ldarg value2
        sub
        ret

        MULTIPLY:
        ldarg value1
        ldarg value2
        mul
        ret

        DIVIDE:
        ldarg value1
        ldarg value2
        brfalse DIVIDE_BY_ZERO
        ldarg value2
        div
        ret


        DIVIDE_BY_ZERO:
        newobj instance void [System.Runtime]System.DivideByZeroException::.ctor()
        throw

        UNKNOWN:
        ldstr "Unknown operation"
        newobj instance void [System.Runtime]System.InvalidOperationException::.ctor()
        throw
    }
}



