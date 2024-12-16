using System;
using System.Threading;

class Program
{
  static void Main()
  {
    Stopwatch stopwatch = new Stopwatch();

    void HandleOnTriggered(string message)
    {
      Console.WriteLine(message);
    }
                
    stopwatch.OnStarted += HandleOnTriggered;
    stopwatch.OnStopped += HandleOnTriggered;
    stopwatch.OnReset += HandleOnTriggered;

    bool quit = false;

    while (!quit)
    {
      if (Console.KeyAvailable)
      {
        ConsoleKey key = Console.ReadKey(true).Key;

        if (key == ConsoleKey.S)
        {
          stopwatch.Start();
        }
        else if (key == ConsoleKey.T)
        {
          stopwatch.Stop();
        }
        else if (key == ConsoleKey.R)
        {
          stopwatch.Reset();
        }
        else if (key == ConsoleKey.Q)
        {
          quit = true;
        }
        else {
          Console.WriteLine("Wrong Input. Try Again.");
        }
      }
      
      Thread.Sleep(1000);
      stopwatch.Tick();

      Console.Clear();
      Console.WriteLine("Stopwatch Program");
      Console.WriteLine("Press S to Start | T to Stop | R to Reset | Q to Quit");
      Console.WriteLine($"Elapsed Time: {stopwatch.GetElapsedTime()}");
    }
    Console.WriteLine("Program Ended.");    
  }
}

