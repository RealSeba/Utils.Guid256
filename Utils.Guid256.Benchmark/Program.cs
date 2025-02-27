using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using System.Runtime.Intrinsics;

namespace Utils.Guid256.Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Guid256 g = new Guid256();
            var dateTime = DateTime.Now.ToString("yyyyMMdd");
            var config = ManualConfig.Create(DefaultConfig.Instance)
                .WithArtifactsPath($"./../../../BenchmarkResults/{dateTime}");

            var summary = BenchmarkRunner.Run<BenchmarkBasic>(config);
        }
    }
}
