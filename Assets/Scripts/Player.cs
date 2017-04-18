using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    //Variable Declarations
    public ItemCollection p;
    public GameObject[] lasers = new GameObject[2];
    public float fireRate = 2;//bullets per second
    public float speed = .05f * Time.deltaTime;
    private float fireTime = float.MinValue;
   
    
    // Use this for initialization
    void Start () {
        p = FindObjectOfType<ItemCollection>();
        //powerbool = p.bPowerUp;

    //rend = GetComponent<SpriteRenderer>();

}

// Update is called once per frame
void Update () {

        faceMouse();
        fire();
        movement();
        

    }

    //Controls all the movement
    void movement()
    {
       Vector3 translation = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
            translation += new Vector3(0, .1f, 0);

        if (Input.GetKey(KeyCode.S))
            translation += new Vector3(0, -.1f, 0);

        if (Input.GetKey(KeyCode.A))
            translation += new Vector3(-.1f , 0, 0);

        if (Input.GetKey(KeyCode.D))
            translation += new Vector3(.1f, 0, 0);

        //Normalize "normalizes" the vectors all to the same value
        //This enables my player to travel diagonally at the correct speed
        translation.Normalize();
        translation *= speed;
        transform.position += translation;

    }
    
    //Function that forces the player's ship to always face the mouse.    
    public void faceMouse()
    {
        //Special Thanks to Munchy2007 in the Unity Forums for these two lines of code.
        //http://answers.unity3d.com/questions/599271/rotating-a-sprite-to-face-mouse-target.html
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position);
    }

    //Function to fire ship's laser gun
    //Will change to more powerful red laser after checking to see if powerup boolean is true
    void fire()
    {

        AudioSource laser = GetComponent<AudioSource>();
        if (gameObject.GetComponent<ItemCollection>().bPowerUp)
        {


            if (Time.time - fireTime > 1 / fireRate && Input.GetMouseButton(0))

            {
                fireRate = 12;
                fireTime = Time.time;
                GameObject newLaser = (GameObject)Instantiate(lasers[1], transform.position, transform.rotation);
                laser.Play();
                laser.Play(44100);

            }
        }

        //shortcircuiting: if we aren't pressing mouse(0) we dont need to check the time
        if (Time.time - fireTime > 1 / fireRate && Input.GetMouseButton(0))
        {
            fireTime = Time.time;
            GameObject newLaser = (GameObject)Instantiate(lasers[0], transform.position, transform.rotation);
            laser.Play();
            laser.Play(44100);
        }

    }




}






       



