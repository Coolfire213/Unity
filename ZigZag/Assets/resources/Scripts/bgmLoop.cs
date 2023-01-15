using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmLoop : MonoBehaviour
{
    public static bgmLoop bgm;

    private void Awake()
    {
        if(bgm == null)
            bgm = this;
        else if(bgm != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
