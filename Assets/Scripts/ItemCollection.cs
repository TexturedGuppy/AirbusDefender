using UnityEngine;
using System.Collections;

//Class that controls the collision detection and what happens when you collide with powerups or other non hostile items
public class ItemCollection : MonoBehaviour {
    private LifeManager life;
    public bool bPowerUp;

    // Use this for initialization
    void Start () {
        bPowerUp = false;
        life = FindObjectOfType<LifeManager>();

    }

    // Update is called once per frame
    void Update () {

    }

    //Method to check for collisions and then perform certain things based on what you collide with
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "PowerUp")
            {
            bPowerUp = true;
                Debug.Log("collided with powerup");
            DestroyObject(GameObject.FindWithTag("PowerUp"));
            }


        if (collision.gameObject.tag == "1up")

            {
                Debug.Log("collided with 1up");
                life.GainLife();
                DestroyObject(GameObject.FindWithTag("1up"));


        }
    }
     
}
