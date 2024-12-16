class Stopwatch
{
  private int TimeElapsed; 
  private bool IsRunning;

  
  public delegate void StopwatchEventHandler(string message);
  public event StopwatchEventHandler OnStarted;
  public event StopwatchEventHandler OnStopped;
  public event StopwatchEventHandler OnReset;

  public Stopwatch()
  {
    TimeElapsed = 0;
    IsRunning = false;
  }

  public void Start()
  {
    if (!IsRunning)
    {
      IsRunning = true;
      OnStarted?.Invoke("Stopwatch Started!");
    }
  }

  public void Stop()
  {
    if (IsRunning)
    {
      IsRunning = false;
      OnStopped?.Invoke("Stopwatch Stopped!");
    }
  }

  public void Reset()
  {
    TimeElapsed = 0;
    IsRunning = false;
    OnReset?.Invoke("Stopwatch Reset!");
  }

  public void Tick()
  {
    if (IsRunning)
    {
      TimeElapsed++;
    }
  }

  public string GetElapsedTime()
  {
    int hours = TimeElapsed / 3600;
    int minutes = (TimeElapsed % 3600) / 60;
    int seconds = TimeElapsed % 60;

    return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
  }
}