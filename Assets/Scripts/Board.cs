/*****************************************************************
 *                           Board                               *
 *****************************************************************
 * - _deck : Deck                                                *
 * - _tableCards : List<Card>                                    *
 *****************************************************************
 * + Deck : Deck                                                 *
 * + TableCards : List<Card>                                     *
 *****************************************************************
 * + Board()                                                     *
 * + ReplaceCards(index1 : int, index2 : int, index3 : int = -1) *
 *****************************************************************/

using System.Collections.Generic;

public class Board
{
    public Deck Deck { get; private set; }
    public List<Card> TableCards { get; private set; }

    public Board()
    {

    }

    /// <summary>
    /// Removes two or three cards from the table and 
    /// replaces them with cards from the deck if possible
    /// </summary>
    /// <param name="index1">The table index of the first card to replace</param>
    /// <param name="index2">The table index of the second card to replace</param>
    /// <param name="index3">[Optional] The table index of the third card to replace</param>
    public void ReplaceCards(int index1, int index2, int index3 = -1)
    {

    }
}