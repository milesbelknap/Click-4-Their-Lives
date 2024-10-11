using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    //buttons
    public GameObject startButton;
    public Button button;
    public Button upgrade;

    //Objects
    public GameObject MomOb;
    public GameObject DadOb;
    public GameObject SisterOb;
    public GameObject continueOneUI;
    public GameObject continueTwoUI;
    public GameObject continueUI;
    public GameObject countDown;

    //character animators
    public Animator Mom;
    public Animator Father;
    public Animator Sister;
    public Animator Countdown;

    //gameplay bools
    public bool isStarted = false;
    public bool dadisStarted = false;
    public bool sisisStarted = false;
    public bool highscoreDispalyed = false;

    //other scripts
    public Upgrade_Button upgradeButton;

    //States
    bool startState = true;
    public bool intState = false;
    public bool secondintState = false;
    bool Dad = false;
    bool SisterState = false;
    public bool EndState = false;



    // Start is called before the first frame update
    public void Start()
    {
        if (startState == true)
        {
            //Time.timeScale = 0;
            button.interactable = false;
            upgrade.interactable = false;

            countDown.SetActive(false);

            upgradeButton = gameObject.GetComponent(typeof(Upgrade_Button)) as Upgrade_Button;
        }
    }

    // Update is called once per frame
    public void Update()
    {

        if (intState == true)
        {
            Destroy(MomOb);
            button.interactable = false;
            upgrade.interactable = true;
            continueOneUI.SetActive(true);
        }

        if (Dad == true)
        {
            intState = false;
            isStarted = false;
            Destroy(continueOneUI);
        }


        if (secondintState == true)
        {
            Destroy(DadOb);
            button.interactable = false;
            continueUI.SetActive(true);
            continueTwoUI.SetActive(true);
        }

        if(SisterState == true)
        {
            secondintState = false;
            dadisStarted = false;
            Destroy(continueTwoUI);
        }

        if(EndState == true)
        {
            sisisStarted = false;
            Destroy(SisterOb);
            button.interactable = false;
            highscoreDispalyed = true;
        }
    }

    IEnumerator NarratorCooldown()
    {
        countDown.SetActive(true);
        Countdown.SetBool("isStarted", true);
        yield return new WaitForSeconds(6f);
        Countdown.SetBool("isStarted", false);
    }

    IEnumerator DadNarratorCooldown()
    {
        countDown.SetActive(true);
        Countdown.SetBool("dadisStarted", true);
        yield return new WaitForSeconds(6f);
        Countdown.SetBool("dadisStarted", false);
    }

    IEnumerator SisNarratorCooldown()
    {
        countDown.SetActive(true);
        Countdown.SetBool("sisisStarted", true);
        yield return new WaitForSeconds(6f);
        Countdown.SetBool("sisisStarted", false);
    }

    IEnumerator CoolDown()
    {
        StartCoroutine(NarratorCooldown());
        // Wait 3 seconds...
        yield return new WaitForSeconds(5f);
        button.interactable = true;
        isStarted = true;
    }

    IEnumerator CountDown()
    {
        StartCoroutine(DadNarratorCooldown());
        // Wait 3 seconds...
        yield return new WaitForSeconds(5f);
        button.interactable = true;
        dadisStarted = true;
    }

    IEnumerator SisCountDown()
    {
        StartCoroutine(SisNarratorCooldown());
        // Wait 3 seconds...
        yield return new WaitForSeconds(5f);
        button.interactable = true;
        sisisStarted = true;
    }



    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Play("Click_2");
        startState = false;
        Destroy(startButton);
       // Time.timeScale = 1;
        Mom.SetBool("isTime", true);
        StartCoroutine(CoolDown());

    }

    public void ContinueOne()
    {
        FindObjectOfType<AudioManager>().Play("Click_2");
        Dad = true;
        Father.SetBool("isTime", true);
        StartCoroutine(CountDown());
    }

    public void ContinueTwo()
    {
        FindObjectOfType<AudioManager>().Play("Click_2");
        SisterState = true;
        Sister.SetBool("isTime", true);
        StartCoroutine(SisCountDown());
    }
}
