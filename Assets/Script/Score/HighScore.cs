using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{

    //highscore number
    public Text highScore;
    public int highScoreAmount;

    //Gameobjects
    public GameObject highscorePanel;
    public GameObject RetryButton;
    public GameObject high_Score;

    //other scripts
    public StateManager stateManager;
    public ScoreCounter scoreCounter;

    void Start()
    {
        highscorePanel.SetActive(false);
        RetryButton.SetActive(false);
        high_Score.SetActive(false);

        ScoreCounter scoreCounter = gameObject.GetComponent(typeof(ScoreCounter)) as ScoreCounter;
        StateManager stateManager = gameObject.GetComponent(typeof(StateManager)) as StateManager;
    }

    void Update()
    {

        if(stateManager.highscoreDispalyed == true)
        {
            highscorePanel.SetActive(true);
            RetryButton.SetActive(true);
            high_Score.SetActive(true);

            highScoreAmount = scoreCounter.scoreAmount;
            highScore.text = highScoreAmount.ToString();
        }

    }

    public void Retry()
    {
        SceneManager.LoadScene("GamePlay");
    }

}
