using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    public AudioSource wallSound;
    public AudioSource playerSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player1" || collision.gameObject.name == "player2")
        {
            this.playerSound.Play();
        }
        else if (collision.gameObject.name == "wallTop" || collision.gameObject.name == "wallBotom")
        {
            this.wallSound.Play();
        }
    }
}
