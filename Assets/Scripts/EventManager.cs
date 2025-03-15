using System;

public static class EventManager
{
    // Start Game Event
    public static event Action GameStarting;
    public static void StartGame() => GameStarting?.Invoke();

    // Set Up Game Event
    public static event Action<int> GameSettingUp;
    public static void SetUpGame(int boardSize) => GameSettingUp?.Invoke(boardSize);

    // Game Set Up Event
    public static event Action GameSetUp;
    public static void FinishSetUp() => GameSetUp?.Invoke();
}