using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformationFileStorage
{
    internal interface ITrancer
    {
        void WriteLine(string message);
    }
    public class ConsoleTrancer : ITrancer
    {
        public void WriteLine(string message) => Console.WriteLine(message);
    }
    public class EmptyTracer: ITrancer
    {
        public void WriteLine(string message) { }
    }
}
