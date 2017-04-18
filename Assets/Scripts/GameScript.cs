using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Class that holds Scipts just for the game itself.
public class GameScript : MonoBehaviour {
    //array of asteroid game objects to choose from
    public Text scoreText;
    private float score = 0;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
        
        
    }
    
    
    //Method to keep track of score
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
        Debug.Log(score);
    }
}
