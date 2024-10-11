using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{

    const string privateCode = "T5IvfAfFEUOprc2nGeoLwQGQVzE9a3zkOFnodT7uNJ4Q";
    const string publicCode = "601beb418f40bb2a70555b08";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoresList;
    static LeaderBoard instance;
    DisplayHighscores highscoresDisplay;

    void Awake()
    {
        instance = this;
        highscoresDisplay = GetComponent<DisplayHighscores>();
    }

    [System.Obsolete]
    public static void AddNewHighscore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighScore(username, score));
    }

    [System.Obsolete]
    IEnumerator UploadNewHighScore(string username, int score)
    {

        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
           print("Upload Successful");
            DownloadHighScores();
        }
        else
        {
            print("Error Uploadings" + www.error);
        }

    }

    public void DownloadHighScores()
    {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }

    [System.Obsolete]
    IEnumerator DownloadHighscoresFromDatabase()
    {

        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);
            highscoresDisplay.OnHighscoresDownLoaded(highscoresList);
        }
        else
        {
            print("Error Downloading:" + www.error);
        }

    }

    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];
        for (int i = 0; i <entries.Length; i ++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
        }
    }

    public struct Highscore
    {
        public string username;
        public int score;

        public Highscore(string _username, int _score)
        {
            username = _username;
            score = _score;
        }
    }
}
