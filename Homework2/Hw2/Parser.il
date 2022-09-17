.class public abstract sealed auto ansi beforefieldinit
  Hw2.Parser
{
    .method public static void ParseCalcArguments(string[] args,
        [out] float64& val1,
        [out] valuetype CalculatorOperation& operation,
        [out] float64& val2)
    {
        ldarg.0
        ldlen
        conv.i4
        ldc.i4.3
        beq SuppLen
        ldstr "Invalid count of input arguments"
        newobj instance void [System.Runtime]System.ArgumentException::.ctor(string)
        throw
        
        SuppLen:
        ldelem.ref
        ldarg.3
        call bool [System.Runtime]System.Double::TryParse(string, float64&)
        stloc.1
        
        ldelem.ref
        call valuetype CalculatorOperation HW2.Parser::ParseOperation(string)
        starg 2
        
        ldelem.ref
        ldarg.1
        call bool [System.Runtime]System.Double::TryParse(string, float64&)
        ldloc.1
        beq ValsParsed
        ldstr "Wrong request syntax or unsupported type of values given. Format: {value operation value}. As values can be entered all integer or fractional numbers"
        newobj instance void [System.Runtime]System.ArgumentException::.ctor(string)
        throw
        
        ValsParsed:
        ret
    }
    
    .method public static valuetype CalculatorOperation ParseOperation(string arg)
    {
        ldstr "Plus"
        ldarg.0
        beq Plus
        
        ldstr "Minus"
        ldarg.0
        beq Minus
        
        ldstr "Multiply"
        ldarg.0
        beq Multiply
        
        ldstr "Divide"
        ldarg.0
        beq Divide
        
        Plus:
        ldc.i4.0
        ret
        
        Minus:
        ldc.i4.1
        ret
        
        Multiply:
        ldc.i4.2
        ret
        
        Divide:
        ldc.i4.3
        ret
    }
}


