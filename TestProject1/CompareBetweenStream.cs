using BenchmarkDotNet.Attributes;

namespace TestProject1
{
    public class CompareBetweenStream
    {

        [Benchmark]
        public void UseMemoryStream()
        {

        }


        [Benchmark]
        public void UseFileBuffingWriteStream()
        {

        }
    }
}
