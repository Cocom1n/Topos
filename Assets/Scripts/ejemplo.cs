using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ejemplo : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpSpeed = 1.0f;
    public GameObject bullet;
    public Transform spanwPoint;
    public GameObject player;
    public float speedBullet = 10.0f;
    public SpriteRenderer sp;
    public Rigidbody2D rb;
    public GameObject gameover;
    public Animator anim;
    public bool isJump = false;

    public bool isheight = false;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        transform.Translate(inputX * Time.deltaTime * speed, 0, 0);
        anim.SetBool("cominando", inputX != 0);
        if ( inputX != 0) {
            sp.flipX = inputX < 0;
        }
        /*
        if (GetComponent<SpriteRenderer>().flipX)
        {
            spanwPoint.position = transform.position + new Vector3(-2, 0);
        }
        else {
            spanwPoint.position = transform.position + new Vector3(2, 0);
        }
        */

        if (!isJump &&(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }

        var fliptemp = GetComponent<SpriteRenderer>().flipX;
        spanwPoint.position = (fliptemp == true) ? transform.position + new Vector3(-2, 0) : transform.position + new Vector3(2, 0);

        if (Input.GetKeyDown(KeyCode.L))
        {
            var temp = Instantiate(bullet, spanwPoint.position, Quaternion.identity);
            var flipX = GetComponent<SpriteRenderer>().flipX;
            var direction = (flipX == false) ? 1 : -1;
            temp.GetComponent<Rigidbody2D>().AddForce(player.transform.right * speedBullet * direction);
            Destroy(temp, 5.5f);
        }

    }

    private void FixedUpdate()
    {
        /*
        if (Input.GetKeyDown(KeyCode.W)) {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
        */

        /*
        if (Input.GetKeyDown(KeyCode.L)) { 
            var temp = Instantiate(bullet,spanwPoint.position,Quaternion.identity);
            temp.GetComponent<Rigidbody2D>().AddForce(-player.transform.forward * speedBullet);
            Destroy(temp,5.5f);
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "item") {
            Destroy(collision.gameObject);
        }

        if (collision.tag == "zombie") {
            gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D otroObjeto)
    {
 

        if (otroObjeto.gameObject.tag == "piso")
        {
            isJump = false;

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "piso") {
            isJump = true;
        }
    }
}
