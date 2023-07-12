// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Ink.Runtime;
// using System.Linq; // for List functions

// public class _InkParser : MonoBehaviour
// {
//     public TextAsset inkJSON;
//     private Story story;

//     //private string currentDialogue;
//     private bool decisionMade = false;

//     List<Card> storyCards = new List<Card>();
//     List<string> tagsCurrent = new List<string>();

//     public Card cardGameObject;
//     public GameManager gameManager;

//     // Cards

//     int orderInStory = 0;
    
//     // Start is called before the first frame update
//     void Start()
//     {
//         story = new Story(inkJSON.text);

//         // while(story.canContinue || story.currentChoices.Count > 0) // if there is more text or choices
//         // {
//         //     refreshDialogue();
//         // }
//         // PrintCardList(storyCards);
//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }

//     public Card refreshDialogue() // previously return type string (var text)
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
//                     return card;
//                 }
//                 else
//                 {
//                     card = MakeCharacterCardWOChoices(orderInStory, currentTag, text);
//                     storyCards.Add(card);
//                     if (story.currentChoices.Count > 0 && decisionMade) 
//                     {
//                         Debug.Log("THERE ARE CHOICES");
                        
//                         UpdateCharacterCardWChoices(storyCards.Last(), story.currentChoices[0].text, story.currentChoices[1].text);
//                         orderInStory++;

//                         if (gameManager.GetSwipeDirection() == "left")
//                         {
//                             Debug.Log("WENT LEFT");
//                             story.ChooseChoiceIndex(0);
//                         }
//                         else if (gameManager.GetSwipeDirection() == "right")
//                         {
//                             Debug.Log("WENT RIGHT");
//                             story.ChooseChoiceIndex(1);
//                         }
//                         else
//                         {
//                             Debug.Log("NO CHOICE CHOSEN.");
//                         }
//                     }
//                 }
//             }
//         } 
//         // else if (story.currentChoices.Count > 0) 
//         // {
//         //     Debug.Log("THERE ARE CHOICES");
            
//         //     UpdateCharacterCardWChoices(storyCards.Last(), story.currentChoices[0].text, story.currentChoices[1].text);
//         //     orderInStory++;
//         //     if (cardGameObject.Left())
//         //     {
//         //         story.ChooseChoiceIndex(0);
//         //     }
//         //     else if (cardGameObject.Right())
//         //     {
//         //         story.ChooseChoiceIndex(1);
//         //     }
//         //     else
//         //     {
//         //         Debug.Log("NO CHOICE CHOSEN.");
//         //     }
//         //     //text = story.currentChoices[0].text; // return left choice to Debug.Log
//         //     //story.ChooseChoiceIndex(0); // choose left choice to move forward
//         // }
//         return storyCards.Last();
//         //return text;
//         //return storyCards;
//     }

//     public void PrintCardList(List<Card> cardList) 
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
//     public Card MakeProseCard(int ci, string prose)
//     {
//         Card card = ScriptableObject.CreateInstance<Card>();
//         card.cardType = "Prose";
//         card.cardID = ci;
//         card.prose = prose;

//         return card;
//     }

//     // Instantiate char card
//     public Card MakeCharacterCardWOChoices(int ci, string sn, string npc)
//     {
//         Card card = ScriptableObject.CreateInstance<Card>();
//         card.cardType = "Character";
//         card.cardID = ci;
//         card.spriteName = sn;
//         card.npc_dialogue = npc;

//         return card;
//     }
    
//     public Card UpdateCharacterCardWChoices(Card card, string left, string right)
//     {
//         card.leftResponse = left;
//         card.rightResponse = right;
        
//         return card;
//     }

// }
