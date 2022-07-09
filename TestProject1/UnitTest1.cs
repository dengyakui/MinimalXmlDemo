using BenchmarkDotNet.Running;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var summary =  BenchmarkRunner.Run<CompareBetweenStream>();
            Console.WriteLine(summary);
        }
    }
}