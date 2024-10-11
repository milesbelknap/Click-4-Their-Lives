using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SisState : MonoBehaviour
{
    //sis timer
    public float sistimer = 0.0f;
    private float siswaitTime = 2.0f;

    public bool sistimeUp = false;
    public StateManager stateManager;
    public ScoreCounter scoreCounter;

    // Start is called before the first frame update
    void Start()
    {
       StateManager stateManager = gameObject.GetComponent(typeof(StateManager)) as StateManager;
       ScoreCounter scoreCounter = gameObject.GetComponent(typeof(ScoreCounter)) as ScoreCounter;
       GameObject.Find("ScoreAmount").GetComponent<ScoreCounter>().AddScore();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //sis state
        if (!stateManager.sisisStarted)
            return;
        if (System.Math.Abs(sistimer) > siswaitTime)
        {
            //fail end game
            //stateManager.intState = true;
            sistimeUp = true;
        }

        sistimer += Time.deltaTime * 1;
        scoreCounter.score.text = scoreCounter.scoreAmount.ToString();

        if (sistimeUp == true)
        {
            FindObjectOfType<AudioManager>().Play("Explosion");
            scoreCounter.explosion.Play();
            scoreCounter.gore.Play();
            stateManager.EndState = true;
            stateManager.sisisStarted = false;
        }
    }

   public void AddScore()
    {
        sistimer = 0.0f;
    }
}
