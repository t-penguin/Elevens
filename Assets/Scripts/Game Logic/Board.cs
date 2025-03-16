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
    /// <param name="index1">The table index of the first card to replace</param>
    /// <param name="index2">The table index of the second card to replace</param>
    /// <param name="index3">[Optional] The table index of the third card to replace</param>
    public void ReplaceCards(int index1, int index2, int index3 = -1)
    {
        // Index out of bounds checks
        bool index1oob = index1 < 0 || index1 >= TableCards.Length;
        bool index2oob = index2 < 0 || index2 >= TableCards.Length;
        bool index3oob = index3 >= TableCards.Length;
        if (index1oob || index2oob || index3oob)
            return;

        bool triplet = index3 < 0;

        // Replace cards on the table
        TableCards[index1] = Deck.TakeTopCard();
        TableCards[index2] = Deck.TakeTopCard();
        if (triplet) 
            TableCards[index3] = Deck.TakeTopCard();
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