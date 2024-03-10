using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody2D ArkBallRB;
    [SerializeField]
    float speed = 1f;
    [SerializeField]
    float maxSpeed = 1000f;
 
    private void Start()                                        
    {
        ArkBallRB = GetComponent<Rigidbody2D>();
        Vector2 vec = new Vector2(Random.Range(-5f, 5f), Random.Range(2f, 4f) );
        ArkBallRB.velocity = vec * speed ;       
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -6f)
        {
            DestroyBall();
        }

        if(ArkBallRB.velocity.magnitude > maxSpeed)
        {
            ArkBallRB.velocity = ArkBallRB.velocity.normalized * maxSpeed;
        } 
         else if(ArkBallRB.velocity.magnitude < maxSpeed)
        {
            ArkBallRB.velocity = ArkBallRB.velocity.normalized * maxSpeed;
        }      
    }

    void DestroyBall()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        FindObjectOfType<GameManager>().Restartlvl();
    }
}
