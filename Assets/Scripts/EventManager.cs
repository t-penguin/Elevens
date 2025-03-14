using System;

public static class EventManager
{
    // Start Game Event
    public static event Action GameStarted;
    public static void StartGame() => GameStarted?.Invoke();
}