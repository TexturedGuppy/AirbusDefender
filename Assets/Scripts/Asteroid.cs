using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
    //Variable Declarations
    public int pointValue = 10;
    int health;
    Vector2 direction;
    float rotation;
    Rigidbody2D rb;
    float spawnTime;
    public float lifeTime = 2;
    Vector3 position;

    // Use this for initialization
    void Start()
    {
        position = transform.position;
        health = Random.Range(1, 100);

        ///Two if statements basically check to see loosely where the spawn points are at
        ///This in turn changes the direction so that it doesn't send asteroids in directions 
        ///that don't make sense, like just completely away from the viewing window.
        if (position.x > 1)
        {
            direction = new Vector3(Random.Range(-0.05f, .0f), Random.Range(-.05f, .05f));
        }
        if (position.x < 1)
        {
            direction = new Vector3(Random.Range(-.05f, .05f), Random.Range(-.05f, .0f));

        }

        //Variable initializers
        rotation = Random.Range(-.5f, .5f);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * Random.Range(100000,1000000));
        spawnTime = Time.time;

    }


    // Update is called once per frame
    void Update()
    {
        //Controls rotation of asteroids
        transform.Rotate(Vector3.forward, rotation);

        //Despawns asteroids to control game performance
        if (Time.time - spawnTime > lifeTime)
        {
            Debug.Log("Asteroid Time Out");
            Destroy(gameObject);
        }

        
    }

    //Controls the damage for the asteroids, once they have no HP they get destroyed
    //Left audio to work destruction noise, couldn't get it to work correctly with an object that gets destoryed
    void TakeDamage(int dmg)
    {
        AudioSource explosion = GetComponent<AudioSource>();

        AudioClip clip;
        health -= dmg;
        if (health <= 0)
        {
            
            Debug.Log("Asteroid Lost all Health");
            Destroy(gameObject);
            GameScript gameScript = FindObjectOfType<GameScript>();
            gameScript.AddScore(pointValue);
            //explosion.PlayClipAtPoint(clip,Vector3.zero);
            //explosion.Play(44100);


        }
    }
}
