using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDestroy : MonoBehaviour
{
    Renderer Renderer;
    private void Awake()
    {
        Renderer = this.GetComponent<Renderer>();
    }

    private void Update()
    {
        if(!Renderer.isVisible)
            Destroy(gameObject, 1f);
    }
}
