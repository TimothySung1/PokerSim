using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    private Suit suit;
    private int value;

    public Card(Suit suit, int value)
    {
        this.value = value;
        this.suit = suit;
    }

    public override string ToString()
    {
        string num = "";
        if (value >= 2 && value <= 10)
        {
            num = "" + value;
        } else
        {
            switch(value)
            {
                case 1:
                    num = "Ace";
                    break;
                case 11:
                    num = "Jack";
                    break;
                case 12:
                    num = "Queen";
                    break;
                case 13:
                    num = "King";
                    break;
                default:
                    Debug.Log("Card value invalid?");
                    break;
            }
        }
        return num + " of " + suit + "s";
    }

    public Suit GetSuit() { return suit; }
    public int GetValue() { return value; }
}

public enum Suit
{
    Spade = 0, Heart = 1, Club = 2, Diamond = 3
}
