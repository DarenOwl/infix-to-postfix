using System;
using System.Collections.Generic;
using System.IO;

namespace InfixToPrefix
{
    class Calculator
    {
        Dictionary<string, int> priority = new Dictionary<string, int>()
            { {"(", -1 }, {")",0 },
            {"+", 1}, {"-", 1},
            {"*", 2}, {":", 2},
            { "ln", 3},{"sqrt", 3},{"cos", 3},{"sin", 3},
            {"^", 4} };

        Dictionary<string, int> variables = new Dictionary<string, int>();

        public double GetResult(string filepath)
        {
            string[] input = File.ReadAllLines(filepath);
            ReadVariables(input);
            return CalculateInPostfixNotation(InfixToPostfix(input[0]));
        }

        public double GetResultAndShowProcess(string filepath)
        {
            string[] input = File.ReadAllLines(filepath);

            Console.WriteLine("Input expression (infix notation):");
            Console.WriteLine(input[0]);

            var postfix = InfixToPostfix(input[0]);
            Console.WriteLine("\nPostfix notation:");
            PrintExpression(postfix);

            ReadVariables(input);
            Console.WriteLine("\nVariables found:");
            PrintVariables();

            var result = CalculateInPostfixNotation(postfix);
            Console.WriteLine("\nResult:");
            Console.WriteLine(result);
            Console.WriteLine("\n\n");
            return result;
        }

        public void ReadVariables(string[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                var pair = input[i].Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
                variables[pair[0]] = int.Parse(pair[1]);
            }
        }

        public List<string> InfixToPostfix(string expression)
        {
            MyStack functions = new MyStack();
            string[] words = expression.Split(' '); //разбитое на "слова" выражение
            List<string> postfix = new List<string>();

            foreach (var word in words)
            {
                if (char.IsDigit(word[0]))
                    postfix.Add(word);
                else if (word == "(")
                    functions.Push(word);
                else if (!priority.ContainsKey(word))
                    postfix.Add(word);
                else
                {
                    while (!functions.IsEmpty())
                        if (priority[functions.Top()] >= priority[word])
                            postfix.Add(functions.Pop());
                        else break;
                    if (word == ")")
                        functions.Pop();
                    else
                        functions.Push(word);
                }
            }
            while (!functions.IsEmpty())
                postfix.Add(functions.Pop());

            return postfix;
        }

        public double CalculateInPostfixNotation(List<string> expression)
        {
            return 0;
        }

        void PrintExpression(IEnumerable<string> expression)
        {
            foreach (var word in expression)
            {
                Console.Write(word);
                Console.Write(' ');
            }
            Console.WriteLine();
        }

        void PrintVariables()
        {
            foreach (var pair in variables)
            {
                Console.Write("variable: ");
                Console.Write(pair.Key);
                Console.Write("\tvalue: ");
                Console.WriteLine(pair.Value);
            }
        }
    }
}
