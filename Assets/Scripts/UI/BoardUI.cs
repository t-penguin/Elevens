using UnityEngine;
using UnityEngine.UI;

public class BoardUI : MonoBehaviour
{
    [SerializeField] private GameObject _tableCard;
    [SerializeField] private Transform _board;
    [SerializeField] private RectTransform[] _tableCards;

    #region Monobehaviour Callbacks

    private void OnEnable()
    {
        EventManager.GameSettingUp += OnSetUp;
    }

    private void OnDisable()
    {
        EventManager.GameSettingUp -= OnSetUp;
    }

    #endregion

    #region Event Callbacks

    /// <summary>
    /// Response to the game's SetUp event. Sets up the board for the specified boardSize.
    /// </summary>
    /// <param name="boardSize">The maximum number of cards that will be on the board</param>
    private void OnSetUp(int boardSize)
    {
        SetBoardLayout(boardSize);

        if (_tableCards != null && _tableCards.Length == boardSize)
            return;

        if (_tableCards != null)
        {
            for (int i = 0; i < _tableCards.Length; i++)
                Destroy(_tableCards[i]);
        }

        _tableCards = new RectTransform[boardSize];
        for (int i = 0; i < boardSize; i++)
            _tableCards[i] = Instantiate(_tableCard, _board).GetComponent<RectTransform>();
    }

    /// <summary>
    /// Sets the board's GridLayoutGroup padding based on the board size
    /// </summary>
    /// <param name="boardSize">The maximum number of cards that will be on the board</param>
    private void SetBoardLayout(int boardSize)
    {
        int columns = Mathf.CeilToInt(Mathf.Sqrt(boardSize));
        int rows = Mathf.CeilToInt((float)boardSize / columns);

        GridLayoutGroup glg = GetComponent<GridLayoutGroup>();
        RectTransform rectTransform = GetComponent<RectTransform>();
        glg.constraintCount = columns;
        glg.padding.top = (int)((rectTransform.sizeDelta.y - glg.cellSize.y * rows - glg.spacing.y * (rows - 1)) / 2);
        glg.padding.left = (int)((rectTransform.sizeDelta.x - glg.cellSize.x * columns - glg.spacing.x * (columns - 1)) / 2);
    }

    #endregion
}