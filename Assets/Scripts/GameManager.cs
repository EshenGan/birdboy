using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField]private birdboy birdboy;
    [SerializeField]private GameObject Play; //button
    [SerializeField] private Text scoretext;
     [SerializeField] private GameObject gameOver;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        pause();
    }

    public void play() {
        score = 0;
        scoretext.text = score.ToString();

        Play.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        birdboy.enabled = true;

        pipes[] pipes = FindObjectsOfType<pipes>();

        for (int i = 0; i < pipes.Length; i++) // destroy old pipes from previous game session
        {
            Destroy(pipes[i].gameObject);
        }
    }
    public void pause() {
        Time.timeScale = 0f;
        birdboy.enabled = false;
        

    }

    public void GameOver() {
        gameOver.SetActive(true);
        Play.SetActive(true);

        pause();

        
    }
    public void scoreinc() {
        score++;
        scoretext.text = score.ToString();
    }
}
