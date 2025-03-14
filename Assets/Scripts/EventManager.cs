using System;

public static class EventManager
{
    // Start Game Event
    public static event Action GameStarting;
    public static void StartGame() => GameStarting?.Invoke();

    // Set Up Game Event
    public static event Action<int> GameSettingUp;
    public static void SetUpGame(int boardSize) => GameSettingUp?.Invoke(boardSize);
}