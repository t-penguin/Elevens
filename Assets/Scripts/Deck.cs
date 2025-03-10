/************************************
 *              Deck                *
 ************************************
 * - _cards : List<Card>            *
 ************************************
 * + Cards : List<Card>             *
 ************************************
 * + Deck()                         *
 * + Shuffle()                      *
 * + Cut(index : int)               *
 * + TakeTopCard() : Card           *
 ************************************/

using System.Collections.Generic;

public class Deck
{
    public List<Card> Cards { get; private set; }

    /// <summary>
    /// Creates an unshuffled standard deck of 52 playing cards
    /// </summary>
    public Deck()
    {

    }

    /// <summary>
    /// Randomly shuffles the deck
    /// </summary>
    public void Shuffle()
    {

    }

    /// <summary>
    /// Cuts the deck at the specified index and swaps the two sections
    /// </summary>
    /// <param name="index">The index to perform the cut at. Range: [0, 52)</param>
    public void Cut(int index)
    {

    }

    /// <summary>
    /// Takes the top card of the deck
    /// </summary>
    /// <returns>The first card in the deck list</returns>
    public Card TakeTopCard()
    {

    }
}