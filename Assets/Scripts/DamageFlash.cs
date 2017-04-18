using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Class used to make player blink when colliding with hostile units
public class DamageFlash : MonoBehaviour {
    //Variables
    private LifeManager life;
    float invincibleTimer = 2.0f;
    private bool bInvincible = false;
    SpriteRenderer rend;
    Color alpha0 = new Color(1f, 1f, 1f, 0f);
    Color alpha1 = new Color(1f, 1f, 1f, 1f);
    float aSpeed = 10.0f;
    // Use this for initialization
    void Start () {
        rend = GetComponent<SpriteRenderer>();
        life = FindObjectOfType<LifeManager>();


    }

    // Update is called once per frame
    void Update () {
        blink();
        
    }

    //Collision method to determine when losing a life
    //Then making player invincible for specified amount of time
    void OnCollisionEnter2D(Collision2D collision)
    {
       

        if (!bInvincible)
        {
            if (collision.gameObject.tag == "Hostile")
            {
                life.LoseLife();

                Debug.Log("collided with Hostile");
                bInvincible = true;
                Invoke("resetInvinc", invincibleTimer);
            }

           
                
        }
    }

    //Special Thanks to Unity user robertbu for inspiring me to read up on Mathf and PingPong
    //Causes player icon to blink at a specified speed once hit
    //Mathf.PingPong causes numbers to "pingpong" back and forth between a certain value and a specified length
    //Lerp after reading up on the color class, just makes the colors bounce between two different values
    //Set my values both to "white" but change there alpha values to cause the sprite to have the blinking effect. 
    void blink()
    {
        if (bInvincible)
            rend.color = Color.Lerp(alpha0, alpha1, Mathf.PingPong(Time.time * aSpeed, 1.0f));
    }

    void resetInvinc()
    {
        bInvincible = false;
        rend.color = new Color(1f, 1f, 1f, 1f);
    }



}
