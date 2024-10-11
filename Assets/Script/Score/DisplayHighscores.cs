using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour
{

    public Text[] highscoreText;
    LeaderBoard highscoreManager;

    void Start()
    {

        for (int i =0; i < highscoreText.Length; i ++)
        {
            highscoreText[i].text = i+1 + ". Fetching...";
        }

        highscoreManager = GetComponent<LeaderBoard>();

        StartCoroutine("RefreshHighscores");
    }

    public void OnHighscoresDownLoaded(LeaderBoard.Highscore[] highscoreList)
    {
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". ";
            if (highscoreList.Length > i)
            {
                highscoreText[i].text += highscoreList[i].username + " _ " + highscoreList[i].score;
            }
        }
    }

    IEnumerator RefreshHighscores()
    {
        while (true)
        {
            highscoreManager.DownloadHighScores();
            yield return new WaitForSeconds(30);
        }
    }
    
}
