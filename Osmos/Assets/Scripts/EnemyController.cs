using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private CircleCollider2D circle;
    private float moveHorizontal;
    private float moveVertical;
    private float radius;
    private SpriteRenderer enemyRenderer;



    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
        enemyRenderer = GetComponent<SpriteRenderer>();

        //set random speed and direction to mote
        moveHorizontal = Random.Range(-1, 1);
        moveVertical = Random.Range(-1, 1);

        //set random size to mote
        radius = Random.Range(1, 6);
        Vector3 scale = new Vector3(radius, radius);

        ////set collider radius = to sprite radius
        //circle.radius = radius;

        //set mass to radius
        rb2d.mass = radius;

        transform.localScale = scale;

    }

    private void FixedUpdate()
    {
        EnemyMovement();
        ColourCheck();
    }

    private void EnemyMovement()
    {
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement);
    }

    //function to make mote the correct colour
    private void ColourCheck()
    {
        if( radius > playerController.size)
        {
            enemyRenderer.color = Color.red;
        }
        if(radius <= playerController.size)
        {
            enemyRenderer.color = Color.yellow;
        }

    }

}
