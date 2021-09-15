using BenchmarkDotNet.Running;

namespace NoteList.WebApi.BenchmarkTests
{
    class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).RunAllJoined();
        }
    }
}
