using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardController : MonoBehaviour
{
    //public ProseCard proseCard;
    //public CharacterCard characterCard;
    public BoxCollider2D thisCard;
    public bool isMouseOver;
    //public TMP_Text tmp;

    // Start is called before the first frame update
    void Start()
    {
        thisCard = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver() {
        isMouseOver = true;
    }

    private void OnMouseExit() {
        isMouseOver = false;
    }

}

public enum CardSprite
{
    JEAN_neutral,
    JEAN_angry,
    JEAN_sad,
    JEAN_blush,
    JEAN_smile
}