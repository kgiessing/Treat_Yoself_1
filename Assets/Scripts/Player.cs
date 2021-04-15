using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 13f;
    // TODO make donut spin
    [SerializeField] private float _spinSpeed = 500f;
    [SerializeField] private float _jumpStrength = 50f;
    public bool isGrounded;

    // Sprinkle attack
    [SerializeField] private float _shootRate = 0.2f;
    [SerializeField] private float _timeToShoot = -0.5f;
    public GameObject sprinklePrefab;
    private void Update()
    {
        //TODO cam spins because it targets the player! FIX THIS
        //transform.Rotate(Vector3.right * _spinSpeed * Time.deltaTime);
        PlayerMovement();
        PlayerJump();
        PlayerShoot();
        // Rotate();
        
    }

    /*public void Rotate()
    {
        transform.Rotate(30f, 0f, 0f, Space.Self);
    }
    */
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

    void PlayerShoot()
    {
        if(Input.GetKey(KeyCode.Mouse0) && Time.time > _timeToShoot)
        {
            Debug.Log("Firebutton pressed!");
            _timeToShoot = Time.time + _shootRate;
            Instantiate(sprinklePrefab,
                transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
        }
    }
}
