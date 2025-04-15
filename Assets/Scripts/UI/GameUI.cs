using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject _deck;
    [SerializeField] private TextMeshProUGUI _remainingText;

    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private TextMeshProUGUI _gamesWonText;
    [SerializeField] private TextMeshProUGUI _gamesPlayedText;
    [SerializeField] private TextMeshProUGUI _winRateText;

    private const string LOSS_TEXT = "No more moves remaining!\nYou lost!";
    private const string WIN_TEXT = "Board cleared!\nCongratulations!\n You won!";
    private const string GAMES_WON_TEXT = "Wins:";
    private const string GAMES_PLAYED_TEXT = "Played:";
    private const string WIN_RATE_TEXT = "Win Rate:";
    private const string CARDS_REMAINING_TEXT = "Remaining:";

    private int _cardsRemaining;

    #region Monobehaviour Callbacks

    private void OnEnable()
    {
        EventManager.StartingCardsDealt += OnStartingCardsDealt;
        EventManager.ReplacedCards += OnReplacedCards;
        EventManager.GameLost += OnLose;
        EventManager.GameWon += OnWin;
        EventManager.UpdateDisplay += OnUpdateDisplay;
    }

    private void OnDisable()
    {
        EventManager.StartingCardsDealt -= OnStartingCardsDealt;
        EventManager.ReplacedCards -= OnReplacedCards;
        EventManager.GameLost -= OnLose;
        EventManager.GameWon -= OnWin;
        EventManager.UpdateDisplay -= OnUpdateDisplay;
    }

    #endregion

    #region Event Callbacks

    private void OnLose()
    {
        _resultPanel.SetActive(true);
        _resultText.text = LOSS_TEXT;
    }

    private void OnWin()
    {
        _resultPanel.SetActive(true);
        _resultText.text = WIN_TEXT;
    }

    private void OnUpdateDisplay(int won, int played)
    {
        _gamesWonText.text = $"{GAMES_WON_TEXT} {won}";
        _gamesPlayedText.text = $"{GAMES_PLAYED_TEXT} {played}";
        _winRateText.text = $"{WIN_RATE_TEXT} {(100f * won / played):F2}%";
    }

    private void OnStartingCardsDealt(Card[] cards)
    {
        _cardsRemaining = 52 - cards.Length;
        _remainingText.text = $"{CARDS_REMAINING_TEXT} {_cardsRemaining}";
    }

    private void OnReplacedCards(Card[] cards, List<int> indexes)
    {
        if (_cardsRemaining == 0) 
            return;

        _cardsRemaining = Mathf.Max(_cardsRemaining - indexes.Count, 0);
        _remainingText.text = $"{CARDS_REMAINING_TEXT} {_cardsRemaining}";

        if (_cardsRemaining == 0)
            _deck.SetActive(false);
    }

    #endregion

    #region Button Callbacks

    public void OnStartGame() => EventManager.StartGame();
    

    #endregion
}