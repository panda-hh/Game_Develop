using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint;
   // private Player thePlayer;
    private PlayerAction thePlayer;
    private CameraManager theCamera;


    void Start()
    {
        theCamera = FindObjectOfType<CameraManager>();
        
        thePlayer = FindObjectOfType<PlayerAction>();
        //thePlayer = FindObjectOfType<Player>();
        if (startPoint==thePlayer.currentMapName)
        {
            theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = this.transform.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
