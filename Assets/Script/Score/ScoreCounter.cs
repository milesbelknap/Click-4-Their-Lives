using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    //Score
    public Text score;
    public int scoreAmount;

    //UpgradeBools
    public bool isNormal = true;
    public bool isFived = false;
    public bool isTened = false;
    public bool isQuartered = false;
    public bool isHalved = false;

    //GameObject
    public Button button;
    public ParticleSystem explosion;
    public ParticleSystem gore;

    //bools & other script stuff
    public bool timeUp = false;
    public bool dadtimeUp = false;
    public StateManager stateManager;
    

    //mom timer
    public float timer = 0.0f;
    private float waitTime = 2.0f;

    //dad timer
    public float dadtimer = 0.0f;
    private float dadwaitTime = 2.0f;

    public void Start()
    {
        scoreAmount = 0;
        score = GetComponent<Text>();

        //GameObject g = GameObject.FindGameObjectWithTag("Player");
        //stateManager = g.GetComponent<StateManager>();
       StateManager stateManager = gameObject.GetComponent(typeof(StateManager)) as StateManager;
        

    }

    public void Update()
    {

        
        //Mom State
        if (!stateManager.isStarted)
            return;
        if (System.Math.Abs(timer) > waitTime)
        {
            //fail end game
            timeUp = true;
        }

        timer += Time.deltaTime * 1;
        score.text = scoreAmount.ToString();

        if(timeUp == true)
        {
            FindObjectOfType<AudioManager>().Play("Explosion");
            explosion.Play();
            gore.Play();
            stateManager.intState = true;
            stateManager.isStarted = false;
        }

    }

    public void FixedUpdate()
    {
        //dad State
        if (!stateManager.dadisStarted)
            return;
        if (System.Math.Abs(dadtimer) > dadwaitTime)
        {
            //fail end game
            //stateManager.intState = true;
            dadtimeUp = true;
        }

        dadtimer += Time.deltaTime * 1;
        score.text = scoreAmount.ToString();

        if (dadtimeUp == true)
        {
            FindObjectOfType<AudioManager>().Play("Explosion");
            explosion.Play();
            gore.Play();
            stateManager.secondintState = true;
            stateManager.dadisStarted = false;
        }




        
    }

    public void AddScore()
    {

        FindObjectOfType<AudioManager>().Play("Click_1");
        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.

        if (isNormal == true)
        {
            scoreAmount += 1;
        }

        if (isFived == true)
        {
            scoreAmount += 5;
        }

        if (isTened == true)
        {
            scoreAmount += 10;
        }

        if(isQuartered == true)
        {
            scoreAmount += 25;
        }

        if(isHalved == true)
        {
            scoreAmount += 50;
        }

        timer = 0.0f;
        dadtimer = 0.0f;
        


    }

   
}
