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
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 150f, jumpPow = 400f;
    private bool grounded;
    public bool faceright;
    private bool jump;

    private Rigidbody2D rigidBody2d;
    private Animator anim;

    public LayerMask layerMask;
    public Transform GroundCheck;
    public float radius;

    public int health;
    private int maxHealth = 5;

    public Text lifeText;
    // Use this for initialization
    void Start()
    {
        faceright = true;
        rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            health = maxHealth;
        }
        else
        {
            health = PlayerPrefs.GetInt("Life");
        }        
        lifeText.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = isGrounded();        
        jump = Input.GetKeyDown(KeyCode.Space);        
    }

    void FixedUpdate()
    {
        //Get the screen limit
        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));

        //set the screen limit
        max.x = max.x - 1f;
        min.x = min.x + 1f;

        Vector2 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        transform.position = pos;

        float h = Input.GetAxis("Horizontal");

        //if(grounded)
        //{
        //    grounded = true;
            rigidBody2d.velocity = new Vector2(h * speed * Time.deltaTime, rigidBody2d.velocity.y);
            anim.SetFloat("speed", Mathf.Abs(rigidBody2d.velocity.x));

            if (h > 0 && !faceright)
            {
                Flip();
            }

            if (h < 0 && faceright)
            {
                Flip();
            }
        //}

        if (jump && grounded)
        {
            grounded = false;
            rigidBody2d.AddForce(Vector2.up * jumpPow);
            anim.SetTrigger("jump");
        }

        if(rigidBody2d.velocity.y < 0)
        {
            Invoke("setLandBooleanTrue", 0.05f);       
        }

        if(rigidBody2d.velocity.y > 0)
        {
            anim.SetBool("land", false);
        }

        animationLayers();

        if(health <= 0)
        {
            death();
        }
    }

    void setLandBooleanTrue()
    {
        anim.ResetTrigger("jump");
        anim.SetBool("land", true);
    }

    private void Flip()
    {
        faceright = !faceright;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    private bool isGrounded()
    {
        //SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //Vector2 pos = gameObject.transform.position;
        //RaycastHit2D raycastHit2D = Physics2D.Linecast(new Vector2(pos.x, pos.y - (spriteRenderer.bounds.size.y / 2)), new Vector2(pos.x, pos.y - (spriteRenderer.bounds.size.y / 2 + 0.2f)));

        //return raycastHit2D != null && raycastHit2D.collider != null;
        if(rigidBody2d.velocity.y <= 0)
        {
            return Physics2D.OverlapCircle(GroundCheck.position, radius, layerMask);
        }
        return false;
    }

    private void animationLayers()
    {
        if(!grounded)
        {
            anim.SetLayerWeight(1, 1);
        }
        else
        {
            anim.SetLayerWeight(1, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Die"))
        {
            death();
        }
    }

    public void death()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void hurtAnim()
    {
        anim.SetTrigger("hurt");
        StartCoroutine("resetTrigger");
    }    

    public void knockback(float knockPwr, Vector2 knockDir)
    {
        if(faceright)
        {
            rigidBody2d.AddForce(new Vector2(knockDir.x * 30f, knockDir.y * 30f));
        }
        if(!faceright)
        {
            rigidBody2d.AddForce(new Vector2(knockDir.x * -30f, knockDir.y * 30f));
        }
        //rigidBody2d.AddForce(new Vector2(knockDir.x * -30, knockDir.y * knockPwr));
    }

    IEnumerator resetTrigger()
    {
        yield return new WaitForSeconds(1.5f);
        anim.ResetTrigger("hurt");
        yield return 0;
    }
}
