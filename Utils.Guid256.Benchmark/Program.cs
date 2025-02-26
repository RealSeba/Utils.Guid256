using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace Utils.Guid256.Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var config = ManualConfig.Create(DefaultConfig.Instance)
                .WithArtifactsPath($"./BenchmarkResults/{dateTime}");

            var summary = BenchmarkRunner.Run<BenchmarkBasic>(config);
        }
    }
}
