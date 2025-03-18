using System;
using System.Collections.Generic;
using UnityEditor;

public static class EventManager
{
    // Event: The game is starting
    public static event Action GameStarting;
    public static void StartGame() => GameStarting?.Invoke();

    // Event: The game board is being set up
    public static event Action<int> GameSettingUp;
    public static void SetUpGame(int boardSize) => GameSettingUp?.Invoke(boardSize);

    // Event: The game board is done being set up
    public static event Action GameSetUp;
    public static void FinishSetUp() => GameSetUp?.Invoke();

    // Event: The starting cards have been dealt
    public static event Action<Card[]> StartingCardsDealt;
    public static void DealtStartingCards(Card[] cards) => StartingCardsDealt?.Invoke(cards);

    // Event: A card on the board has been clicked
    public static event Action<Card, bool> ClickedCard;
    public static void ClickCard(Card card, bool selected) => ClickedCard?.Invoke(card, selected);

    // Event: Cards on the table have been replaced
    public static event Action<Card[], List<int>> ReplacedCards;
    public static void ReplaceCards(Card[] cards, List<int> indexes) => ReplacedCards?.Invoke(cards, indexes);
}