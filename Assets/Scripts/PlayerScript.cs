using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

     private Rigidbody2D rd2d;
     public float speed;
    public Text score;
    public Text WinText;
    private int scoreValue = 0;
    private int lives = 3;
    public Text LivesText;
    public AudioClip musicClipTwo; 
    public AudioSource musicSource;
   

    // Start is called before the first frame update
    void Start()
    {
       {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        WinText.text = " ";
       LivesText.text = lives.ToString();      
       lives = 3;
       SetLivesText();
       }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
           score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            if (scoreValue == 4)
            {
                WinText.text = "You Win! Created by Alexander Corliss";
                
            }
        }
         else if (collision.collider.tag == ("Enemy"))
        {
            Destroy(collision.collider.gameObject);
            lives = lives - 1;  
            SetLivesText();
        }  
    
    }   


    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3),ForceMode2D.Impulse);
            }
        }
    }
    
void SetLivesText ()
    {
        LivesText.text = "Lives: " + lives.ToString ();
        if (lives == 0)
        {
            Destroy(this.gameObject);
            WinText.text = "You Lose...";

            if (Input.GetKey("escape"))
            {
            Application.Quit();
            }
        }
    }

    void update()
    {
        if (scoreValue == 4)
        {
             musicSource.clip = musicClipTwo;

          musicSource.Play();
        }
    }
}
 