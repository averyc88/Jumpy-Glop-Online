using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MenuLogic : MonoBehaviour
{
    public MenuMusicScript MenuMusic;
    // static bool created = false;
    void Awake()
    {   
    
        MenuMusic = GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusicScript>();
        MenuMusic.playMusic();   
    }
    public void playGame()
    {
        SceneManager.LoadScene("Jumpy Glop");
    }

    public void highScores()
    {
        SceneManager.LoadScene("High Scores");
    }
}
