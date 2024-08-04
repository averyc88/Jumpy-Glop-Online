using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LogicScript : MonoBehaviour
{
    public PipeSpawnScript spawn;
    public AudioSource Song;

    public AudioSource GameOverSound;
    public MenuMusicScript MenuMusic;

    public SingularHighScoreScript highScore;

    public Dictionary<string, Tuple<string, int>> highScores = new Dictionary<string, Tuple<string, int>>();

    void Start()
    {
        gameOverScreen.SetActive(false);

        // initialize pipe spawner 
        spawn = GameObject.FindGameObjectWithTag("PipeSpawn").GetComponent<PipeSpawnScript>();
        GameOverSound = GameObject.FindGameObjectWithTag("GameOverSound").GetComponent<AudioSource>();
        MenuMusic = GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusicScript>();
        highScore = GameObject.FindGameObjectWithTag("HighScore").GetComponent<SingularHighScoreScript>();

        MenuMusic.stopMusic();
        Song = GetComponent<AudioSource>();
        Song.playOnAwake = true;
        Song.loop = true;

        // Initialize high scores
        highScores.Add(PlayerPrefs.GetString("playerName1"), new Tuple<string, int>(PlayerPrefs.GetString("playerName1"), PlayerPrefs.GetInt("highScore1")));
        highScores.Add(PlayerPrefs.GetString("playerName2"), new Tuple<string, int>(PlayerPrefs.GetString("playerName2"), PlayerPrefs.GetInt("highScore2")));
        highScores.Add(PlayerPrefs.GetString("playerName3"), new Tuple<string, int>(PlayerPrefs.GetString("playerName3"), PlayerPrefs.GetInt("highScore3")));

    }
    public int playerScore;
    public string curPlayer;
    public Text scoreText;
    public Text scoreText2;

    public GameObject gameOverScreen;
    public bool gameEnded = false;
    public bool nameEntered = false;


    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        scoreText2.text = playerScore.ToString();
    }
    public void restartGame()
    {
        SceneManager.LoadScene("Jumpy Glop");
    }

    public void exitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void gameOver()
    {
        // activate game over screen, deactivate pipe spawner when game ends
        gameOverScreen.SetActive(true);
        spawn.gameActive = false;
        gameEnded = true;
        Song.Stop();
        GameOverSound.Play();

        if (playerScore > highScore.highScore) 
        {
            highScore.highScore = playerScore;
        }

        // handle game over coroutine
        StartCoroutine(HandleGameOver());
    }

    private IEnumerator HandleGameOver()
    {
        yield return new WaitUntil(() => nameEntered == true);

        // handle high scores
        var newScores = handleHighScores(highScores, playerScore, curPlayer);
        highScores = newScores;

        // set player prefs to new scores and names
        PlayerPrefs.SetInt("highScore1", highScores.ElementAt(0).Value.Item2);
        PlayerPrefs.SetInt("highScore2", highScores.ElementAt(1).Value.Item2);
        PlayerPrefs.SetInt("highScore3", highScores.ElementAt(2).Value.Item2);

        PlayerPrefs.SetString("playerName1", highScores.ElementAt(0).Value.Item1);
        PlayerPrefs.SetString("playerName2", highScores.ElementAt(1).Value.Item1);
        PlayerPrefs.SetString("playerName3", highScores.ElementAt(2).Value.Item1);
    }

    // handle the high scores
    public static Dictionary<string, Tuple<string, int>> handleHighScores(Dictionary<string, Tuple<string, int>> highScores, int score, string name)
    {

        // if the dictionary already contains this person's name, update it 
        if (highScores.ContainsKey(name))
        {
            var curScore = highScores[name].Item2;
            if (curScore < score)
            {
                highScores[name] = new Tuple<string, int>(name, score);
            }

            highScores = highScores.OrderByDescending(x => x.Value.Item2).ToDictionary(x => x.Key, x => x.Value);

            return highScores;
        }

        // if the score is lower than the current lowest, don't do anything
        else if (score <= (highScores.ElementAt(2).Value.Item2))
        {
            return highScores;
        }
        else
        {
            // add new entry
            highScores.Add(name, new Tuple<string, int>(name, score));

            // sort dictionary 
            highScores = highScores.OrderByDescending(x => x.Value.Item2).ToDictionary(x => x.Key, x => x.Value);

            // remove the lowest score
            var lastElement = highScores.LastOrDefault();
            highScores.Remove(lastElement.Key);

            return highScores;
        }
    }
    // void Update()
    // {

    // }
}
