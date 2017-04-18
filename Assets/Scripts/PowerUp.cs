using UnityEngine;
using System.Collections;

//Small PowerUp script to control where it spawns at, and destorys the object after a given amount of time
public class PowerUp : MonoBehaviour {

    float spawnTime;
    public float lifeTime = 2;
    Vector3 position;
    public float speed = .1f;

    // Use this for initialization
    void Start()
    {
        position = transform.position;
       
        

        

        //direction = new Vector3(Random.Range(-.05f, .05f), Random.Range(-.05f, .05f));
        spawnTime = Time.time;

    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTime > lifeTime)
        {
            Debug.Log("PowerUp Timeout");
            Destroy(gameObject);
        }

        transform.position += new Vector3(0,-Time.deltaTime * speed,0);



    }

   
}
