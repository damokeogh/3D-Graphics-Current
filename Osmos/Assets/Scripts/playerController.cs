using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

    public static float size;

    public Text WinText;

    private int score;
    private Rigidbody2D rb2d;
    private float speed;
    private Vector2 movement;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        size = 2;
        speed = 10;
        score = 0;
        WinText.text = "";

    }

    private void FixedUpdate()
    {

        PlayerMove();
        PlayerScale();
        CheckWin();

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

    private void CheckWin()
    {
        if(score == 21)
        {
            WinText.text = "YOU WIN";
            
        }
    

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && other.rigidbody.mass <= size)
        {
            other.gameObject.SetActive(false);
            size = size + 0.5f;
            score++;

        }


        if (other.gameObject.CompareTag("Enemy") && other.rigidbody.mass > size)
        {
            this.gameObject.SetActive(false);

        }

    }



}
