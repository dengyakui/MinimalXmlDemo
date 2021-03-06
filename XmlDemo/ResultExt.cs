using System.Xml.Serialization;

using Microsoft.AspNetCore.WebUtilities;
namespace Microsoft.AspNetCore.Http;

public static class ResultsExtension
{
    public static IResult Xml<T>(this Microsoft.AspNetCore.Http.IResultExtensions resultExtension, T obj)
    {
        return new XmlResult<T>(obj);
    }
    public static IResult XmlV2<T>(this Microsoft.AspNetCore.Http.IResultExtensions resultExtension, T obj)
    {
        return new XmlResultV2<T>(obj);
    }
}



public class XmlResult<T> : IResult
{
    // Create the serializer that will actually perform the XML serialization
    private static readonly XmlSerializer Serializer = new(typeof(T));

    // The object to serialize
    private readonly T _result;

    public XmlResult(T result)
    {
        _result = result;
    }

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        // NOTE: best practice would be to pull this, we'll look at this shortly
        using var ms = new MemoryStream();

        // Serialize the object synchronously then rewind the stream
        Serializer.Serialize(ms, _result);
        ms.Position = 0;

        httpContext.Response.ContentType = "application/xml";
        await ms.CopyToAsync(httpContext.Response.Body);
    }
}



public class XmlResultV2<T> : IResult
{
    // Create the serializer that will actually perform the XML serialization
    private static readonly XmlSerializer Serializer = new(typeof(T));

    // The object to serialize
    private readonly T _result;

    public XmlResultV2(T result)
    {
        _result = result;
    }

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        // NOTE: best practice would be to pull this, we'll look at this shortly
        using var ms = new FileBufferingWriteStream();

        // Serialize the object synchronously then rewind the stream
        Serializer.Serialize(ms, _result);

        httpContext.Response.ContentType = "application/xml";
        await ms.DrainBufferAsync(httpContext.Response.Body);
    }
}