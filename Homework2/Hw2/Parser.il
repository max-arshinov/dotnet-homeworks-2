.class public abstract sealed auto ansi beforefieldinit
  Hw2.Parser
{
    .method public static void ParseCalcArguments(string[] args,
     [out] float64& a,
     [out] valuetype Hw2.CalculatorOperation& operation,
     [out] float64& b){
     .locals init (
      [0] float64 value1,
      [1] float64 value2,
      [2] bool islengthsupported,
      [3] valuetype [System.Runtime]System.Runtime.CompilerServices.DefaultInterpolatedStringHandler V_3
    )
    
        ldarg.0
        call bool Hw2.Parser::IsArgLengthSupported(string[])
        ldc.i4.0
        ceq
        stloc.2 
        ldloc.2
        brtrue.s argumentexception_label
        
        ldarg.1      
        ldarg.0      
        ldc.i4.0
        ldelem.ref
        ldloca.s     value1
        call         bool [System.Runtime]System.Double::TryParse(string, float64&)
        brfalse.s    incorrectdata_exception_label
        ldloc.0      
        stind.r8
         
        ldarg.2      
        ldarg.0     
        ldc.i4.1
        ldelem.ref
        call         valuetype Hw2.CalculatorOperation Hw2.Parser::ParseOperation(string)
        stind.i4
         
        ldarg.3     
        ldarg.0      
        ldc.i4.2
        ldelem.ref
        ldloca.s     value2
        call         bool [System.Runtime]System.Double::TryParse(string, float64&)
        brfalse.s    incorrectdata_exception_label
        ldloc.1     
        stind.r8
                  
        incorrectdata_exception_label: ldstr "Данные введены некорректно"
        newobj instance void [System.Runtime]System.ArgumentException::.ctor(string)
        throw
        
        argumentexception_label: ldstr ""
        newobj instance void [System.Runtime]System.ArgumentException::.ctor()
        throw                 
        ret
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
        ldarg.0
        switch (add_label, div_label, mul_label, sub_label)
        br.s exception_label
        
        add_label:
        ldstr "+"
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brtrue.s add_true_label
        add_true_label: ldc.i4.0
        stloc.0
        ret
        
        div_label:
        ldstr "-"
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brtrue.s div_true_label
        div_true_label: ldc.i4.1
        stloc.0
        ret
        
        mul_label:
        ldstr "*"
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brtrue.s mul_true_label
        mul_true_label: ldc.i4.2
        stloc.0
        ret
        
        sub_label:
        ldstr "/"
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brtrue.s sub_true_label
        sub_true_label: ldc.i4.3
        stloc.0
        ret
        
        exception_label:newobj       instance void [System.Runtime]System.ArgumentOutOfRangeException::.ctor()
        throw
     }
}


