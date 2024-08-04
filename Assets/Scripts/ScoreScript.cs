using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public Text highScore1;
    public Text playerName1;
    public Text highScore2;
    public Text playerName2;
    public Text highScore3;
    public Text playerName3;

    // Start is called before the first frame update
    void Start()
    {
        // initialize player names
        if (PlayerPrefs.GetString("playerName1") == null)
        {
            PlayerPrefs.SetString("playerName1", "Name 1:");
        }

        if (PlayerPrefs.GetString("playerName2") == null)
        {
            PlayerPrefs.SetString("playerName2", "Name 2:");
        }

        if (PlayerPrefs.GetString("playerName3") == null)
        {
            PlayerPrefs.SetString("playerName3", "Name 3:");
        }

        // initialize scores
        if (PlayerPrefs.GetInt("highScore1") == 0)
        {
            PlayerPrefs.SetInt("highScore1", 0);
        }

        if (PlayerPrefs.GetInt("highScore2") == 0)
        {
            PlayerPrefs.SetInt("highScore2", 0);
        }

        if (PlayerPrefs.GetInt("highScore3") == 0)
        {
            PlayerPrefs.SetInt("highScore3", 0);
        }


    }

    // Update is called once per frame
    void Update()
    {
        highScore1.text = PlayerPrefs.GetInt("highScore1").ToString();
        playerName1.text = PlayerPrefs.GetString("playerName1");

        highScore2.text = PlayerPrefs.GetInt("highScore2").ToString();
        playerName2.text = PlayerPrefs.GetString("playerName2");

        highScore3.text = PlayerPrefs.GetInt("highScore3").ToString();
        playerName3.text = PlayerPrefs.GetString("playerName3");

    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void resetHighScores()
    {
        PlayerPrefs.SetInt("highScore1", -1);
        PlayerPrefs.SetInt("highScore2", -1);
        PlayerPrefs.SetInt("highScore3", -1);

        PlayerPrefs.SetString("playerName1", "Name 1:");
        PlayerPrefs.SetString("playerName2", "Name 2:");
        PlayerPrefs.SetString("playerName3", "Name 3:");


    }
}
