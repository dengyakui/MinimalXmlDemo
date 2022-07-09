using System.Xml.Serialization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Extensions.Xml(new Person{ FirstName = "Andrew", LastName = "Lock111"}));

app.MapGet("/test", ()=> Results.Ok());

app.Run();


public class Person
{
  public string? FirstName {get; init;}

  public string? LastName {get;init;}
}

