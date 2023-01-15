using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCollision : MonoBehaviour
{
    public ballMovement ballMovement;
    public scoreController scoreController;

    void Deflection(Collision2D c)
    {
        Vector3 ballPos = this.transform.position;
        Vector3 playerPos = c.gameObject.transform.position;

        float playerHeight = c.collider.bounds.size.y;
        float x;
        if (c.gameObject.name == "player1")
            x = 1;
        else
            x = -1;

        float y = (ballPos.y - playerPos.y) / playerHeight;

        this.ballMovement.IncreaseHitCounter();
        this.ballMovement.MoveBall(new Vector2(x, y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "player1" || collision.gameObject.name == "player2")
        {
            this.Deflection(collision);
        }
        else if (collision.gameObject.name == "wallLeft")
        {
            Debug.Log("hit left wall");
            this.scoreController.UpdatePlayer2();
            StartCoroutine(this.ballMovement.StartBall(true));
        }
        else if (collision.gameObject.name == "wallRight")
        {
            Debug.Log("hit right wall");
            this.scoreController.UpdatePlayer1();
            StartCoroutine(this.ballMovement.StartBall(false));
        }
    }
}
