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

public class PauseMenuController : MonoBehaviour {

    public bool pause = false;
    public GameObject pauseUI;
    
	// Use this for initialization
	void Start () {
        pauseUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }

        if(pause)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if(pause == false)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
	}

    public void resume()
    {
        pause = false;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit(string name)
    {
        SceneManager.LoadScene(name);
    }
}
