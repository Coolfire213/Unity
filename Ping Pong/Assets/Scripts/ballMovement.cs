using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    public float moveSpeed;
    public float maxSpeed;
    public float speedIncrease;

    int hitCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartBall());
    }

    void BallReset(bool isPlayer1)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (isPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(-100, 45, 0);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(100, 45, 0);
        }
    }

    public IEnumerator StartBall(bool player1Start = true)
    {
        this.BallReset(player1Start);
        this.hitCounter = 0;
        yield return new WaitForSeconds(1);
        if (player1Start)
        {
            MoveBall(new Vector2(-1, 0));
            Debug.Log("test0");
        }
        else
        {
            MoveBall(new Vector2(1,0));
        }
    }

    public void MoveBall(Vector2 dir)
    {
        dir = dir.normalized;
        float speed = moveSpeed + hitCounter * speedIncrease;
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();   
        rigidbody2D.velocity = dir * speed;
        Debug.Log("test4");
    }

    public void IncreaseHitCounter()
    {
        if(this.hitCounter * this.speedIncrease <= this.maxSpeed)
            this.hitCounter++;
    }
}
