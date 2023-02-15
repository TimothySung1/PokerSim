using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

public class Game : MonoBehaviour
{
    private int numPlayers;
    [SerializeField] private GameObject[] players;
    private int cur;
    private int playersLeft;
    private State curState = State.Waiting;
    private static string[] cardsAvailable = new string[52];
    //each string is formatted [suit][num]
    //spade = 0, heart = 1, club = 2, diamond = 3
    //ace = 1, ..., king = 13
    //use Circular Array to implement small and big blinds as well

    private enum State
    {
        Waiting,
        Done
    }


    private void Start()
    {
        newGame();
    }

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
    }

    private void showNewGameButton()
    {
        //also show quit button
    }

    private void newGame()
    {
        Debug.Log("New game");
        curState = State.Done;
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
        bool gameOver = false;

        //game logic
        
    }

    public void NextTurn()
    {
        cur = (cur + 1) % players.Length;
    }

    public void FinishState()
    {
        curState = State.Done;
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

    public void IncrementCur()
    {
        cur = (cur + 1) % numPlayers;
    }

    public string[] GetCardsAvailable()
    {
        return cardsAvailable;
    }

    public void DecrementPlayersLeft()
    {
        playersLeft--;
    }
}
