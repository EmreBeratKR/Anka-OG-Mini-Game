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

    private bool isForward
    {
        get
        {
            return Input.GetKey(KeyCode.W);
        }
    }

    private bool isBackward => Input.GetKey(KeyCode.S);
    private bool isRight => Input.GetKey(KeyCode.D);
    private bool isLeft => Input.GetKey(KeyCode.A);
    private bool isJump => Input.GetKeyDown(KeyCode.Space);


    public float GetSpeed()
    {
        return body.velocity.magnitude;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello, World!");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Rotate();
    }

    private void Move()
    {
        if (isForward)
        {
            body.velocity = new Vector3(body.velocity.x, body.velocity.y, speed);
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (isBackward)
        {
            body.velocity = new Vector3(body.velocity.x, body.velocity.y, -speed);
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        if (isRight)
        {
            body.velocity = new Vector3(speed, body.velocity.y, body.velocity.z);
            transform.localEulerAngles = new Vector3(0, 90, 0);
        }
        else if (isLeft)
        {
            body.velocity = new Vector3(-speed, body.velocity.y, body.velocity.z);
            transform.localEulerAngles = new Vector3(0, 270, 0);
        }
    }

    private void Jump()
    {
        if (isJump)
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

    private void Rotate()
    {
        if (isForward && isRight)
        {
            transform.localEulerAngles = Vector3.up * 45;
            return;
        }
        if (isForward && isLeft)
        {
            transform.localEulerAngles = Vector3.up * 315;
            return;
        }
        if (isForward && !isLeft && !isRight)
        {
            transform.localEulerAngles = Vector3.up * 0;
            return;
        }

        if (isBackward && isRight)
        {
            transform.localEulerAngles = Vector3.up * 135;
            return;
        }
        if (isBackward && isLeft)
        {
            transform.localEulerAngles = Vector3.up * 225;
            return;
        }
        if (isBackward && !isLeft && !isRight)
        {
            transform.localEulerAngles = Vector3.up * 180;
            return;
        }

        if (isRight)
        {
            transform.localEulerAngles = Vector3.up * 90;
            return;
        }

        if (isLeft)
        {
            transform.localEulerAngles = Vector3.up * 270;
            return;
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
