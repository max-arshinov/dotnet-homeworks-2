.class public abstract sealed auto ansi beforefieldinit
  Hw2.Calculator
{
    .method public static float64 Calculate(float64, valuetype Hw2.CalculatorOperation operation, float64){
        .locals init(
        [0] float64 value1,
        [1] float64 value2
        )
        
        ldarg.1 
        switch (add_label, sub_label, mul_label, div_label)
        br.s exception_label
        
        add_label:ldarg.0
        ldarg.2
        add
        ret
        
        div_label:ldarg.0
        ldarg.2
        div
        ret
        
        mul_label:ldarg.0
        ldarg.2
        mul
        ret
        
        sub_label:ldarg.0
        ldarg.2
        sub
        ret
        
        exception_label:newobj       instance void [System.Runtime]System.ArgumentOutOfRangeException::.ctor()
        throw
        
    }   
} 
  



