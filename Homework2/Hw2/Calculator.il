.class public abstract sealed auto ansi beforefieldinit
  Hw2.Calculator
{
    .method public static float64 Calculate (float64 value1, valuetype CalculatorOperation operation, float64 value2) cil managed
    {
        .maxstack 4
               
        ldc.i4.0
        ldarg.1
        beq Plus
        
        ldc.i4.1
        ldarg.1
        beq Minus
        
        ldc.i4.2
        ldarg.1
        beq Multiply
        
        ldc.i4.3
        ldarg.1
        beq Divide
        
        newobj instance void [System.Runtime]System.ArgumentOutOfRangeException::.ctor()
        throw
        
        ldarg.0
        ldarg.2
        
        Plus:
        add
        ret
        
        Minus:
        sub
        ret
        
        Multiply:
        mul
        ret
        
        Divide:
        div
        ret
    }
}



