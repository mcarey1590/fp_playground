**Legend**
Mean      : Arithmetic mean of all measurements
Error     : Half of 99.9% confidence interval
StdDev    : Standard deviation of all measurements
Gen 0     : GC Generation 0 collects per 1000 operations
Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
1 ns      : 1 Nanosecond (0.000000001 sec)


### WithResultInstances
[Code](https://github.com/mcarey1590/fp_playground/blob/0e8b08219550dea21394c82df7d0792865951258/WithResultInstances.cs)

``` ini  
  
BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.1 (21C52) [Darwin 21.2.0]  
Intel Core i9-9880H CPU 2.30GHz, 1 CPU, 16 logical and 8 physical cores  
.NET SDK=6.0.101  
 [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  
  
```  
|                                           Method |      Mean |    Error |   StdDev |  Gen 0 | Allocated |  
|------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|  
|  DoSomethingWithId_EmptyGuid_ReturnsErrorMessage |  29.72 ns | 0.243 ns | 0.215 ns | 0.0134 |     112 B |  
| DoSomethingWithId_RandomGuid_ReturnsErrorMessage | 227.86 ns | 3.421 ns | 3.200 ns | 0.0372 |     312 B |  
|       DoSomethingWithId_TheOne_ReturnsSuccessful | 164.27 ns | 0.696 ns | 0.617 ns | 0.0420 |     352 B |

### WithLocalException
[Code](https://github.com/mcarey1590/fp_playground/blob/0e8b08219550dea21394c82df7d0792865951258/WithLocalException.cs)

``` ini  
  
BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.1 (21C52) [Darwin 21.2.0]  
Intel Core i9-9880H CPU 2.30GHz, 1 CPU, 16 logical and 8 physical cores  
.NET SDK=6.0.101  
 [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  
  
```  
|                                           Method |        Mean |     Error |    StdDev |  Gen 0 | Allocated |  
|------------------------------------------------- |------------:|----------:|----------:|-------:|----------:|  
|  DoSomethingWithId_EmptyGuid_ReturnsErrorMessage | 24,788.4 ns | 136.32 ns | 120.84 ns | 0.0305 |     448 B |  
| DoSomethingWithId_RandomGuid_ReturnsErrorMessage | 25,440.4 ns | 174.16 ns | 135.97 ns | 0.0610 |     720 B |  
|       DoSomethingWithId_TheOne_ReturnsSuccessful |    157.9 ns |   3.12 ns |   4.57 ns | 0.0477 |     400 B |

### WithFpLanguageExt
[Code](https://github.com/mcarey1590/fp_playground/blob/0e8b08219550dea21394c82df7d0792865951258/WithFpLanguageExt.cs)

``` ini  
  
BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.1 (21C52) [Darwin 21.2.0]  
Intel Core i9-9880H CPU 2.30GHz, 1 CPU, 16 logical and 8 physical cores  
.NET SDK=6.0.101  
 [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  
  
```  
|                                           Method |     Mean |   Error |  StdDev |  Gen 0 | Allocated |  
|------------------------------------------------- |---------:|--------:|--------:|-------:|----------:|  
|  DoSomethingWithId_EmptyGuid_ReturnsErrorMessage | 116.4 ns | 0.43 ns | 0.36 ns | 0.0544 |     456 B |  
| DoSomethingWithId_RandomGuid_ReturnsErrorMessage | 387.8 ns | 7.65 ns | 8.18 ns | 0.0715 |     600 B |  
|       DoSomethingWithId_TheOne_ReturnsSuccessful | 281.3 ns | 0.93 ns | 0.87 ns | 0.0477 |     400 B |