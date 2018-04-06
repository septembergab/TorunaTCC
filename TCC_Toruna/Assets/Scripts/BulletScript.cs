using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private Vector2 speed = new Vector2(11, 0);
    private Rigidbody2D rbBullet;

    void Start()
    {

        rbBullet = GetComponent<Rigidbody2D>();
        rbBullet.velocity = speed * this.transform.localScale.x;
        Destroy(gameObject, 1.4f);

    }

    void Update()
    {

    }
}
