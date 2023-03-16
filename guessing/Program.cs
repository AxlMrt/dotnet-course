namespace Guessing_Game
{
  class Guess_Program
  {
    static void Main(string[] args)
    {
      Random rd = new Random();
      int rand_num = rd.Next(0, 10);
      int user_num;
      int counter = 0;
      string result = counter > 1 ? "guesses" : "guess";
  
      Console.Write("Wanna play a game with me ? Try to guess my number between 0 and 10 !\n");
      do
      {
        Console.Write("Enter your guess: ");
        user_num = Int32.Parse(Console.ReadLine());
        counter++;
      } while (user_num != rand_num);

      if (user_num == rand_num)
      {
        Console.WriteLine($"You win ! You made {counter} {result} !");
      }
    }
  }
}
