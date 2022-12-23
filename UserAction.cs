using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserAction : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    private float speed = 5;

    private float horizontal;
    public UserManager manager;
    public bool isDie=false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (UserManager.Instance.stopTrigger)
        PlayerMove();

        ScreenChk();

      
    }

    private void PlayerMove()
    {
        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
    }

    private void ScreenChk()
    {
        Vector3 worlpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worlpos.x < 0.05f) worlpos.x = 0.05f;
        if (worlpos.x > 0.95f) worlpos.x = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worlpos);
    }
}
