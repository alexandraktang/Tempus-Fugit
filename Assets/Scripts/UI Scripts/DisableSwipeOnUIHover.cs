using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSwipeOnUIHover : MonoBehaviour
{
    public GameManager2 gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mouseOnUI()
    {
        gameManager.mouseIsOverUI = true;
    }

    public void mouseOffUI()
    {
        gameManager.mouseIsOverUI = false;
    }
}
