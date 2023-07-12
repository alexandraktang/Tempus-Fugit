// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;
// using System; // for Enum functions
// using System.Linq; // for List functions

// public class GameManager : MonoBehaviour
// {
//     [Header("Game Objects")]
//     // Game objects
//     public GameObject cardGameObject;
//     public CardController mainCardController;
//     public SpriteRenderer cardSpriteRenderer;
//     public ResourceManager resourceManager;
//     public InkParser inkParser;
//     private List<Card> storyList;
    
//     [Header("Movement Variables")]
//     // Movement variables
//     public float fMovingSpeed = 1.2f;
//     public float fSideMargin = 0.5f;
//     public float fSideTrigger = 2f; // checks if you're actually doing anything
//     private Vector3 pos;
    
//     [Header("Game Objects & Text")]
//     // Dialogue variables
//     public TMP_Text debugText;
//     public GameObject proseBackground;
//     public GameObject proseTextObject;
//     public TMP_Text proseText;
//     public GameObject npc_dialogueObject;
//     public TMP_Text npc_dialogue;
//     public GameObject responseObject;
//     public TMP_Text response;
//     public GameObject spriteObject;

//     [Header("Text Variables")]
//     public Color textColor;
//     public float divideValue = 3f;
//     private float alphaText;

//     // Card variables
//     private string leftResponse;
//     private string rightResponse;

//     // Iteration variables
//     private int iteratorForStoryList = 0;

//     // Start is called before the first frame update
//     void Start()
//     {
//         storyList = inkParser.GetCardList();
//         LoadCard(storyList.First());
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // Dialogue text handling
//         textColor.a = Mathf.Min(Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin / divideValue, 1); // text transparency
        

//         if (cardGameObject.transform.position.x > fSideTrigger) // if past the trigger point (furthest right)
//         {
//             if (Input.GetMouseButtonUp(0)) // if mouse button is released, call function
//             {
//                 Debug.Log("You swiped right.");
//                 LoadCard(storyList[iteratorForStoryList+1]);
//                 iteratorForStoryList = iteratorForStoryList + 1;
//                 if (iteratorForStoryList >= storyList.Count - 1) 
//                 {
//                     Debug.Log("iterator is greater than cards available");
//                     iteratorForStoryList = -1; // LoadCard starts at iteratorForStoryList +1
//                 }
//             }
//         }
//         else if (cardGameObject.transform.position.x > fSideMargin)
//         {
//             // do nothing if trigger is not activated
//         }
//         else if (cardGameObject.transform.position.x > -fSideMargin)
//         {
//             textColor.a = 0; // if in the center, do not display any text
//         }
//         else if (cardGameObject.transform.position.x > -fSideTrigger)
//         {
//             // do nothing if trigger is not activated
//         }
//         else // if past the trigger point (furthest left)
//         {
//             if (Input.GetMouseButtonUp(0)) // if mouse button is released, call function
//             {
//                 Debug.Log("You swiped left.");
//                 LoadCard(storyList[iteratorForStoryList+1]);
//                 iteratorForStoryList = iteratorForStoryList + 1;
//                 if (iteratorForStoryList >= storyList.Count - 1) 
//                 {
//                     Debug.Log("iterator is greater than cards available");
//                     iteratorForStoryList = -1;
//                 }
//             }
//         }
//         UpdateResponse();

//         // Movement
//         if (Input.GetMouseButton(0) && mainCardController.isMouseOver) {
//             Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//             cardGameObject.transform.position = pos;
//         }
//         else 
//         {
//             cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, new Vector2(0,0), fMovingSpeed);
//         }

//         // UI
//         debugText.text = "" + textColor.a;
        
//     }

//     public void LoadCard(Card card)
//     {
//         if (card.cardType == "Prose")
//         {
//             proseText.text = card.prose;

//             // set Character elements inactive
//             npc_dialogueObject.SetActive(false);
//             responseObject.SetActive(false);
//             spriteObject.SetActive(false);

//             // set Prose elements active
//             proseBackground.SetActive(true);
//             proseTextObject.SetActive(true);
//         }
//         else if (card.cardType == "Character")
//         {
//             Debug.Log("LOAD CARD IS CHAR.");
//             AssignSprite(card, card.spriteName);
//             npc_dialogue.text = card.npc_dialogue;
//             leftResponse = card.leftResponse;
//             rightResponse = card.rightResponse;

//             // set Prose elements inactive
//             proseBackground.SetActive(false);
//             proseTextObject.SetActive(false);

//             // set Character elements active
//             npc_dialogueObject.SetActive(true);
//             responseObject.SetActive(true);
//             spriteObject.SetActive(true);
//         }
//     }

//     private void AssignSprite(Card card, string spriteName) 
//     {
//         int counter = 0;
//         foreach(string name in Enum.GetNames(typeof(CardSprite))) {
//             Debug.Log("Sprite name[" + counter + "]: " + name);
//             if (name == spriteName) 
//             {
//                 Debug.Log("name = spriteName\n name: " + name + " spriteName: " + spriteName + "\n counter: " + counter);
//                 cardSpriteRenderer.sprite = resourceManager.sprites[counter];
//                 return;
//             }
//             else 
//             {
//                 counter++;
//             }
//         }
//     }

//     private void UpdateResponse() 
//     {
//         response.color = textColor;
//         if (cardGameObject.transform.position.x < 0) 
//         {
//             response.text = leftResponse;
//         }
//         else 
//         {
//             response.text = rightResponse;
//         }
//     }

// }
