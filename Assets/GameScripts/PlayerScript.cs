using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.Experimental.RestService;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] GameObject gameTable;
    [SerializeField] private bool bot = true;
    [SerializeField] private int chips = 500;
    [SerializeField] TMP_Text textBox;
    [SerializeField] Button callButton;
    [SerializeField] Button raiseButton;
    [SerializeField] Button foldButton;
    private bool playing = true;
    private bool acted = false;
    private string[] hand;

    private void Awake()
    {
        if (!bot)
        {
            callButton.interactable = false;
            raiseButton.interactable = false;
            foldButton.interactable = false;
            callButton.onClick.AddListener(CallOrBet);
            raiseButton.onClick.AddListener(Raise);
            foldButton.onClick.AddListener(Fold);
        }
        
    }

    public void InitializePlayer()
    {
        hand = new string[2];
        int handIndex = 0;
        string[] cards = gameTable.GetComponent<Game>().GetCardsAvailable();
        while (handIndex < 2)
        {
            int cardIndex = (int)(Random.value * 51);
            string card = cards[cardIndex];
            if (card != null)
            {
                hand[handIndex] = card;
                cards[cardIndex] = null;
                handIndex++;
            }
        }
        textBox.text = hand[0] + " " + hand[1];
        playing = true;
    }

    public void Go()
    {
        //do whatever, then disable itself, then enable the next player
        if (playing)
        {
            Debug.Log("Player " + playerName + " goes...");
            if (bot)
            {
                CallOrBet();
            } else
            {
                
                //enable buttons
                callButton.interactable = true;
                raiseButton.interactable = true;
                foldButton.interactable = true;
                //wait for input
                StartCoroutine("WaitForAction");
                //disable buttons after
                
                
                
                
               
            }
            Debug.Log("Player " + playerName + " went...");
        }
    }


    public IEnumerator WaitForAction()
    {
        acted = false;
        while (!acted)
        {
            yield return null;
        }
        Debug.Log("User Action");
        callButton.interactable = false;
        raiseButton.interactable = false;
        foldButton.interactable = false;
        NextTurn();
    }

    private void NextTurn()
    {
        gameTable.GetComponent<Game>().FinishState();
        gameTable.GetComponent<Game>().IncrementCur();
    }

    public void ChangeChips(int chips, bool lose)
    {
        if (lose)
        {
            this.chips -= chips;
            if (chips < 0)
            {
                //exit the game, option to rebuy
            }
        } else
        {
            this.chips += chips;
        }
    }

    public void CallOrBet()
    {


        if (bot)
        {
            NextTurn();
        }
        acted = true;
    }

    public void AllIn()
    {

        if (bot)
        {
            NextTurn();
        }
        acted = true;
    }

    public void Raise()
    {

        if (bot)
        {
            NextTurn();
        }
        acted = true;
    }

    public void Fold()
    {

        if (bot)
        {
            NextTurn();
        }
        playing = false;
        acted = true;
    }

    public bool IsPlaying()
    {
        return playing;
    }
}
