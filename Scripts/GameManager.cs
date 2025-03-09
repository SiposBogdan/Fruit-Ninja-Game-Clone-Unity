using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Score Elements")]
    public int score;
    public Text scoreText;
    public int highscore;
    public Text highscoreText;

    [Header("Sounds")]
    public AudioClip[] sliceSounds;
    public AudioClip[] bombSounds;
    public AudioClip[] missSounds;
    public AudioClip[] missFinalSounds;
    public AudioSource audioSource;

    [Header("Game Over")]
    public GameObject gameOverPannel;
    public Text gameOverPannelScoreText;
    public Text gameOverPannelHighScoreText;

    [Header("Lives System")]
    public int lives = 3;
    public Text livesText;



    private void Awake()
    {
        gameOverPannel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        GetHighscore();
        
    }
    
    public void IncreaseScore(int points)
    {
        score = score + points;
        scoreText.text = "Score: " + score.ToString();
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = "Best: "+ score.ToString();
        }
    }
    public void OnBombHit()
    {
        Time.timeScale = 0;
        gameOverPannelScoreText.text = "Score: " + score.ToString();
        gameOverPannelHighScoreText.text = "Best: " + highscore.ToString();
        gameOverPannel.SetActive(true);
        Debug.Log("Bomb hit");
    }
    private void GetHighscore()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Best: " + highscore;
    }
    public void RestartGame()
    {
        score = 0;
        lives = 3;
        scoreText.text = "Score: "+score.ToString();
        livesText.text = "Lives: " + lives.ToString();

        gameOverPannel.SetActive(false);

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(obj);
        }
        Time.timeScale = 1;
    }
    public void PlayRandomSliceSounds()
    {
        AudioClip randomSound = sliceSounds[Random.Range(0, sliceSounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }
    public void PlayRandomBombSounds()
    {
        AudioClip randomSound = bombSounds[Random.Range(0, bombSounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }

    public void PlayRandomMissSounds()
    {
        AudioClip randomSound = missSounds[Random.Range(0, missSounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }
    public void PlayRandomFinalSounds()
    {
        AudioClip randomSound = missFinalSounds[Random.Range(0, missFinalSounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }
    public void OnZeroLivesLeft()
    {
        FindAnyObjectByType<GameManager>().PlayRandomFinalSounds();
        Time.timeScale = 0;
        gameOverPannelScoreText.text = "Score: " + score.ToString();
        gameOverPannelHighScoreText.text = "Best: " + highscore.ToString();
        gameOverPannel.SetActive(true);
        Debug.Log("No lives left");
    }
    public void LoseLife()
    {
        lives--;
        FindAnyObjectByType<GameManager>().PlayRandomMissSounds();
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives.ToString();
        }
        if (lives <= 0)
        {
            OnZeroLivesLeft();
        }
    }

}
