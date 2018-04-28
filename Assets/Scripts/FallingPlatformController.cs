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

public class FallingPlatformController : MonoBehaviour {
    private Rigidbody2D rigidBody2d;
    // Use this for initialization
    void Start () {
        rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
    }
	

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(fall());
            
        }
        if (collision.collider.CompareTag("Die"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator fall()
    {
        yield return new WaitForSeconds(1f);
        rigidBody2d.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;
    }
}
