using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotScript : MonoBehaviour
{
    [SerializeField] GameObject gameTable;
    [SerializeField] private int position;
    private string[] hand;

    private void Awake()
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
        
    }

    private void Update()
    {
        if (position == gameTable.GetComponent<Game>().CurrentTurn())
        {
            //
        }
    }
}
