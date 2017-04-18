using UnityEngine;
using System.Collections;

/// <summary>
/// Controls the spawnrates for everything in the scene, has the future proofability 
/// of being used continously no matter the add ons
/// </summary>
public class SpawnControl : MonoBehaviour {
    //Variables
    public GameObject[] asteroidPrefabs = new GameObject[10];
    public GameObject[] powerUps = new GameObject[2]; 
    Vector3 location;
    public float spawnRate = 1f;

    // Use this for initialization
    void Start () {
        location = transform.position;

        //Kind of like the update method but a lot more controlled
        StartCoroutine("SpawnRate");
        StartCoroutine("PowerUp");
    }


    // Update is called once per frame
    void Update () {
	
	}

    //PowerUp spawn rate controller
    IEnumerator PowerUp()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(spawnRate);
            Instantiate(powerUps[Random.Range(0, powerUps.Length)], location, Quaternion.identity);
        }
    }



    //Enables me to control how fast or slow asteroids will spawn into the scene
    //Uses real time values, easier to control than trying to play with time variables
    IEnumerator SpawnRate()
    {
        while (true)
        {
            Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], location, Quaternion.identity);
            yield return new WaitForSecondsRealtime(spawnRate);
        }
    }
}
