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

using System.Collections.Generic;

public class Elevens
{
    private Board _board;
    private List<Card> _selectedCards;
    private int _gamesPlayed;
    private int _gamesWon;

    /// <summary>
    /// Creates a new Elevens game
    /// </summary>
    public Elevens()
    {
        _gamesPlayed = 0;
        _gamesWon = 0;
        SetUp();
    }

    /// <summary>
    /// Sets up the board for a new Elevens game
    /// </summary>
    public void SetUp()
    {
        _board = new Board();
        _selectedCards = new List<Card>();
    }

    /// <summary>
    /// Adds the given card to the selected cards list
    /// </summary>
    /// <param name="card">The card to be selected</param>
    public void SelectCard(Card card) => _selectedCards.Add(card);

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

    /// <summary>
    /// Response to the player's replace request. Validates the request and 
    /// if succeeded, initiates a replace and checks if the game is won. If 
    /// the game is not won, checks for any valid moves remaining. 
    /// </summary>
    public void OnReplace()
    {

    }

    /// <summary>
    /// Response to the player's restart request. Ends the current game 
    /// as a loss and starts a new game.
    /// </summary>
    public void OnRestart()
    {

    }

    /// <summary>
    /// Response to the player winning a game. Increases the win counter.
    /// </summary>
    public void OnWin()
    {

    }

    /// <summary>
    /// Response to the player losing a game.
    /// </summary>
    public void OnLose()
    {

    }
}