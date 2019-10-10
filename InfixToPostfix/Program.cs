namespace InfixToPrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            new Calculator().GetResultAndShowProcess("expression.txt");
            //new Calculator().GetResultAndShowProcess("expression2.txt");
            //new Calculator().GetResultAndShowProcess("expression3.txt");
            //new Calculator().GetResultAndShowProcess("expression4.txt");

            //MyStack<string>.ExecuteFromFile();
        }
    }
}
