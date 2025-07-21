using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingParameters : MonoBehaviour
{
    private Rigidbody2D RB;
    [SerializeField] private AudioClip DamageSoundPlayer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            GameManager.Instance._damageTaken(20);
            SoundManager.Instance._PlaySound(DamageSoundPlayer);
            Destroy(gameObject);

        }
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }



    }
}
