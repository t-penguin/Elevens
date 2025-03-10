/************************************
 *              Card                *
 ************************************
 * - _rank : Rank                   *
 * - _suit : Suit                   *
 * - _faceUp : bool                 *
 ************************************
 * + Rank : Rank                    *
 * + Suit : Suit                    *
 * + FaceUp : bool                  *
 ************************************
 * + Card(rank : Rank, suit : Suit) *
 * + FlipOver()                     *
 ************************************/

public class Card
{
    public Rank Rank { get; private set; }
    public Suit Suit { get; private set; }
    public bool FaceUp { get; private set; }

    public Card (Rank rank, Suit suit)
    {
        Rank = rank;
        Suit = suit;
        FaceUp = false;
    }

    /// <summary>
    /// Turns the card over to be face up
    /// </summary>
    public void FlipOver() => FaceUp = true;
}