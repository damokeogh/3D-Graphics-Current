using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody2D rb2D;
    private int count;

    private void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();

    }

    private void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2D.AddForce(movement * speed);


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }



    }

    void SetCountText()
    {

        countText.text = "Count: " + count.ToString();

        if (count >= 8)
        {
            winText.text = "YOU WIN";
        }

    }


}
