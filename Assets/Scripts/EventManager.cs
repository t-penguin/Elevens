using System;
using System.Collections.Generic;
using UnityEditor;

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
    public static event Action<Card[]> StartingCardsDealt;
    public static void DealtStartingCards(Card[] cards) => StartingCardsDealt?.Invoke(cards);

    // Clicked Card Event
    public static event Action<Card, bool> ClickedCard;
    public static void ClickCard(Card card, bool selected) => ClickedCard?.Invoke(card, selected);

    // Replaced Cards Event
    public static event Action<Card[], List<int>> ReplacedCards;
    public static void ReplaceCards(Card[] cards, List<int> indexes) => ReplacedCards?.Invoke(cards, indexes);
}