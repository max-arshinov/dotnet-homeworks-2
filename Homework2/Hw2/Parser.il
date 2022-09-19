.class public abstract sealed auto ansi beforefieldinit
  Hw2.Parser
{
    .method public static void ParseCalcArguments(string[] args,
     [out] float64& a,
     [out] valuetype Hw2.CalculatorOperation& operation,
     [out] float64& b){    
        ldarg args
        call bool Hw2.Parser::IsArgLengthSupported(string[])
        brfalse argumentexception_label
        
        ldarg args      
        ldc.i4.0
        ldelem.ref
        ldarg a
        call bool [System.Runtime]System.Double::TryParse(string, float64&)
        brfalse incorrectdata_exception_label       
             
        ldarg operation
        ldarg args    
        ldc.i4.1
        ldelem.ref
        call valuetype Hw2.CalculatorOperation Hw2.Parser::ParseOperation(string)
        stind.i4

        ldarg args     
        ldc.i4.2
        ldelem.ref
        ldarg b
        call         bool [System.Runtime]System.Double::TryParse(string, float64&)
        brfalse    incorrectdata_exception_label     
        
        ret
        
        incorrectdata_exception_label: 
        ldstr "Данные введены некорректно"
        newobj instance void [System.Runtime]System.ArgumentException::.ctor(string)
        throw
        
        argumentexception_label: 
        ldstr "Неверный формат данных"
        newobj instance void [System.Runtime]System.ArgumentException::.ctor()
        throw                 
     }
     
     .method private static bool IsArgLengthSupported(string[] args){
        ldarg.0
        ldlen
        conv.i4
        ldc.i4.3
        ceq
        ret
     }
     
     .method private static valuetype Hw2.CalculatorOperation ParseOperation(string arg){
        
        .locals init (
      [0] valuetype Hw2.CalculatorOperation V_0
    )       
        ldarg arg
        ldstr "+"
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brfalse Minus
        ldc.i4.0
        ret
        
        Minus: 
        ldarg arg
        ldstr "-"
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brfalse Multiply
        ldc.i4.1
        ret
        
        Multiply:
        ldarg arg
        ldstr "*"
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brfalse Divide
        ldc.i4.2
        ret
        
        Divide:
        ldarg arg
        ldstr "/"
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brfalse exception_label
        ldc.i4.3
        ret
        
        exception_label:
        newobj instance void [System.Runtime]System.InvalidOperationException::.ctor()
        throw
     }
}


