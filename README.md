Usus.NET
========

This Visual Studio extension provides static code analysis for software developed with .NET.
![Usus.NET VSIX](https://github.com/usus/Usus.NET/wiki/andrenarefacafter.png)

The analysis can also be performed in code.
```csharp
//var metrics = Analyze.PortableExecutables(assemblyToAnalyze);
var metrics = Analyze.Me();
foreach (var method in metrics.Methods)
{
	Console.WriteLine("Signature: " + method.Signature);
	Console.WriteLine("CC: " + method.CyclomaticComplexity);
}
```

The result of the analysis can be rated and filtered for hotspots.
```csharp
RatedMetrics rated = metrics.Rate();
double acd = rated.AverageComponentDependency;
int cyclicNamespaces = rated.NamespacesWithCyclicDependencies;

MetricsHotspots hotspots = metrics.Hotspots();
var complicatedMethods = hotspots.OfCyclomaticComplexity();
var bigClasses = hotspots.OfClassSizeOver(10);
```
