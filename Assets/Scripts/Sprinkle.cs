using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinkle : MonoBehaviour
{
    public Vector3 forwardedVector;
    //public Vector3 forwardedVectorTwo;
    [SerializeField] private float _sprinkleSpeed = 15f;

    private void Start()
    {
        
    }

    void Update()
    {
        // to shoot in the direction, where the player is looking (rotation of donut)
        // when mouse moves, donut moves
        
        transform.Translate(forwardedVector * _sprinkleSpeed * Time.deltaTime);
        
        /*if (transform.position.x > 10f)
        {
            Destroy(this.gameObject);
        }
    */}

    public void getDirection(float playerRotationTwo)
    {
        forwardedVector = Quaternion.Euler(0, playerRotationTwo, 0f) * Vector3.forward;
    }
}
