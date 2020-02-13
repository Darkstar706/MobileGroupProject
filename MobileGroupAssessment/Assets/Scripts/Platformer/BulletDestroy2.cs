using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy2 : MonoBehaviour
{
    public float particleLifeTime = 1.0f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
