using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;
    private Rigidbody2D rig; 
    public float mapWidth;
    public Joystick joystick;

    private void Start()
    {  
        rig = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        //float x = joystick.Horizontal;
        Vector2 newPosition = rig.position + Vector2.right * x;
        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
        rig.MovePosition(newPosition);

        


    }

}
