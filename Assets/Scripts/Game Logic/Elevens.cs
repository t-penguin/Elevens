/************************************
 *            Elevens               *
 ************************************
 * - _board : Board                 *
 * - _selectedCards : List<Card>    *
 * - _gamesPlayed : int             *
 * - _gamesWon : int                *
 ************************************
 *                                  *
 ************************************
 * + Elevens()                      *
 * + SetUp()                        *
 * + SelectCard(card : Card)        *
 * + DeselectCard(card : Card)      *
 * + ValidateReplace() : bool       *
 * + ValidMoveRemaining() : bool    *
 * + OnReplace()                    *
 * + OnRestart()                    *
 * + OnWin()                        *
 * + OnLose()                       *
 ************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

public class Elevens : MonoBehaviour
{
    private Board _board;
    private List<Card> _selectedCards;
    private int _gamesPlayed;
    private int _gamesWon;

    private bool _moveMade;
    private bool _gameEnded;

    private const int BOARD_SIZE = 9;

    #region Monobehaviour Callbacks

    private void Start()
    {
        _gamesPlayed = 0;
        _gamesWon = 0;
    }

    private void OnEnable()
    {
        EventManager.GameStarting += OnStartGame;
        EventManager.GameSetUp += OnFinishSetUp;
        EventManager.ClickedCard += OnClickedCard;
    }

    private void OnDisable()
    {
        EventManager.GameStarting -= OnStartGame;
        EventManager.GameSetUp -= OnFinishSetUp;
        EventManager.ClickedCard -= OnClickedCard;
    }

    #endregion

    #region Event Callbacks

    private void OnStartGame()
    {
        if (_moveMade)
            OnRestart();
        else
            SetUp();
    }

    private void OnFinishSetUp() => FillTable();
    private void OnClickedCard(Card card, bool selected)
    {
        if (selected)
            SelectCard(card);
        else
            DeselectCard(card);
    }

    /// <summary>
    /// Response to the player's replace request. Validates the request and 
    /// if succeeded, initiates a replace and checks if the game is won. If 
    /// the game is not won, checks for any valid moves remaining. 
    /// </summary>
    public void OnReplace()
    {
        if (!ValidateReplace()) 
            return;

        if (!_moveMade)
            _moveMade = true;

        int numCards = _selectedCards.Count;

        List<int> indexes = new List<int>(numCards);
        foreach (Card card in _selectedCards)
            indexes.Add(Array.IndexOf(_board.TableCards, card));

        _selectedCards.Clear();
        _board.ReplaceCards(indexes);
        EventManager.ReplaceCards(_board.TableCards, indexes);

        if (_board.IsEmpty())
        {
            OnWin();
            EventManager.Win();
            return;
        }

        if (ValidMoveRemaining())
            return;

        OnLose();
        EventManager.Lose();
    }

    /// <summary>
    /// Response to the player's restart request. Ends the current game 
    /// as a loss and starts a new game.
    /// </summary>
    public void OnRestart()
    {
        if (!_gameEnded)
            OnLose();

        SetUp();
    }

    /// <summary>
    /// Response to the player winning a game. Increases the win counter.
    /// </summary>
    public void OnWin()
    {
        _gameEnded = true;
        _gamesWon++;
        _gamesPlayed++;
        EventManager.UpdateInfo(_gamesWon, _gamesPlayed);
    }

    /// <summary>
    /// Response to the player losing a game.
    /// </summary>
    public void OnLose()
    {
        _gameEnded = true;
        _gamesPlayed++;
        EventManager.UpdateInfo(_gamesWon, _gamesPlayed);
    }

    #endregion

    /// <summary>
    /// Sets up the board for a new Elevens game
    /// </summary>
    public void SetUp()
    {
        _board = new Board(BOARD_SIZE);
        _selectedCards = new List<Card>();
        _moveMade = false;
        _gameEnded = false;
        EventManager.SetUpGame(BOARD_SIZE);
    }

    private void FillTable()
    {
        bool validStart = false;
        while (!validStart)
        {
            _board.DealStartingCards();
            validStart = ValidMoveRemaining();
        }

        EventManager.DealtStartingCards(_board.TableCards);
    }

    /// <summary>
    /// Adds the given card to the selected cards list
    /// </summary>
    /// <param name="card">The card to be selected</param>
    public void SelectCard(Card card)
    {
        if (_selectedCards.Contains(card))
            return;

        _selectedCards.Add(card);
    }

    /// <summary>
    /// Removes the given card from the selected cards list
    /// </summary>
    /// <param name="card">The card to be selected</param>
    public void DeselectCard(Card card) => _selectedCards.Remove(card);

    /// <summary>
    /// Checks whether the cards in the selected cards list form
    /// a valid group of cards to replace. Valid cards include any
    /// pair whose values add to 11, or a Jack, Queen, King triplet.
    /// </summary>
    /// <returns>True if valid, false otherwise</returns>
    public bool ValidateReplace()
    {
        switch (_selectedCards.Count)
        {
            default:
                return false;
            case 2:
                int total = 0;
                foreach (Card card in _selectedCards)
                    total += (int)card.Rank;

                return total == 11;
            case 3:
                bool hasJack = false;
                bool hasQueen = false;
                bool hasKing = false;
                foreach (Card card in _selectedCards)
                {
                    if (card.Rank == Rank.Jack)
                        hasJack = true;
                    if (card.Rank == Rank.Queen)
                        hasQueen = true;
                    if (card.Rank == Rank.King)
                        hasKing = true;
                }
                return hasJack && hasQueen && hasKing;
        }
    }

    /// <summary>
    /// Scans the board for a valid move. Valid moves include any
    /// pair whose values add to 11, or a Jack, Queen, King triplet.
    /// </summary>
    /// <returns>True if a valid move exists, false otherwise</returns>
    public bool ValidMoveRemaining()
    {
        foreach (Card card in _board.TableCards)
        {
            if (card == null)
                continue;

            Rank pairRank;
            switch (card.Rank)
            {
                default: continue;
                case Rank.Ace:
                    pairRank = Rank.Ten;
                    break;
                case Rank.Two:
                    pairRank = Rank.Nine;
                    break;
                case Rank.Three:
                    pairRank = Rank.Eight;
                    break;
                case Rank.Four:
                    pairRank = Rank.Seven;
                    break;
                case Rank.Five:
                    pairRank = Rank.Six;
                    break;
                case Rank.Jack:
                    if(_board.ContainsRank(card, Rank.Queen) && _board.ContainsRank(card, Rank.King))
                        return true;
                    continue;
            }

            if (_board.ContainsRank(card, pairRank))
                return true;
        }

        return false;
    }
}