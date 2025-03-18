using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private TextMeshProUGUI _resultText;

    private const string LOSS_TEXT = "No more moves remaining!\nYou lost!";
    private const string WIN_TEXT = "Board cleared!\nCongratulations!\n You won!";

    #region Monobehaviour Callbacks

    private void OnEnable()
    {
        EventManager.GameLost += OnLose;
        EventManager.GameWon += OnWin;
    }

    private void OnDisable()
    {
        EventManager.GameLost -= OnLose;
        EventManager.GameWon -= OnWin;
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

    #endregion

    #region Button Callbacks

    public void OnStartGame() => EventManager.StartGame();
    

    #endregion
}