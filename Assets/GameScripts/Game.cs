using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

public class Game : MonoBehaviour
{

    public enum Hand
    {
        HighCard, Pair, TwoPair, ThreeOfAKind, Straight,
        Flush, FullHouse, FourOfAKind, StraightFlush,
        RoyalFlush
    }

    private int numPlayers;
    [SerializeField] private GameObject[] players;
    private int cur;
    private int playersLeft;
    //private State curState = State.Waiting;
    private static Card[] cardsAvailable = new Card[52];
    private static Card[] cardsOnTable = new Card[5];
    //each string is formatted [suit][num]
    //spade = 0, heart = 1, club = 2, diamond = 3
    //ace = 1, ..., king = 13
    //use Circular Array to implement small and big blinds as well

    /*
    private enum State
    {
        Waiting,
        Done
    }
    */

    public static Card[] GetCardsOnTable()
    {
        return cardsOnTable;
    }
    private void Start()
    {
        newGame();
    }
    /*
    private void Update()
    {
        if (curState == State.Done)
        {
            curState = State.Waiting;
            PlayerScript curPlayer = players[cur].GetComponent<PlayerScript>();
            int count = 0;
            while (!curPlayer.IsPlaying())
            {
                if (count > numPlayers)
                {
                    // Game over, display whoever is playing as the winner
                    //press button for new game, if button pressed, new Game
                    //set all players to playing for next deal
                    showNewGameButton();
                    newGame();
                    return;
                }
                IncrementCur();
                curPlayer = players[cur].GetComponent<PlayerScript>();
            }
            Debug.Log("Current player goes...");
            curPlayer.Go();
            Debug.Log("Current player went...");
            
            
        }
    } */

    private void showNewGameButton()
    {
        //also show quit button
        print("game over");
    }

    private void newGame()
    {
        Debug.Log("New game");
        //curState = State.Done;
        ResetCards();
        numPlayers = players.Length;
        playersLeft = players.Length;
        if (numPlayers == 0)
        {
            return;
        }
        cur = 0;
        foreach (GameObject player in players)
        {
            player.GetComponent<PlayerScript>().InitializePlayer();
        }
        PlayerScript firstPlayer = players[0].GetComponent<PlayerScript>();
        firstPlayer.Go();
    }

    public void NextTurn()
    {
        IncrementCur();
        //FinishState();
        if (playersLeft <= 1)
        {
            showNewGameButton();
            return;
        }
        //curState = State.Waiting;
        PlayerScript curPlayer = players[cur].GetComponent<PlayerScript>();
        for (int i = 0; i < numPlayers; i++)
        {
            if (curPlayer.IsPlaying())
            {
                break;
            }
            IncrementCur();
            curPlayer = players[cur].GetComponent<PlayerScript>();
        }
        curPlayer.Go();
    }

    /*
    public void FinishState()
    {
        curState = State.Done;
    }
    */

    private void ResetCards()
    {
        int cardIndex = 0;
        for (int i = 0; i < 4; i++)
        {
            Suit suit = (Suit)i;
            int j = 1;
            while (j < 14)
            {
                Card card = new Card(suit, j);
                cardsAvailable[cardIndex] = card;
                cardIndex++;
                j++;
            }
        }
    }

    public int CurrentTurn()
    {
        return cur;
    }

    public void IncrementCur()
    {
        cur = (cur + 1) % numPlayers;
    }

    public Card[] GetCardsAvailable()
    {
        return cardsAvailable;
    }

    public void DecrementPlayersLeft()
    {
        playersLeft--;
    }
}
