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
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour {

    public GameController gameController;
    private int sceneIndex;
    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (sceneIndex == 3)
            {
                gameController.inputText.text = "Congratulation! You found the treasure. Press E to continue.";
            }
            else
            {
                gameController.inputText.text = "Press E to continue.";
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(sceneIndex == 3)
            {
                SceneManager.LoadScene("Win");
            }
            else
            {
                SceneManager.LoadScene(sceneIndex + 1);                
            }
            PlayerPrefs.SetInt("Score", gameController.score);
            PlayerPrefs.SetInt("Life", gameController.health);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameController.inputText.text = "";
        }
    }
}
