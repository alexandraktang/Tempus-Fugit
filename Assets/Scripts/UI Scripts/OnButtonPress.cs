using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnButtonPress : MonoBehaviour
{
    public string sceneToLoad;

    public AudioSource audioSource;
    private Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button button;
    private bool soundOn = true;

    public AnimationController anim;
    
    void Start() 
    {
        soundOnImage = button.image.sprite;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void MuteMusic()
    {
        if (soundOn)
        {
            button.image.sprite = soundOffImage;
            soundOn = false;
            audioSource.mute = true;
        }
        else
        {
            button.image.sprite = soundOnImage;
            soundOn = true;
            audioSource.mute = false;
        }
    }

    public void SetInstructionScreenFalse()
    {
        anim.SetInstructionScreenFalse();
        
    }

    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

}
