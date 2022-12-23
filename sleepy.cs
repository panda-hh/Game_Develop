using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleepy : MonoBehaviour
{

    [SerializeField]
    private new Rigidbody2D rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            UserManager.Instance.Score();
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            UserManager.Instance.GameOver();
            collision.gameObject.GetComponent<UserAction>().isDie = true;
            Destroy(this.gameObject);
            

            GameObject[] allsleepy = GameObject.FindGameObjectsWithTag("Sleepy");
            for(int i=0; i<allsleepy.Length; i++)
            {
                Destroy(allsleepy[i]);
            }
            
        }
    }

  
}
