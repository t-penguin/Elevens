using System;
using System.Collections.Generic;

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

    // Starting Cards Dealt Event
    public static event Action<List<Card>> StartingCardsDealt;
    public static void DealtStartingCards(List<Card> cards) => StartingCardsDealt?.Invoke(cards);
}