using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{

    [SerializeField] private AudioClip PickUpSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (GameManager.Instance._getLifeBar() < 100))
        {
            SoundManager.Instance._PlaySound(PickUpSound);
            GameManager.Instance._potionTaken(20);
            Destroy(gameObject);
        }
    }
}
