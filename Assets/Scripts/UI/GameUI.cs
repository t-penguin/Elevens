using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private TextMeshProUGUI _gamesWonText;
    [SerializeField] private TextMeshProUGUI _gamesPlayedText;
    [SerializeField] private TextMeshProUGUI _winRateText;

    private const string LOSS_TEXT = "No more moves remaining!\nYou lost!";
    private const string WIN_TEXT = "Board cleared!\nCongratulations!\n You won!";
    private const string GAMES_WON_TEXT = "Wins: ";
    private const string GAMES_PLAYED_TEXT = "Played: ";
    private const string WIN_RATE_TEXT = "Win Rate: ";

    #region Monobehaviour Callbacks

    private void OnEnable()
    {
        EventManager.GameLost += OnLose;
        EventManager.GameWon += OnWin;
        EventManager.UpdateDisplay += OnUpdateDisplay;
    }

    private void OnDisable()
    {
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
        _gamesWonText.text = $"{GAMES_WON_TEXT}{won}";
        _gamesPlayedText.text = $"{GAMES_PLAYED_TEXT}{played}";
        _winRateText.text = $"{WIN_RATE_TEXT}{(100f * won / played):F2}%";
    }

    #endregion

    #region Button Callbacks

    public void OnStartGame() => EventManager.StartGame();
    

    #endregion
}