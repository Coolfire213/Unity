using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameStart;
    public int score;
    public TextMeshProUGUI scoreTex;
    public TextMeshProUGUI highscoreTex;
    int highscore;

    private void Awake()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        highscoreTex.text = "Highscore: " + highscore.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            GameStart();
    }

    public void GameStart()
    {
        isGameStart = true;
        FindObjectOfType<RoadGeneration>().StartCreating();
    }

    public void Restart()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        if(highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save(); 
        }
        SceneManager.LoadScene("main");
    }

    public void IncraseScore()
    {
        score++;
        scoreTex.text = score.ToString();   
    }

    private void OnBecameInvisible()
    {
        if (GameObject.FindGameObjectWithTag("road").transform.position.z < GameObject.FindGameObjectWithTag("Player").transform.position.z)
            Destroy(GameObject.FindGameObjectWithTag("road"), 1f);
    }
}
