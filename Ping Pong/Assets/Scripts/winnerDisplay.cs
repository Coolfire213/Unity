using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class winnerDisplay : MonoBehaviour
{
    public TextMeshProUGUI wText;

    // Start is called before the first frame update
    void Start()
    {
        CheckWinner();
    }

    void CheckWinner()
    {
        int w = PlayerPrefs.GetInt("winner");
        if(w == 1)
        {
            wText.text = "Player 1 wins the game";
        }
        else
        {
            wText.text = "Comp wins the game";
        }
    }

}
