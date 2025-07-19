using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (GameManager.Instance._getLifeBar() < 100))
        {
            Destroy(gameObject);
            GameManager.Instance._potionTaken(20);
        }
    }
}
