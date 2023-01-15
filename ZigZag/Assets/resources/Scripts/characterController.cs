using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    private GameManager gameManager;
    public Transform characterTransform;
    private Rigidbody rb;
    private bool walkRight = true;
    private Animator animator;
    public GameObject particle;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (!gameManager.isGameStart)
        {
            return;
        }
        else
            animator.SetTrigger("isStart");

        rb.transform.position = transform.position + transform.forward * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwitchDir();
        }

        if(!Physics.Raycast(characterTransform.position, -transform.up, out RaycastHit hit, Mathf.Infinity))
        {
            //animator.SetTrigger("isFalling");
            animator.SetBool("isFall", true);
        }
        else
        {
            animator.SetBool("isFall", false);
        }

        if (transform.position.y < -5)
            gameManager.Restart();
    }

    void SwitchDir()
    {
        if (!gameManager.isGameStart)
            return;

        walkRight = !walkRight;
        if(walkRight)
            transform.rotation = Quaternion.Euler(0,45,0);
        else
            transform.rotation = Quaternion.Euler(0,-45,0); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("crystal"))
        {
            gameManager.IncraseScore();
            GameObject tempPart = Instantiate(particle, other.transform.position, Quaternion.identity);
            Destroy(tempPart, 1.5f);
            Destroy(other.gameObject);
        }
    }
}
