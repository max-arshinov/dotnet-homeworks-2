.class public abstract sealed auto ansi beforefieldinit
  Hw2.Calculator extends System.Object
{
    .method public static float64 Calculate(
        float64 value1, 
        valuetype Hw2.CalculatorOperation operation, 
        float64 value2) cil managed
    {
         .maxstack 4
        //load value1
        ldarg.0
        //load value2
        ldarg.2
        
        //case +
        ldarg.1
        ldc.i4 0
        beq.s addOperation
        
        //case -
        ldarg.1
        ldc.i4 1
        beq.s substractOperation
        
        //case *
        ldarg.1
        ldc.i4 2
        beq.s multiplyOperation
        
        //case /
        ldarg.1
        ldc.i4 3
        beq.s divideOperation
        
        //case undefined
        ldarg.1
        ldc.i4 4
        beq.s undefinedOperation
        
        addOperation: 
        add
        ret
        
        substractOperation: 
        sub
        ret
        
        multiplyOperation: 
        mul
        ret
        
        divideOperation: 
        div
        ret
        
        undefinedOperation:
        pop 
        newobj instance void [System.Runtime]System.ArgumentOutOfRangeException::.ctor()
        throw
        ret
    }
}



