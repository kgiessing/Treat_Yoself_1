using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Spin : MonoBehaviour
{

    [SerializeField] private float _spinSpeed = 40;
    // Update is called once per frame
    // this is just a test 
    void Update()
    {
        transform.Rotate(Vector3.right * _spinSpeed * Time.deltaTime);
    }
}
