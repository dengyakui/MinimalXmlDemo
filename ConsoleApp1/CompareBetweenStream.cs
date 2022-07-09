using BenchmarkDotNet.Attributes;

using Microsoft.AspNetCore.Http;

namespace ConsoleApp1
{
    [MemoryDiagnoser]
    public class CompareBetweenStream
    {

        [Benchmark]
        public async Task UseMemoryStreamAsync()
        {
            var stream = new MemoryStream();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Body = stream;
            httpContext.Request.ContentLength = stream.Length;

            var obj=  Enumerable.Range(1, 1000).Select(x => new Person { FirstName = "Andrew" + x, LastName = "Lock" + x }).ToList();
            var result = Results.Extensions.Xml(obj);
            await result.ExecuteAsync(httpContext);
        }


        [Benchmark]
        public async Task UseFileBuffingWriteStreamAsync()
        {
            var stream = new MemoryStream();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Body = stream;
            httpContext.Request.ContentLength = stream.Length;
            var obj = Enumerable.Range(1, 1000).Select(x => new Person { FirstName = "Andrew" + x, LastName = "Lock" + x }).ToList();
            var result = Results.Extensions.XmlV2(obj);
            await result.ExecuteAsync(httpContext);
        }
    }
}
