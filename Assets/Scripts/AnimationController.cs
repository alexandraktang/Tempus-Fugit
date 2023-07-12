using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator anim;
    public GameManager2 gameManager;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // mouse position
        UpdateCardPosition(mousePosition);
    }

    private void UpdateCardPosition(Vector2 pos) 
    {
        if (pos.x > gameManager.fSideTrigger) // mouse is on right side && mouse is greater than sideMargin
        {
            anim.SetBool("moveRight", true);
        }
        else if (pos.x < -gameManager.fSideTrigger) // mouse is on left side && mouse is less than negative sideMargin
        {
            anim.SetBool("moveLeft", true);
        }
        else 
        {
            anim.SetBool("moveRight", false);
            anim.SetBool("moveLeft", false);
        }
    }

    public void SetFlipCard() 
    {
        anim.SetBool("loadingCard", true);
    }

    public void ResetFlipCard()
    {
        anim.SetBool("loadingCard", false);
    }

    public void SetInstructionScreenFalse()
    {
        anim.SetBool("instructionsScreen", false);
        StartCoroutine(WaitForSeconds(.2f)); // makes GameManager wait for 2 seconds before registering clicks, so closing menu does not affect story
    }

    private IEnumerator WaitForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameManager.waitIsOver = true;
    }

}