using UnityEngine;
using System.Collections;

//My laser class, Poor name choice to be general, but Unity makes it a pain to change names.
public class laserBlue01 : MonoBehaviour {

    //Variables
    public int lifeTime = 2;
    float spawnTime;
    public float bulletSpeed = .1f;
    public int damage = 20;

    // Use this for initialization
    void Start()
    {
        //set a spawn timer for the lasers
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, Time.deltaTime * bulletSpeed, 0));//always use time.deltaTime * speed to make up for computers with bad framerate.
        if (Time.time - spawnTime > lifeTime)
        {

            //Destroy(this);//This points to the component, Not the gameobject its attached to
            Destroy(gameObject);
        }
    }

    //Looks for unit collision
    //Checks to see if lasers hit a hostile unit
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hostile")
        {
            Debug.Log("collided with Hostile");
            //Or
            //Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();
            //asteroid.TakeDamage(damage);
            collision.gameObject.SendMessage("TakeDamage", damage);
            Destroy(gameObject);
        }
    }

    //Trigger Method left over from in class assignments I never used
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Triggered");
    }

}
