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
    public Text highScoreText;
    public Text highScoreText2;

    public SingularHighScoreScript highScore;
    public int playerScore;

    void Awake()
    {   
        highScore = GameObject.FindGameObjectWithTag("HighScore").GetComponent<SingularHighScoreScript>();
        highScoreText.text = highScore.highScore.ToString();
        highScoreText2.text = highScore.highScore.ToString();

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

    public void Update()
    {

    }
}
