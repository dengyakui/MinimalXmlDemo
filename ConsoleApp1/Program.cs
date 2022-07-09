// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;

using ConsoleApp1;

Console.WriteLine("Hello, World!");

BenchmarkRunner.Run<CompareBetweenStream>();
