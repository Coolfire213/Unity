using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreController : MonoBehaviour
{
    private int pscore1 = 0, pscore2 = 0;

    public GameObject playerScore1;
    public GameObject playerScore2;
    public int maxScore;

    // Update is called once per frame
    void Update()
    {
        if (pscore1 >= maxScore)
        {
            PlayerPrefs.SetInt("winner", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("game over");
        }
        else if(pscore2 >= maxScore)
        {
            PlayerPrefs.SetInt("winner", 2);
            PlayerPrefs.Save();
            SceneManager.LoadScene("game over");
        }
    }

    private void FixedUpdate()
    {
        TextMeshProUGUI score1Text = this.playerScore1.GetComponent<TextMeshProUGUI>();
        score1Text.text = this.pscore1.ToString();
        TextMeshProUGUI score2Text = this.playerScore2.GetComponent<TextMeshProUGUI>();
        score2Text.text = this.pscore2.ToString();
    }

    public void UpdatePlayer1()
    {
        this.pscore1++;
    }

    public void UpdatePlayer2()
    {
        this.pscore2++;
    }
}
