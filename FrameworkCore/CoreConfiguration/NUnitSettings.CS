using NUnit.Framework;

[assembly: LevelOfParallelism(5)]
[assembly: Parallelizable(ParallelScope.Fixtures)]