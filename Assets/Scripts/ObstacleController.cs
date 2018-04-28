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

public class ObstacleController : MonoBehaviour {
    public PlayerController player;

    public GameController gameController;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerController>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            gameController.LoseLive(1);
            player.hurtAnim();
            player.knockback(20f, player.transform.position);
        }
    }

}
