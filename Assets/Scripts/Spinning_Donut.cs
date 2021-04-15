using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning_Donut : MonoBehaviour
{
    [SerializeField] private float _spinSpeed = 40;
    [SerializeField] private float _speed = 13f;
    
    [SerializeField] private float _jumpStrength = 50f;
    public bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * _spinSpeed * Time.deltaTime);
        PlayerJump();
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(horizontal, 0f, vertical) * _speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }

    void PlayerJump()
    {
        // only let player jump when on ground
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpStrength);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("is grounded!");
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

}
