.class public abstract sealed auto ansi beforefieldinit
  Hw2.Parser extends System.Object
{
    .method public static void ParseCalcArguments(string[] args,
        [out] float64& value1,
        [out] valuetype Hw2.CalculatorOperation& operation,
        [out] float64& value2
        ) cil managed
    {
       //checking if arg is null
       ldarg.0
       brfalse.s badArgs
       
       //checking args length
       ldarg.0
       call bool Hw2.Parser::IsArgLengthSupported(string[])
       brfalse.s badArgs 
       
       //parsing value1
       ldarg.0
       ldc.i4.0
       ldelem.ref 
       ldarg.1 
       call bool [System.Runtime]System.Double::TryParse(string, float64&)
       //checking if parsed
       brfalse.s badArgs
       
       //parsing value2
       ldarg.0
       ldc.i4.2
       ldelem.ref 
       ldarg.3 
       call bool [System.Runtime]System.Double::TryParse(string, float64&)
       //checking if parsed
       brfalse.s badArgs
       
       
       
       //Parse operation
       ldarg.2
       ldarg.0
       ldc.i4.1
       ldelem.ref
       call valuetype Hw2.CalculatorOperation Hw2.Parser::ParseOperation(string)
       stind.i1
       
       //if operation is undefined
       ldarg.2
       ldind.i1
       ldc.i4.4
       ceq
       brtrue.s invalidOperation
       
       ret
       
       badArgs:
       newobj instance void [System.Runtime]System.ArgumentException::.ctor()
       throw
       
       invalidOperation:
       newobj instance void [System.Runtime]System.InvalidOperationException::.ctor()
       throw
    }
    
    .method private static 
    valuetype Hw2.CalculatorOperation ParseOperation(string arg) cil managed
    {
        .maxstack 3
        .locals init ([0] valuetype Hw2.CalculatorOperation)
        
        ldstr "+"
        ldarg.0
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brtrue.s addOperation
        
        ldstr "-"
        ldarg.0
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brtrue.s substractOperation
        
        ldstr "*"
        ldarg.0
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brtrue.s multiplyOperation
        
        ldstr "/"
        ldarg.0
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brtrue.s divideOperation
        
        br.s undefinedOperation
        
        
        addOperation: 
        ldc.i4 0
        br.s methodExit
        
        substractOperation: 
        ldc.i4.1
        br.s methodExit
        
        multiplyOperation: 
        ldc.i4.2
        br.s methodExit
        
        divideOperation: 
        ldc.i4.3
        br.s methodExit
        
        undefinedOperation:
        ldc.i4.4
        br.s methodExit
        
        methodExit:
        //cast to enum
        stloc.0
        ldloc.0
        ret
    }
    
    .method public static bool IsArgLengthSupported(string[] args) cil managed
    {
        .maxstack 2
        ldarg.0
        ldlen
        ldc.i4.3
        ceq
        ret
    }
}


