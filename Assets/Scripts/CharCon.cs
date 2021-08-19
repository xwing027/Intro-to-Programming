using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//better way to control objects, regardless of speed you don't have any clipping

public class CharCon : MonoBehaviour
{
    [SerializeField] 
    float speed;
    
    Vector3 movement;
    
    CharacterController charCon;
    
    [SerializeField]
    float mouseSensitivity;
    
    [SerializeField]
    float jumpHeight;
    
    [SerializeField]
    float gravity;

    // Start is called before the first frame update
    void Start()
    {
        charCon = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //moving the mouse turns the character
        transform.Rotate(Vector3.up * mouseSensitivity * Input.GetAxisRaw("Mouse X"));

        movement.z = 0;
        movement.x = 0;

        //this moves the character, and changes rotation to local rather than global (character will still move in the direction you want when rotating)
        movement += transform.forward*Input.GetAxisRaw("Vertical") * speed;
        
        movement += transform.right*Input.GetAxisRaw("Horizontal") * speed;

        if (charCon.isGrounded) // prevents infinite jumping
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Jump");
                movement.y = jumpHeight;
            }
        }
        else
        {
            if (movement.y > -9.8f)
            {
                movement.y -= gravity;
            }
        }
        
        charCon.Move(movement * Time.deltaTime); 
    }
}
