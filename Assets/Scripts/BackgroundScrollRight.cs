using UnityEngine;
using System.Collections;

//Script that controls how the background moves
public class BackgroundScrollRight : MonoBehaviour {

    //Speed of Background scrolling
    public float speed = 0.5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 offset = new Vector2(0, -Time.time * speed);

        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
