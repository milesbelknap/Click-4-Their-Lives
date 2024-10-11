using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_Button : MonoBehaviour
{

    //GameObjects
    public GameObject UpgradeMenu;
    public GameObject FiveBut;
    public GameObject TenBut;
    public GameObject QuarterBut;
    public GameObject HalfBut;
    public GameObject ExBut;
    public GameObject continueOneUI;
    public GameObject continueTwoUI;
    public GameObject firstPoints;
    public GameObject secondPoints;
    public GameObject thirdPoints;
    public GameObject fourthPoints;

    //other scripts
    public ScoreCounter scoreCounter;
    public StateManager stateManager;

    //bools
    public bool FiveIsBuyable = false;
    public bool TenIsBuyable = false;
    public bool QuartIsBuyable = false;
    public bool HalfIsBuyable = false;
    public bool FiveIsWaiting = true;
    public bool TenIsWaiting = true;
    public bool QuartIsWaiting = true;
    public bool HalfIsWaiting = true;
    


    // Start is called before the first frame update
    void Start()
    {
        UpgradeMenu.SetActive(false);
        FiveBut.SetActive(false);
        TenBut.SetActive(false);
        QuarterBut.SetActive(false);
        HalfBut.SetActive(false);
        ExBut.SetActive(false);
        firstPoints.SetActive(false);
        secondPoints.SetActive(false);
        thirdPoints.SetActive(false);
        fourthPoints.SetActive(false);

        ScoreCounter scoreCounter = gameObject.GetComponent(typeof(ScoreCounter)) as ScoreCounter;
        StateManager stateManager = gameObject.GetComponent(typeof(StateManager)) as StateManager;
    }

    // Update is called once per frame
    void Update()
    {
        
        scoreCounter.score.text = scoreCounter.scoreAmount.ToString();

        if(FiveIsWaiting == true)
        {
            if (scoreCounter.scoreAmount >= 300)
            {
                FiveIsBuyable = true;   
            }
        }

        if(TenIsWaiting == true)
        {
            if (scoreCounter.scoreAmount >= 700)
            {
                TenIsBuyable = true;
            }
        }
       
        if(QuartIsWaiting == true)
        {
            if (scoreCounter.scoreAmount >= 1500)
            {
                QuartIsBuyable = true;
            }
        }
       
        if(HalfIsWaiting == true)
        {
            if (scoreCounter.scoreAmount >= 3000)
            {
                HalfIsBuyable = true;
            }
        }
       
    }


    public void Upgrade()
    {
        FindObjectOfType<AudioManager>().Play("Click_2");

        UpgradeMenu.SetActive(true);
        FiveBut.SetActive(true);
        TenBut.SetActive(true);
        QuarterBut.SetActive(true);
        HalfBut.SetActive(true);
        ExBut.SetActive(true);
        firstPoints.SetActive(true);
        secondPoints.SetActive(true);
        thirdPoints.SetActive(true);
        fourthPoints.SetActive(true);


        stateManager.continueUI.SetActive(false);
      
        
    }

    public void EX()
    {

        FindObjectOfType<AudioManager>().Play("Click_3");

        UpgradeMenu.SetActive(false);
        FiveBut.SetActive(false);
        TenBut.SetActive(false);
        QuarterBut.SetActive(false);
        HalfBut.SetActive(false);
        ExBut.SetActive(false);
        firstPoints.SetActive(false);
        secondPoints.SetActive(false);
        thirdPoints.SetActive(false);
        fourthPoints.SetActive(false);


        stateManager.continueUI.SetActive(true);
        

    }

    public void FiveMult()
    {

        FindObjectOfType<AudioManager>().Play("Click_3");

        if (FiveIsBuyable == true)
        {
            scoreCounter.isFived = true;
            scoreCounter.isNormal = false;
            FiveIsWaiting = false;
            scoreCounter.scoreAmount = scoreCounter.scoreAmount - 300;
            FiveIsBuyable = false;
        }
    }

    public void TenMult()
    {

        FindObjectOfType<AudioManager>().Play("Click_3");

        if (TenIsBuyable == true)
        {
            scoreCounter.isTened = true;
            scoreCounter.isFived = false;
            scoreCounter.isNormal = false;
            TenIsWaiting = false;
            scoreCounter.scoreAmount = scoreCounter.scoreAmount - 700;
            TenIsBuyable = false;
        }
    }

    public void QuarterMult()
    {

        FindObjectOfType<AudioManager>().Play("Click_3");

        if (QuartIsBuyable == true)
        {
            scoreCounter.isQuartered = true;
            scoreCounter.isTened = false;
            scoreCounter.isFived = false;
            scoreCounter.isNormal = false;
            QuartIsWaiting = false;
            scoreCounter.scoreAmount = scoreCounter.scoreAmount - 1500;
            QuartIsBuyable = false;
        }
    }

    public void HalfMult()
    {

        FindObjectOfType<AudioManager>().Play("Click_3");

        if (HalfIsBuyable == true)
        {
            scoreCounter.isHalved = true;
            scoreCounter.isQuartered = false;
            scoreCounter.isTened = false;
            scoreCounter.isFived = false;
            scoreCounter.isNormal = false;
            HalfIsWaiting = false;
            scoreCounter.scoreAmount = scoreCounter.scoreAmount - 3000;
            HalfIsBuyable = false;
        }
    }
}
