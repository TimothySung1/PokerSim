using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private int players;
    private bool[] inPlay;
    private int cur;
    private string[] cardsAvailable;
    //each string is formatted [suit][num]
    //spade = 0, heart = 1, club = 2, diamond = 3
    //ace = 1, ..., king = 13
    //use Circular Array to implement small and big blinds as well

    private void Awake()
    {
        if (players == 0)
        {
            return;
        }
        inPlay = new bool[players];
        for (int i = 0; i < players; i++)
        {
            inPlay[i] = true;
        }
        cur = 0;
        cardsAvailable = new string[52];
        ResetCards();
    }
    
    private void ResetCards()
    {
        int cardIndex = 0;
        for (int i = 0; i < 4; i++)
        {
            int j = 1;
            while (j < 14)
            {
                StringBuilder cardBuilder = new StringBuilder();
                cardBuilder.Append(i.ToString());
                cardBuilder.Append(j.ToString());
                cardsAvailable[cardIndex] = cardBuilder.ToString();
                cardIndex++;
                j++;
            }
        }
    }

    public int CurrentTurn()
    {
        return cur;
    }

    public void NextTurn()
    {
        cur = (cur + 1) % players;
    }

    public string[] GetCardsAvailable()
    {
        return cardsAvailable;
    }
}
