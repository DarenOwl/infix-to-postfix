using System;
using System.Collections.Generic;
using System.IO;

namespace InfixToPrefix
{
    public class MyStack
    {
        List<string> list = new List<string>();
        public void Push(string value)
        {
            list.Add(value);
        }
        public string Pop()
        {
            if (list.Count == 0) return "Ошибка выполнения команды - Стек пуст";
            var result = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return result;
        }

        public string Top()
        {
            if (list.Count != 0)
                return list[list.Count - 1];
            return "Ошибка выполнения команды - Стек пуст";
        }

        public bool IsEmpty()
        {
            return list.Count == 0;
        }

        public void Print()
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public static void ExecuteFromFile()
        {
            //считывание из файла
            var watch = System.Diagnostics.Stopwatch.StartNew();

            string input = File.ReadAllText("input.txt");

            watch.Stop();
            Console.WriteLine("Время считывания: " + watch.Elapsed);


            //Выполнение программы
            watch.Restart();

            var commands = input.Split(' ');
            var s = new MyStack();
            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i][0] == '1')
                {
                    var val = commands[i].Split(',')[1];
                    s.Push(val);
                    Console.WriteLine("Push: " + val);
                }
                else if (commands[i] == "2")
                    Console.WriteLine("Pop: " + s.Pop());
                else if (commands[i] == "3")
                    Console.WriteLine("Top: " + s.Top());
                else if (commands[i] == "4")
                    Console.WriteLine("IsEmpty: " + s.IsEmpty());
                else if (commands[i] == "5")
                {
                    Console.WriteLine("Print:");
                    s.Print();
                }
            }
            Console.WriteLine("Время выполнения: " + watch.Elapsed);
        }
    }  
}
