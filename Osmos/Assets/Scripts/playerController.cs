using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    private Rigidbody2D rb2d;

    public float speed;
    public float size;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        size = 3;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

        Vector3 scale = new Vector3(size, size);
        transform.localScale = scale;

    }

}
