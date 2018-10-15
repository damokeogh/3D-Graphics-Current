using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private float speed;
    public static float size;
    private Vector2 movement;
    GameObject player;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        size = 2;
        speed = 10;   
    }

    private void FixedUpdate()
    {

        PlayerMove();
        PlayerScale();
        

    }

    private void PlayerMove()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    private void PlayerScale()
    {
        Vector3 scale = new Vector3(size, size);
        transform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && other.otherRigidbody.mass <= size)
        {
            other.gameObject.SetActive(false);
            size++;

        }


        if (other.gameObject.CompareTag("Enemy") && other.otherRigidbody.mass > size)
        {
            gameObject.SetActive(false);

        }

    }



}
