using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{

    public GameObject Clicker;
    public int xPos;
    public int yPos;
    
    public int clickerCount;
    public bool isPaused;

    public StateManager stateManager;

    // Start is called before the first frame update
    void Start()
    {
       StateManager stateManager = gameObject.GetComponent(typeof(StateManager)) as StateManager;

        isPaused = false;

    }

        // Update is called once per frame
        void Update()
    {

      

        //mom
        if (stateManager.isStarted == true)
       {
            isPaused = false;
            StartCoroutine(ClickerSpawn());
        }
        else if (stateManager.isStarted == false)
        {
         
            isPaused = true;
        }
       

        //dad
       if (stateManager.dadisStarted == true)
       {
            StartCoroutine(ClickerSpawn());
            isPaused = false;
       }
       else if(stateManager.dadisStarted == false)
       {

            isPaused = true;
       }

        //sister
       if (stateManager.sisisStarted == true)
        {
            StartCoroutine(ClickerSpawn());
            isPaused = false;
        }
        else if (stateManager.sisisStarted == false)
        {
            isPaused = true;
        }
    }

    IEnumerator ClickerSpawn()
    {

        
            while (isPaused)
            {
                yield return null;
            }

            while (clickerCount < 1)
            {

            xPos = Random.Range(-27, 23);
            yPos = Random.Range(-51, -30);
            clickerCount += 1;
            yield return new WaitForSeconds(10f);
            Instantiate(Clicker, new Vector3(xPos, yPos, -3), Quaternion.identity);         

            }
          
           

    }
}
