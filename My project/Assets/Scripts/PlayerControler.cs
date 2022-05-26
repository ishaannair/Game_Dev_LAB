using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//  using UnityEngine.SceneManagement;
public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=70;
     public float maxSpeed = 10;
    public float upSpeed = 10;
    private Rigidbody2D marioBody;
    private SpriteRenderer marioSprite;
    private bool faceRightState = true;
    private bool onGroundState = true;

    public Transform enemyLocation;
    public Text scoreText;

    private bool collision_with_enemy=false;

    private int score = 0;
    private bool countScoreState = false;
    // Start is called before the first frame update
    void  Start()
    {
        // Set to be 30 FPS
        Application.targetFrameRate =  30;
        marioBody = GetComponent<Rigidbody2D>();
        marioSprite = GetComponent<SpriteRenderer>();
    }
    // void  FixedUpdate()
    // {
    //     float moveHorizontal = Input.GetAxis("Horizontal");
    //     Vector2 movement = new Vector2(moveHorizontal, 0);
    //     marioBody.AddForce(movement * speed);
    // }
      // FixedUpdate may be called once per frame. See documentation for details.
  void FixedUpdate(){
      // dynamic rigidbody
            float moveHorizontal = Input.GetAxis("Horizontal");
            if (Mathf.Abs(moveHorizontal) > 0){
                Vector2 movement = new Vector2(moveHorizontal, 0);
                if (marioBody.velocity.magnitude < maxSpeed)
                        marioBody.AddForce(movement * speed);
            }
            if (Input.GetKeyUp("a") || Input.GetKeyUp("d")){
                // stop
                marioBody.velocity = Vector2.zero;
            }
            if (Input.GetKeyDown("space") && onGroundState){
                marioBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
                onGroundState = false;
                  countScoreState = true; 
                  //check if Gomba is underneath
            }

  }
    void OnTriggerEnter2D(Collider2D other)
  {
      if (other.gameObject.CompareTag("Enemy"))
      {
          Debug.Log("Collided with Gomba!");
          collision_with_enemy=true;
      }
  }
  void OnCollisionEnter2D(Collision2D col)
  {



      if (col.gameObject.CompareTag("Ground"))
      {
          Debug.Log("Collided with ground!");
          onGroundState = true; // back on ground
          countScoreState = false; // reset score state
          scoreText.text = "Score: " + score.ToString();
      }

  }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a") && faceRightState){
          faceRightState = false;
          marioSprite.flipX = true;
      }

        if (Input.GetKeyDown("d") && !faceRightState){
          faceRightState = true;
          marioSprite.flipX = false;
      }
         // when jumping, and Gomba is near Mario and we haven't registered our score
      if (!onGroundState && countScoreState)
      {
        //   Debug.Log("doing maths");
          if (Mathf.Abs(transform.position.x - enemyLocation.position.x) < 0.5f)
          {
            //   Debug.Log("doing maths");
              countScoreState = false;
              score++;
              Debug.Log(score);
          }

        
      }
    if (collision_with_enemy)
         {
             Application.LoadLevel(0);
         }
    }

}
