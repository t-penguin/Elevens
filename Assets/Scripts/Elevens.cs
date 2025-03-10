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
    /// Checks whether the cards in the selected cards list form
    /// a valid group of cards to replace. Valid cards include any
    /// pair whose values add to 11, or a Jack, Queen, King triplet.
    /// </summary>
    /// <returns>True if valid, false otherwise</returns>
    public bool ValidateReplace()
    {

    }

    /// <summary>
    /// Scans the board for a valid move. Valid moves include any
    /// pair whose values add to 11, or a Jack, Queen, King triplet.
    /// </summary>
    /// <returns>True if a valid move exists, false otherwise</returns>
    public bool ValidMoveRemaining()
    {

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