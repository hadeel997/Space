using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidMovement : MonoBehaviour
{
    [Header("control the speed of the Astroid")]
    public float maxspeed;
    public float minspeed;

    [Header("control the rotational speed")]
    public float rotationalSpeedMin;
    public float rotationalSpeedMax;

    private float rotationalSpeed;
    private float xAngle, yAngle, zAngle;


    public Vector3 movmentDirection;

    private float astroidSpeed;
    // Start is called before the first frame update
    void Start()
    {
        astroidSpeed= Random.Range(minspeed,maxspeed);
        
        xAngle = Random.Range(0,360);
        yAngle = Random.Range(0,360);
        zAngle = Random.Range(0,360);

        transform.Rotate(xAngle,yAngle,zAngle); 
        
        rotationalSpeed=Random.Range(rotationalSpeedMin, rotationalSpeedMax);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movmentDirection * Time.deltaTime * astroidSpeed,Space.World);
        transform.Rotate(Vector3.up * Time.deltaTime * rotationalSpeed);
    }
}
