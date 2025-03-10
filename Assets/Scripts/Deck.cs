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

using System;
using System.Collections.Generic;

public class Deck
{
    public List<Card> Cards { get; private set; }

    /// <summary>
    /// Creates an unshuffled standard deck of 52 playing cards
    /// </summary>
    public Deck()
    {
        Cards = new List<Card>(52);
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                Cards.Add(new Card(rank, suit));
    }

    /// <summary>
    /// Randomly shuffles the deck
    /// </summary>
    public void Shuffle()
    {
        Random rand = new Random();
        for (int i = 0; i < Cards.Count; i++)
        {
            int r = rand.Next(i, Cards.Count);
            Card temp = Cards[i];
            Cards[i] = Cards[r];
            Cards[r] = temp;
        }
    }

    /// <summary>
    /// Cuts the deck at the specified index and swaps the two sections
    /// </summary>
    /// <param name="index">The index to perform the cut at. Range: [1, Cards.Count - 1)</param>
    public void Cut(int index)
    {
        if (index <= 0 || index >= Cards.Count - 1)
            return;

        // This can be done better, but the list is small so it's fine for now
        List<Card> temp = Cards.GetRange(0, index + 1);
        Cards.RemoveRange(0, index + 1);
        Cards.AddRange(temp);
    }

    /// <summary>
    /// Takes the top card of the deck
    /// </summary>
    /// <returns>The first card in the deck list</returns>
    public Card TakeTopCard()
    {
        if (Cards.Count == 0) 
            return null;

        Card topCard = Cards[0];
        Cards.RemoveAt(0);
        return topCard;
    }
}