using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsummableMushroomSimple : MonoBehaviour
{
    // Start is called before the first frame update

    // private float maxOffset = 5.0f;
    private float mushroomPatroltime = 2.0f;
    private int moveRight = -15;
    private Vector2 velocity;

    public float upSpeed = 20;
    private bool collision_with_obsticle=false;
    private Rigidbody2D mushroomBody;
    private float originalX = 0.0f;
    void Start()
    {
        mushroomBody = GetComponent<Rigidbody2D>();
      // get the starting position
        originalX = transform.position.x;
        ComputeVelocity();
        mushroomBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
    }
    void ComputeVelocity(){
        velocity = new Vector2((moveRight) / mushroomPatroltime, 0);
    }
    void MoveMushroom(){
        mushroomBody.MovePosition(mushroomBody.position + velocity * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {

          MoveMushroom();
      
    }


    void OnTriggerEnter2D(Collider2D other)
  {
            if (other.gameObject.CompareTag("Obstacles")){
                collision_with_obsticle=true;
              
                moveRight *= -1;
                ComputeVelocity();

                Debug.Log("Collided with pipe!");

      }
        
            if (other.gameObject.CompareTag("Mario")){
                collision_with_obsticle=true;
              
                moveRight *= 0;
                ComputeVelocity();

                Debug.Log("Collided with Mario!");

      }


      
  }
    void  OnBecameInvisible(){
        Destroy(gameObject);	
    }
}
