using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingParameters : MonoBehaviour
{
    private Rigidbody2D RB;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameManager.Instance._damageTaken(20);
        }
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        

    }
}
