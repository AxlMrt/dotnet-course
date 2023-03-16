using System;
namespace Calculate
{
  class Calculator
  {
    static void Main()
    {
      Console.WriteLine("This is a calculator.");
      Console.Write("0: Add\n1: Substract\n2: Divide");
      Console.Write("\nWhat would you like to do ?\n");
  
      double user;
      do
      {
        user = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Please, choose a valid number");
      } while (user > 2 || user < 0);
  
      Console.Write("Pick your first number: ");
      double first = Convert.ToDouble(Console.ReadLine());
      Console.Write("Pick the second one: ");
      double second = Convert.ToDouble(Console.ReadLine());
  
      Console.WriteLine("Result is");
      Operations(user, first, second);
    }

    static void Operations(double op, double a, double b)
    {
      switch (op)
      {
        case 0:
          Console.WriteLine(a + b);
          break;
        case 1:
          Console.WriteLine(a - b);
          break;
        case 2:
          Console.WriteLine(a / b);
          break;
      }
    }
  }
}