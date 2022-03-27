using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    bool isGrounded = false;

    int extraJump = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello, World!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            body.velocity = new Vector3(body.velocity.x, body.velocity.y, speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            body.velocity = new Vector3(body.velocity.x, body.velocity.y, -speed);
        }



        if (Input.GetKey(KeyCode.D))
        {
            body.velocity = new Vector3(speed, body.velocity.y, body.velocity.z);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            body.velocity = new Vector3(-speed, body.velocity.y, body.velocity.z);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                body.AddForce(Vector3.up * jumpForce);
            }
            else if (extraJump > 0)
            {
                body.AddForce(Vector3.up * jumpForce);
                extraJump = extraJump - 1;
            }

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Spike")
        {
            Destroy(gameObject);
        }
        else if (other.collider.tag == "Ground")
        {
            isGrounded = true;
            extraJump = 1;
        }
    }

    /* void OnCollisionStay(Collision other)
    {
        Debug.Log(other.collider.gameObject.name + " a çarpıyoruz");
    } */

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Area")
        {
            Debug.Log("Bölge Feth ediliyor...");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
