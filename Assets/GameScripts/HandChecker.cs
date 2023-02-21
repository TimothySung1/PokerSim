using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandChecker : MonoBehaviour
{
    private static Card[] cardsOnTable;
    private static Card flop1;
    private static Card flop2;
    private static Card flop3;
    private static Card turn;
    private static Card river;
    // Start is called before the first frame update
    
    public static Game.Hand GetHand(Card c1, Card c2)
    {
        cardsOnTable = Game.GetCardsOnTable();
        flop1 = cardsOnTable[0];
        flop2 = cardsOnTable[1];
        flop3 = cardsOnTable[2];
        turn = cardsOnTable[3];
        river = cardsOnTable[4];
        return Game.Hand.HighCard;
    }

    //mod card by 10 to get number, divide by ten to get suit
    //redo this
    //could make card class containing suit and number
    //also sort by rank/suit to better check for hands
    private static bool CheckPair(string c1, string c2)
    {
        return false;
    }

    private static bool CheckTwoPair(Card c1, Card c2)
    {
        return false;
    }

    private static bool CheckThreeOfAKind(Card c1, Card c2)
    {
        return false;
    }

    private static bool CheckStraight(Card c1, Card c2)
    {
        return false;
    }

    private static bool CheckFlush(Card c1, Card c2)
    {
        return false;
    }

    private static bool CheckFullHouse(Card c1, Card c2)
    {
        return false;
    }

    private static bool CheckFourOfAKind(Card c1, Card c2)
    {
        return false;
    }

    private static bool CheckStraightFlush(Card c1, Card c2)
    {
        return CheckFlush(c1, c2) && CheckStraight(c1, c2);
    }

    private static bool CheckRoyalFlush(Card c1, Card c2)
    {
        //return check straight flush and if the ace is there
        return false;
    }
}
