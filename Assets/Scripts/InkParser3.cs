using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.Linq; // for List functions

public class InkParser3 : MonoBehaviour
{
    //public TextAsset inkJSON;
    public Story story;
    public bool waitingForChoice = false;
    public string swipeDirection = "";

    List<string> tagsCurrent = new List<string>();

    public bool storyOver = false;
    int orderInStory = 0;
    
    // Start is called before the first frame update
    public void Start()
    {
        //story = new Story(inkJSON.text);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Card refreshDialogue() // previously return type string (var text)
    {
        string text = "";
        Card card = ScriptableObject.CreateInstance<Card>();

        if (story.canContinue) {
            text = story.Continue();
            tagsCurrent = story.currentTags;
            Debug.Log("RefreshDialogue Text is: " + text);
            Debug.Log(tagsCurrent.Last());
            if (tagsCurrent.Count > 0)
            {
                string currentTag = tagsCurrent.Last(); // should only be one in list
                if (currentTag == "Prose") {
                    card = MakeProseCard(card, orderInStory, text);
                    Debug.Log(card.CardToString(card));
                    orderInStory++;
                }
                else
                {
                    card = MakeCharacterCardWOChoices(card, orderInStory, currentTag, text);
                    Debug.Log(card.CardToString(card));

                    // MAKE CHOICE
                    if (story.currentChoices.Count > 0) 
                    {
                        Debug.Log("THERE ARE CHOICES");
                        
                        UpdateCharacterCardWChoices(card, story.currentChoices[0].text, story.currentChoices[1].text);
                        Debug.Log(card.CardToString(card));
                        orderInStory++;

                        waitingForChoice = true;
                    }
                    else
                    {
                        orderInStory++;
                    }
                }
            }
        }
        else if (story.currentChoices.Count > 0)
        {
            MakeDecision();
        }
        else
        {
            storyOver = true;
            orderInStory = 0;
        }

        return card; // make sure LoadCard checks if card is null
    }

    private void PrintCardList(List<Card> cardList) 
    {
        foreach(Card item in cardList) 
        {
            Debug.Log(item.CardToString(item));
        }
    }

    // Instantiate char card
    private Card MakeProseCard(Card card, int ci, string prose)
    {
        card.cardType = "Prose";
        card.cardID = ci;
        card.prose = prose;

        return card;
    }

    // Instantiate char card
    private Card MakeCharacterCardWOChoices(Card card, int ci, string sn, string npc)
    {
        card.cardType = "Character";
        card.cardID = ci;
        card.spriteName = sn;
        card.npc_dialogue = npc;

        return card;
    }
    
    private Card UpdateCharacterCardWChoices(Card card, string left, string right)
    {
        card.leftResponse = left;
        card.rightResponse = right;
        
        return card;
    }

    public void MakeDecision()
    {
        if (swipeDirection == "left") {
            Debug.Log("Player swiped left!");
            story.ChooseChoiceIndex(0); // choose left choice to move forward
            swipeDirection = "";
        }
        else if (swipeDirection == "right")
        {
            Debug.Log("Player swiped right!");
            story.ChooseChoiceIndex(1); // choose left choice to move forward
            swipeDirection = "";
        }
    }
}
