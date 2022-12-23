using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transfer2 : MonoBehaviour
{
    public string transferMapName;
    public Transform target;
    //private Player thePlayer;
    private Player2Action thePlayer;
    private CameraManager theCamera;


    void Awake()
    {
        //thePlayer = FindObjectOfType<Player>();
        thePlayer = FindObjectOfType<Player2Action>();
        theCamera = FindObjectOfType<CameraManager>();


    }


    private void OnTriggerEnter2D(Collider2D collison)
    {
        thePlayer = FindObjectOfType<Player2Action>();
        theCamera = FindObjectOfType<CameraManager>();
        if (collison.gameObject.name == "Player")
        {

            thePlayer.currentMapName = transferMapName;
            theCamera.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = target.transform.position;


        }
    }
}