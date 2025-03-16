using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardUI : MonoBehaviour
{
    [SerializeField] private GameObject _tableCard;
    [SerializeField] private Transform _board;
    [SerializeField] private RectTransform[] _tableCards;

    private Dictionary<string, Sprite> _cardSprites;

    private const string CARD_SPRITES_PATH = "Textures/Cards";

    #region Monobehaviour Callbacks

    private void Awake()
    {
        _cardSprites = new Dictionary<string, Sprite>();
        LoadCardSprites(CARD_SPRITES_PATH);
    }

    private void OnEnable()
    {
        EventManager.GameSettingUp += OnSetUp;
        EventManager.StartingCardsDealt += OnStartingCardsDealt;
    }

    private void OnDisable()
    {
        EventManager.GameSettingUp -= OnSetUp;
        EventManager.StartingCardsDealt -= OnStartingCardsDealt;
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
        {
            EventManager.FinishSetUp();
            return;
        }

        if (_tableCards != null)
        {
            for (int i = 0; i < _tableCards.Length; i++)
                Destroy(_tableCards[i]);
        }

        _tableCards = new RectTransform[boardSize];
        for (int i = 0; i < boardSize; i++)
            _tableCards[i] = Instantiate(_tableCard, _board).GetComponent<RectTransform>();

        EventManager.FinishSetUp();
    }

    /// <summary>
    /// Response to a game's StartingCardsDealt event. Sets the card sprites for all cards on the table.
    /// Does nothing if the size of the list of cards and the table cards array don't match or the list is null.
    /// </summary>
    /// <param name="cards">A list of all the cards on the table</param>
    private void OnStartingCardsDealt(List<Card> cards)
    {
        if (cards == null || cards.Count != _tableCards.Length)
            return;

        for (int i = 0; i < cards.Count; i++)
        {
            Sprite sprite = GetCardSprite(cards[i]);
            _tableCards[i].GetComponent<Image>().sprite = sprite;
            _tableCards[i].GetComponent<CardUI>().Card = cards[i];
        }
    }

    #endregion

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

    /// <summary>
    /// Retrieves sprites for all the cards from the Textures folder in Resources. 
    /// Stores these sprites into a dictionary for quick retrieval.
    /// </summary>
    /// <param name="path">The path to the sliced spritesheet containing all the card sprites</param>
    private void LoadCardSprites(string path)
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(path);

        foreach (Sprite sprite in sprites)
            _cardSprites.Add(sprite.name, sprite);
    }

    /// <summary>
    /// Fetches a card sprite from the dictionary.
    /// </summary>
    /// <param name="card">The card to retrieve a sprite of.</param>
    /// <returns>The sprite of the card, null if not found.</returns>
    public Sprite GetCardSprite(Card card)
    {
        string name = $"{card.Rank}_{card.Suit}";
        if (_cardSprites.ContainsKey(name))
            return _cardSprites[name];
        else
            return null;
    }
}