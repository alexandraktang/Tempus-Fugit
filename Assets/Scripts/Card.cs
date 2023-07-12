using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class Card : ScriptableObject
{
    public string cardType;
    public int cardID;

    // Prose Card var
    public string prose;

    // Character Card var
    public string spriteName;
    public string npc_dialogue;
    public string leftResponse = "";
    public string rightResponse = "";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Card Type
    public string GetCardType(Card card) 
    {
        return card.cardType;
    }
    
    public void SetCardType(Card card, string ct) 
    {
        card.cardType = ct;
    }

    // Card ID
    public int GetCardID(Card card) 
    {
        return card.cardID;
    }
    
    public void SetCardID(Card card, int ci) {

        card.cardID = ci;
    }

    public string CardToString(Card card) 
    {
        string text = "";
        text = text + "cardType = " + card.cardType + "\n";
        text = text + "cardID = " + card.cardID + "\n";

        if (card.cardType == "Prose")
        {
            text = text + "prose = " + card.prose;
            text = text +  "spriteName = " + card.spriteName + "\n"; // set to none for prose
        }
        else
        {
            text = text +  "spriteName = " + card.spriteName + "\n";
            text = text +  "npc_dialogue = " + card.npc_dialogue + "\n";
            text = text + "leftResponse = " + card.leftResponse + "\n";
            text = text + "rightResponse = " + card.rightResponse;
        }
        return text;
    }

    public bool Left() 
    {
        Debug.Log("You swiped left.");
        return true;
    }
    
    public bool Right()
    {
        Debug.Log("You swiped right.");
        return true;
    }

}
