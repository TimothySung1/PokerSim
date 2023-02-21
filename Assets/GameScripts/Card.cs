using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Card
{
    private Suit suit;
    private int value;

    public Card(Suit suit, int value)
    {
        this.suit = suit;
        this.value = value;
    }

    public Card()
    {
        this.suit = 0;
        this.value = 0;
    }

    public int GetValue()
    {
        return value;
    }

    public Suit GetSuit()
    {
        return suit;
    }

    public override string ToString()
    {
        return value + " of " + suit + "s";
    }
}

public enum Suit
{
    Spade, Heart, Club, Diamond
}
