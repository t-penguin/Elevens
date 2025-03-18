using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private TextMeshProUGUI _resultText;

    private const string LOSS_TEXT = "No more moves remaining!\nYou lost!";

    #region Monobehaviour Callbacks

    private void OnEnable()
    {
        EventManager.LostGame += OnLose;
    }

    private void OnDisable()
    {
        EventManager.LostGame -= OnLose;
    }

    #endregion

    #region Event Callbacks

    private void OnLose()
    {
        _resultPanel.SetActive(true);
        _resultText.text = LOSS_TEXT;
    }

    #endregion

    #region Button Callbacks

    public void OnStartGame() => EventManager.StartGame();
    

    #endregion
}