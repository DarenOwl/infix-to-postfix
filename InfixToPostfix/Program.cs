using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfixToPrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            new Calculator().GetResultAndShowProcess("expression.txt");
            new Calculator().GetResultAndShowProcess("expression2.txt");
            new Calculator().GetResultAndShowProcess("expression3.txt");
        }
    }
}
