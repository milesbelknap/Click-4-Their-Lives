using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    [SerializeField] private CameraFollow cameraFollow;

    private Vector3 cameraFollowPosition;

    public float edgeSize = 30f;

    public float moveAmount = 100f;

    private void Start()
    {
        //cameraFollow.Setup(() => cameraFollowPosition, () => 80f);
    }
   
    // Update is called once per frame
    void Update()
    {

        if(Input.mousePosition.x > Screen.width - edgeSize)
        {
            cameraFollowPosition.x += moveAmount * Time.deltaTime;
        }

        if (Input.mousePosition.x < edgeSize)
        {
            cameraFollowPosition.x -= moveAmount * Time.deltaTime;
        }

        if (Input.mousePosition.y > Screen.width - edgeSize)
        {
            cameraFollowPosition.y += moveAmount * Time.deltaTime;
        }

        if (Input.mousePosition.y < edgeSize)
        {
            cameraFollowPosition.y -= moveAmount * Time.deltaTime;
        }

    }
}
