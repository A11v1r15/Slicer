using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rigidbody3D;
    public float JumpSpeed = 5;
    private bool goingDown = false;

    // Use this for initialization
    void Start()
    {
        rigidbody3D = gameObject.GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goingDown)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - JumpSpeed * Time.deltaTime, transform.position.z);
        }
        else if(transform.position.y < 0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + JumpSpeed * Time.deltaTime, transform.position.z);
        }
        if (transform.position.y < -3f)
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().mute = true;
            PlataformGenerator.GameOver.SetActive(true);
        }
    }

    void OnMouseDown()
    {
        Debug.Log("cliq");
        if (!PlataformGenerator.GameOver.activeSelf)
        {
            goingDown = true;
        }
    }
    void OnMouseUp()
    {
        if (!PlataformGenerator.GameOver.activeSelf)
        {
            goingDown = false;
        }
    }
}