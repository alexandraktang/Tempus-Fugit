using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System; // for Enum functions
using System.Linq; // for List functions
using Ink.Runtime;

public class GameManager2 : MonoBehaviour
{
    [Header("Game Objects")]
    // Game objects
    public GameObject cardGameObject;
    public CardController mainCardController;
    public SpriteRenderer cardSpriteRenderer;
    public ResourceManager resourceManager;
    public InkParser3 inkParser;
    private List<Card> storyList;
    public AnimationController animationController;
    
    [Header("Movement Variables")]
    // Movement variables
    private float fSideMargin = 0.5f;
    public float fSideTrigger = 2f; // checks if you're actually doing anything
    private Vector3 pos;
    
    [Header("Game & Text Objects")]
    // Dialogue variables
    public TMP_Text debugText;
    public GameObject proseBackground;
    public GameObject proseTextObject;
    public TMP_Text proseText;
    public GameObject npc_dialogueObject;
    public TMP_Text npc_dialogue;
    public SpriteRenderer responseBackgroundSpriteRenderer;
    public Color responseBackgroundColor;
    public Color responseBackgroundColorFullTransparent;
    public GameObject responseObject;
    public TMP_Text response;
    public GameObject spriteObject;
    public TextAsset inkJSON;
    public GameObject instructionsScreen;

    [Header("UI Variables")]
    public Color textColor;
    public float fBackgroundTransparency = 0.5f; // background text transparency
    public float fBackgroundTransparencyOn = 0.0f; // background color fully transparent
    public float divideValue = 3f;
    private float alphaText;
    public bool waitIsOver = false; // used in AnimationController script, prevents closing instructions from proceeding
    public bool mouseIsOverUI = false; // used in DisableSwipeOnUIHover script

    [Header("Audio")]
    public AudioSource cardSwipeAudio;

    // Card variables
    private string leftResponse;
    private string rightResponse;

    // Start is called before the first frame update
    void Start()
    {
        inkParser.story = new Story(inkJSON.text);
        LoadCard(inkParser.refreshDialogue());
    }

    // Update is called once per frame
    void Update()
    {
        // Dialogue text handling
        textColor.a = Mathf.Min(Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin / divideValue, 1); // text transparency
        responseBackgroundColor.a = Mathf.Min(Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin / divideValue, fBackgroundTransparency); // background color transparency
        responseBackgroundColorFullTransparent.a = Mathf.Min(Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin / divideValue, fBackgroundTransparencyOn); 

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // mouse position

        if (inkParser.storyOver == true)
        {
            inkParser.story = new Story(inkJSON.text);
            inkParser.storyOver = false;
            LoadCard(inkParser.refreshDialogue());
        }

        if (!instructionsScreen.activeInHierarchy && waitIsOver) // if instructions are on screen, do not let the card move
        {
            SwipeCard(pos);
        }
        UpdateResponse();

        // UI
        debugText.text = "" + textColor.a;
        
    }

    public void LoadCard(Card card)
    {
        if (card == null) {
            Debug.Log("CARD IS NULL.");
        }
        else if (card.cardType == "Prose")
        {
            proseText.text = card.prose;

            // set Character elements inactive
            npc_dialogueObject.SetActive(false);
            responseObject.SetActive(false);
            spriteObject.SetActive(false);

            // set Prose elements active
            proseBackground.SetActive(true);
            proseTextObject.SetActive(true);
        }
        else if (card.cardType == "Character")
        {
            //Debug.Log("LOAD CARD IS CHAR.");
            AssignSprite(card, card.spriteName);
            npc_dialogue.text = card.npc_dialogue;
            leftResponse = card.leftResponse;
            rightResponse = card.rightResponse;

            // set Prose elements inactive
            proseBackground.SetActive(false);
            proseTextObject.SetActive(false);

            // set Character elements active
            npc_dialogueObject.SetActive(true);
            responseObject.SetActive(true);
            spriteObject.SetActive(true);
        }

        animationController.SetFlipCard();
        cardSwipeAudio.Play(0);
    }

    private void AssignSprite(Card card, string spriteName) 
    {
        int counter = 0;
        foreach(string name in Enum.GetNames(typeof(CardSprite))) {
            //Debug.Log("Sprite name[" + counter + "]: " + name);
            if (name == spriteName) 
            {
                //Debug.Log("name = spriteName\n name: " + name + " spriteName: " + spriteName + "\n counter: " + counter);
                cardSpriteRenderer.sprite = resourceManager.sprites[counter];
                return;
            }
            else 
            {
                counter++;
            }
        }
    }

    private void SwipeCard(Vector2 pos)
    {
        if (pos.x > fSideTrigger && !mouseIsOverUI) // if past the trigger point (furthest right)
        {
            if (Input.GetMouseButtonUp(0)) // if mouse button is released, call function
            {
                Debug.Log("You swiped right.");
                if (inkParser.waitingForChoice == true) 
                {
                    inkParser.swipeDirection = "right";
                    inkParser.waitingForChoice = false;
                    inkParser.MakeDecision();
                }
                LoadCard(inkParser.refreshDialogue());
            }
        }
        else if (pos.x < -fSideTrigger && !mouseIsOverUI) // if past the trigger point (furthest left)
        {
            if (Input.GetMouseButtonUp(0)) // if mouse button is released, call function
            {
                if (inkParser.storyOver == true)
                {
                    inkParser.story = new Story(inkJSON.text);
                    inkParser.storyOver = false;
                }
                Debug.Log("You swiped left.");
                if (inkParser.waitingForChoice == true) 
                {
                    inkParser.swipeDirection = "left";
                    inkParser.waitingForChoice = false;
                    inkParser.MakeDecision();
                }
                LoadCard(inkParser.refreshDialogue());
            }
        }
        else if (!mouseIsOverUI)
        {
            textColor.a = 0; // if in the center, do not display any text
        }
    }

    private void UpdateResponse() 
    {
        response.color = textColor;
        if (cardGameObject.transform.position.x < 0) 
        {
            response.text = leftResponse;
            if (leftResponse != "")
            {
                responseBackgroundSpriteRenderer.color = responseBackgroundColor;
            }
            else
            {
                responseBackgroundSpriteRenderer.color = responseBackgroundColorFullTransparent;
            }
        }
        else 
        {
            response.text = rightResponse;
            if (rightResponse != "")
            {
                responseBackgroundSpriteRenderer.color = responseBackgroundColor;
            }
            else
            {
                responseBackgroundSpriteRenderer.color = responseBackgroundColorFullTransparent;
            }
        }
    }
    
}
