using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_P_Cam : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1;
    public Transform Target, Player;
    private float mouseX, mouseY;

    [SerializeField] private Sprinkle _sprinkle;

    // TODO DECOMMENT IN FINAL VERSION
    /*void Start()
    {
        // make cursor invisible and locked to middle of screen
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    */
    
    // LateUpdate is called after Update functions have been called
    private void LateUpdate()
    {
        CamControl();
    }

   void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * _rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * _rotationSpeed;
        // prevents cam from flipping around
        mouseY = Mathf.Clamp(mouseY, -35f, 30f);
        
        // keep cam focused on target
        mouseY -= Input.GetAxis("Mouse Y") * _rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, 5f, 60f);
        transform.LookAt(Target);

        // only move camera when LeftShift is pressed
        // otherwise move both cam and player
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
        }
        else
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
            Player.rotation = Quaternion.Euler(0f, mouseX, 0f);
            
            _sprinkle.getDirection(mouseX);
        }
    } 
}
