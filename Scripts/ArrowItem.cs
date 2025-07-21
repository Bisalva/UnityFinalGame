using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowItem : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (GameManager.Instance._getArrowsAmount() < 5))
        {
            Destroy(gameObject);
            GameManager.Instance._takeArrow();
        }
    }
}
