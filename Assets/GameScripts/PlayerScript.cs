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
    private Card[] hand;

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
        hand = new Card[2];
        int handIndex = 0;
        Card[] cards = gameTable.GetComponent<Game>().GetCardsAvailable();
        while (handIndex < 2)
        {
            int cardIndex = (int)(Random.value * 51);
            Card card = cards[cardIndex];
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
                Debug.Log("Player " + playerName + " went...");
                gameTable.GetComponent<Game>().NextTurn();
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
        acted = false;
        Debug.Log("Player " + playerName + " went...");
        gameTable.GetComponent<Game>().NextTurn();
    }


    public void LoseChips(int chips)
    {
        this.chips -= chips;
        if (this.chips <= 0)
        {
            //end game
        }
    }

    public void GainChips(int chips)
    {
        this.chips += chips;
    }

    

    IEnumerator BotWaitAction()
    {

        int choice = (int) Random.Range(0, 3);
        yield return new WaitForSeconds(2);
    }

    public void CallOrBet()
    {


        if (bot)
        {
            
            Debug.Log("Bot called/betted");
        }
        acted = true;
    }

    public void AllIn()
    {

        if (bot)
        {
            
        }
        acted = true;
    }

    public void Raise()
    {

        if (bot)
        {
            
        }
        acted = true;
    }

    public void Fold()
    {

        if (bot)
        {
            
        }
        playing = false;
        acted = true;
        gameTable.GetComponent<Game>().DecrementPlayersLeft();
    }

    public bool IsPlaying()
    {
        return playing;
    }
}
