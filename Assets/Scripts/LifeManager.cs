using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Script that manages how many lives a player has
//Also displays to the UI how many lives a player has.
public class LifeManager : MonoBehaviour {
    //Variables
    public int startingLives = 3;
    private int lifeCount;
    private Text t;

	// Use this for initialization
	void Start () {
        t = GetComponent<Text>();
        lifeCount = startingLives;
	} 
	
	// Update is called once per frame
	void Update () {
        t.text = "x " + lifeCount;
	}
    //Lose a life
    public void LoseLife()
    {
        lifeCount--;
        if (lifeCount == -1)
            SceneManager.LoadScene(0);
    }

        



    //Gain a life
    public void GainLife()
    {
        lifeCount++;
    }

}
