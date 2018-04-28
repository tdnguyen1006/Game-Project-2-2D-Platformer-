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

public class MaceController : MonoBehaviour {

    public float speed = 0.05f, changeDirection = -1;
    private Vector3 Move;

    public PauseMenuController pause;

    public PlayerController player;

    public GameController gameController;

    // Use this for initialization
    void Start()
    {
        Move = this.transform.position;
        pause = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<PauseMenuController>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerController>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(pause.pause)
        {
            this.transform.position = this.transform.position;
        }
        if(pause.pause == false)
        {
            Move.y -= speed;
            this.transform.position = Move;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            speed *= changeDirection;
        }
        
        if(col.collider.CompareTag("Player"))
        {
            gameController.LoseLive(1);
            player.hurtAnim();
            player.knockback(20f, player.transform.position);
        }
    }


}
