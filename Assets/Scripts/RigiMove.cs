using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//look bewteen the changes of this document and movement. getting rigibody changes the movement, as seen in start and update
//this type of movement is good for marble type games (octo expansion flashbacks...)

public class RigiMove : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody rigi;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigi.AddRelativeForce(0, 0, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigi.AddRelativeForce(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigi.AddRelativeForce(0, 0, -speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigi.AddRelativeForce(speed * Time.deltaTime, 0, 0);
        }
    }
}
