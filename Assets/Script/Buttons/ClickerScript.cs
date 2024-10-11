using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerScript : MonoBehaviour
{

    static public ScoreCounter scoreCounter;
    static public SisState sisState;
    static public ClickScript clickScript;

  

    // Start is called before the first frame update
    void Start()
    {
        ScoreCounter scoreCounter = gameObject.GetComponent(typeof(ScoreCounter)) as ScoreCounter;
        SisState sisState = gameObject.GetComponent(typeof(SisState)) as SisState;
        ClickScript clickScript = gameObject.GetComponent(typeof(ClickScript)) as ClickScript;

        StartCoroutine(Clickit());
    }

    // Update is called once per frame
    void Update()
    {
        //destroy on click
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

          
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                   {
                    clickScript.clickerCount -= 1;
                    Destroy(gameObject);
                   }
                
            }
        }
    }

    IEnumerator Clickit()
    {
        yield return new WaitForSeconds(3f);
        scoreCounter.timer = 3;
        scoreCounter.dadtimer = 3;
        sisState.sistimer = 3;
        Destroy(gameObject);
    }
}
