/*
Member:     Toan Nguyen - 100979753
            Hamad Ahmad - 101006399
            Mentesnot Aboset - 101022050
            Zheng Liu - 100970328

 Source:    https://www.youtube.com/playlist?list=PL2614K6kEvHC37KsgRtqnydn1vQd8uCPy
            https://www.youtube.com/playlist?list=PLq3pyCh4J1B2va_ftIthSpUaQH0LycRA-
            https://www.youtube.com/playlist?list=PLX-uZVK_0K_6VXcSajfFbXDXndb6AdBLO
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text inputText;

    public Text scoreText;

    public int score;

    public PlayerController player;

    public int health;

    public Text lifeText;

    // Use this for initialization
    void Start () {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            score = 0;
        }
        else
        {
            score = PlayerPrefs.GetInt("Score");
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerController>();
        health = player.health;
    }
	
	// Update is called once per frame
	void Update () {
        UpdateScore();
    }

    public void AddScore(int num)
    {
        score += num;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    void UpdateLive()
    {
        lifeText.text = health.ToString();
    }

    public void AddLive()
    {
        health = 5;
        UpdateLive();
    }

    public void LoseLive(int num)
    {
        health -= num;
        UpdateLive();

        if(health <= 0)
        {
            player.death();
        }
    }
}
