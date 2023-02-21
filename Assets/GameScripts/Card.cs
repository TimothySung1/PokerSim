using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    Suit suit;
    int value;

    public Card(Suit suit, int value)
    {
        this.value = value;
        this.suit = suit;
    }

    public override string ToString()
    {
        return value + " of " + suit + "s";
    }
}

public enum Suit
{
    Spade = 0, Heart = 1, Club = 2, Diamond = 3
}
