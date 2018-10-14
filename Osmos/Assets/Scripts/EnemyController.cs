using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private float moveHorizontal;
    private float moveVertical;
    private float radius;



    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        moveHorizontal = Random.Range(-10, 10);
        moveVertical = Random.Range(-10, 10);
        radius = Random.Range(0, 8);
        Vector3 scale = new Vector3(radius, radius);
        transform.localScale = scale;

    }

    private void FixedUpdate()
    {

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement);
    }
}
