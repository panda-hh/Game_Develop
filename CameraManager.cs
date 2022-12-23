using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    static public CameraManager instance;
    public GameObject target;//카메라가 따라갈대상
    public float moveSpeed;
    private Vector3 targetPosition;//대상의 현재 위치값
    public string currentMapName;

    void Start()
    {
    

        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else if(currentMapName=="Game1")
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);

            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }

       
        if (currentMapName == "Game1")
        {
            Destroy(this.gameObject);
        }
        else if (currentMapName == "Stage1")
        {
            this.target = GameObject.Find("Player");
        }


    }
}