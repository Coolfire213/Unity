using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class game : MonoBehaviour
{
    public GameObject objectToSpawn;
    //public GameObject tempText;

    // Start is called before the first frame update
    void Start()
    {
        objectToSpawn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        pCheck();
    }

    public void pCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                objectToSpawn.SetActive(true);

            }
            else
            {
                Time.timeScale = 1;
                objectToSpawn.SetActive(false);
            }
        }
    }


}
