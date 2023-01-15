using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camController : MonoBehaviour
{
    public Transform camTransform;
    private Vector3 camPosition;

    // Start is called before the first frame update
    void Awake()
    {
        camPosition = transform.position - camTransform.position;   
    }

    private void LateUpdate()
    {
        transform.position = camTransform.position + camPosition;
    }
}
