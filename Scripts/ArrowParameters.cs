using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowParameters : MonoBehaviour
{

    public float arrowSpeed;
    private Rigidbody2D RB;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        RB.velocity = transform.right * arrowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy._TakeDamageEnemy(1);
            Destroy(gameObject);
        }

    }
    
}
