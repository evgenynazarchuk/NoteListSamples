using System;
using BenchmarkDotNet;
using BenchmarkDotNet.Running;

namespace NoteList.Repository.BenchmarkTests
{
    class Program
    {
        public static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}
