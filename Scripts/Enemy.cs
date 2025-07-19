using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //LIFES
    public int lifes;
    public GameObject hitParticles;

    //-----

    //MOVEMENT
    private Vector2 initialPosition;
    private bool DoneTrayectory;
    public int distance;
    public int speedEnemy;
    public bool orientation;
    //-----


    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (orientation)
        {
            if (DoneTrayectory)
            {
                transform.Translate(Vector2.right * speedEnemy * Time.deltaTime);

                if (transform.position.x >= initialPosition.x + distance)
                {
                    DoneTrayectory = false;
                    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                }


            }
            else
            {
                transform.Translate(Vector2.left * speedEnemy * Time.deltaTime);

                if (transform.position.x <= initialPosition.x - distance)
                {
                    DoneTrayectory = true;
                    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                }


            }
        }
        else
        {
            if (DoneTrayectory)
            {
                transform.Translate(Vector2.up * speedEnemy * Time.deltaTime);

                if (transform.position.y >= initialPosition.y + distance)
                {
                    DoneTrayectory = false;
                }

            }
            else
            {
                transform.Translate(Vector2.down * speedEnemy * Time.deltaTime);

                if (transform.position.y <= initialPosition.y - distance)
                {
                    DoneTrayectory = true;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            GameManager.Instance._damageTaken(20);
        }

    }

    public void _TakeDamageEnemy(int damage)
    {
        lifes -= damage;
        Instantiate(hitParticles, transform.position, transform.rotation);

        if (lifes <= 0)
        {
            Destroy(gameObject);
        }
    }
}
