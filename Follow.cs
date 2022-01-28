using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float cameraDistOffset = 10;
    private Camera mainCamera;
    private GameObject player;

    private bool lookDown;
    // Use this for initialization
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        player = GameObject.Find("Paul");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerInfo = player.transform.transform.position;


        if (Input.GetKeyDown("f") && lookDown == false)
        {
            lookDown = true;
        }
        else if (Input.GetKeyUp("f") && lookDown == true)
        {
            lookDown = false;
        }

        if (lookDown == true)
        {
            mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y - 5, playerInfo.z - cameraDistOffset);
        }
        else
        {
            mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y, playerInfo.z - cameraDistOffset);
        }


    }
}
