// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Ink.Runtime;
// using System.Linq; // for List functions

// public class InkParser : MonoBehaviour
// {
//     public TextAsset inkJSON;
//     private Story story;

//     //private string currentDialogue;
//     private bool decisionMade = false;

//     List<Card> storyCards = new List<Card>();
//     List<string> tagsCurrent = new List<string>();

//     // Cards

//     int orderInStory = 0;
    
//     // Start is called before the first frame update
//     void Start()
//     {
//         story = new Story(inkJSON.text);

//         while(story.canContinue || story.currentChoices.Count > 0) // if there is more text or choices
//         {
//             refreshDialogue();
//         }
//         PrintCardList(storyCards);
//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }

//     public List<Card> refreshDialogue() // previously return type string (var text)
//     {
//         string text = "";
         
//         if (story.canContinue) {
//             Card card;
//             text = story.Continue();
//             tagsCurrent = story.currentTags;
//             Debug.Log("RefreshDialogue Text is: " + text);
//             if (tagsCurrent.Count > 0)
//             {
//                 string currentTag = tagsCurrent.Last(); // should only be one in list
//                 if (currentTag == "Prose") {
//                     card = MakeProseCard(orderInStory, text);
//                     storyCards.Add(card);
//                     orderInStory++;
//                 }
//                 else
//                 {
//                     card = MakeCharacterCardWOChoices(orderInStory, currentTag, text);
//                     storyCards.Add(card);


//                     // MAKE CHOICE
//                     if (story.currentChoices.Count > 0) 
//                     {
//                         Debug.Log("THERE ARE CHOICES");
            
//                         UpdateCharacterCardWChoices(storyCards.Last(), story.currentChoices[0].text, story.currentChoices[1].text);
//                         orderInStory++;
                        
//                         text = story.currentChoices[0].text; // return left choice to Debug.Log
//                         story.ChooseChoiceIndex(0); // choose left choice to move forward
//                     }
                    
//                 }
//             }
//         } 

        
//         //return text;
//         return storyCards;
//     }

//     private void PrintCardList(List<Card> cardList) 
//     {
//         foreach(Card item in cardList) 
//         {
//             Debug.Log(item.CardToString(item));
//         }
//     }

//     public List<Card> GetCardList() 
//     {
//         return storyCards;
//     }

//     // Instantiate char card
//     private Card MakeProseCard(int ci, string prose)
//     {
//         Card card = ScriptableObject.CreateInstance<Card>();
//         card.cardType = "Prose";
//         card.cardID = ci;
//         card.prose = prose;

//         return card;
//     }

//     // Instantiate char card
//     private Card MakeCharacterCardWOChoices(int ci, string sn, string npc)
//     {
//         Card card = ScriptableObject.CreateInstance<Card>();
//         card.cardType = "Character";
//         card.cardID = ci;
//         card.spriteName = sn;
//         card.npc_dialogue = npc;

//         return card;
//     }
    
//     private Card UpdateCharacterCardWChoices(Card card, string left, string right)
//     {
//         card.leftResponse = left;
//         card.rightResponse = right;
        
//         return card;
//     }
// }
