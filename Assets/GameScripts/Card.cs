using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private Suit suit;
    private int value;

    public Card(Suit suit, int value)
    {
        this.suit = suit;
        this.value = value;
    }

    public int GetValue()
    {
        return value;
    }

    public Suit GetSuit()
    {
        return suit;
    }


}

public enum Suit
{
    Spade, Heart, Club, Diamond
}
