/*****************************************************************
 *                           Board                               *
 *****************************************************************
 * - _deck : Deck                                                *
 * - _tableCards : List<Card>                                    *
 *****************************************************************
 * + Deck : Deck                                                 *
 * + TableCards : List<Card>                                     *
 *****************************************************************
 * + Board(size : int)                                           *
 * + ReplaceCards(index1 : int, index2 : int, index3 : int = -1) *
 * + ContainsRank(card : Card, rank : Rank)                      *
 *****************************************************************/

using System;
using System.Collections.Generic;

public class Board
{
    public Deck Deck { get; private set; }
    public Card[] TableCards { get; private set; }

    private int _size;

    public Board(int size)
    {
        _size = size;
        Deck = new Deck();
        Deck.Shuffle();
        TableCards = new Card[size];
    }

    public void DealStartingCards()
    {
        for (int i = 0; i < _size; i++)
            TableCards[i] = Deck.TakeTopCard();
    }

    /// <summary>
    /// Removes two or three cards from the table and 
    /// replaces them with cards from the deck if possible
    /// </summary>
    /// <param name="indexes">A list of cards to be replaced by their index in the table cards array</param>
    public void ReplaceCards(List<int> indexes)
    {
        // Index out of bounds checks
        foreach (int index in indexes)
            if (index < 0 || index >= TableCards.Length)
                return;

        // Replace cards on the table
        foreach (int index in indexes)
            TableCards[index] = Deck.TakeTopCard();
    }

    /// <summary>
    /// Checks if the board contains a card with the specified rank
    /// </summary>
    /// <param name="card">The card to skip</param>
    /// <param name="rank">The rank to search for</param>
    /// <returns></returns>
    public bool ContainsRank(Card card, Rank rank)
    {
        foreach (Card tableCard in TableCards)
        {
            if (tableCard == card)
                continue;

            if (tableCard.Rank == rank)
                return true;
        }

        return false;
    }
}