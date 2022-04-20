**Legend**
Mean   : Arithmetic mean of all measurements
Error  : Half of 99.9% confidence interval
StdDev : Standard deviation of all measurements
1 ns   : 1 Nanosecond (0.000000001 sec)

### WithResultInstances
[Code](https://github.com/mcarey1590/fp_playground/blob/0e8b08219550dea21394c82df7d0792865951258/WithResultInstances.cs)

``` ini  
  
BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.1 (21C52) [Darwin 21.2.0]  
Intel Core i9-9880H CPU 2.30GHz, 1 CPU, 16 logical and 8 physical cores  
.NET SDK=6.0.101  
 [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  
  
```  
|                                           Method |      Mean |    Error |   StdDev |  
|------------------------------------------------- |----------:|---------:|---------:|  
|  DoSomethingWithId_EmptyGuid_ReturnsErrorMessage |  29.17 ns | 0.086 ns | 0.076 ns |  
| DoSomethingWithId_RandomGuid_ReturnsErrorMessage | 226.29 ns | 3.658 ns | 3.422 ns |  
|       DoSomethingWithId_TheOne_ReturnsSuccessful | 162.86 ns | 3.189 ns | 5.058 ns |

### WithLocalException
[Code](https://github.com/mcarey1590/fp_playground/blob/0e8b08219550dea21394c82df7d0792865951258/WithLocalException.cs)
``` ini  
  
BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.1 (21C52) [Darwin 21.2.0]  
Intel Core i9-9880H CPU 2.30GHz, 1 CPU, 16 logical and 8 physical cores  
.NET SDK=6.0.101  
 [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  
  
```  
|                                           Method |        Mean |     Error |    StdDev |  
|------------------------------------------------- |------------:|----------:|----------:|  
|  DoSomethingWithId_EmptyGuid_ReturnsErrorMessage | 24,806.9 ns |  49.65 ns |  46.44 ns |  
| DoSomethingWithId_RandomGuid_ReturnsErrorMessage | 25,378.7 ns | 121.07 ns | 107.33 ns |  
|       DoSomethingWithId_TheOne_ReturnsSuccessful |    156.8 ns |   3.10 ns |   2.75 ns |

### WithFpLanguageExt
[Code](https://github.com/mcarey1590/fp_playground/blob/0e8b08219550dea21394c82df7d0792865951258/WithFpLanguageExt.cs)

``` ini  
  
BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.1 (21C52) [Darwin 21.2.0]  
Intel Core i9-9880H CPU 2.30GHz, 1 CPU, 16 logical and 8 physical cores  
.NET SDK=6.0.101  
 [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  
  
```  
|                                           Method |     Mean |   Error |  StdDev |  
|------------------------------------------------- |---------:|--------:|--------:|  
|  DoSomethingWithId_EmptyGuid_ReturnsErrorMessage | 117.4 ns | 0.38 ns | 0.33 ns |  
| DoSomethingWithId_RandomGuid_ReturnsErrorMessage | 388.6 ns | 5.50 ns | 5.14 ns |  
|       DoSomethingWithId_TheOne_ReturnsSuccessful | 283.3 ns | 3.06 ns | 2.71 ns |