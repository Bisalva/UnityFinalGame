using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //Sound
    [SerializeField] private AudioClip DamageSoundPlayer;

    //LIFES
    public int lifes;
    private bool LifeStatus = true;
    public GameObject hitParticles;

    //-----

    //MOVEMENT
    private Vector2 initialPosition;
    private bool DoneTrayectory;
    public int distance;
    public int speedEnemy;
    public bool orientation;
    private Animator Animator;
    //-----

    //LOOT
    public GameObject LootItem;
    //----

    //Shot (Only Bee)
    public GameObject StingPrefab;
    private Transform Character;
    public int speedSting;
    public float fireRate = 2f;
    private float nextFireTime = 0f;
    private bool canShoot = false;
    //----

    void Start()
    {
        initialPosition = transform.position;
        Animator = GetComponent<Animator>();
        Character = GameObject.FindGameObjectWithTag("Player").transform;
        if (gameObject.tag == "BeeEnemy")
        {
            canShoot = true;

        }

    }

    void Update()
    {

        if (LifeStatus)
        {
            _MovementEnemy();

            if (Time.time >= nextFireTime && canShoot == true)
            {
                _ShootEnemy();
                nextFireTime = Time.time + fireRate;
            }

        }

    }

    public void _MovementEnemy()
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
            SoundManager.Instance._PlaySound(DamageSoundPlayer);
            GameManager.Instance._damageTaken(20);
        }

    }

    public void _TakeDamageEnemy(int damage)
    {
        lifes -= damage;
        Instantiate(hitParticles, transform.position, transform.rotation);

        if (lifes <= 0)
        {
            LifeStatus = false;
            if (gameObject.tag == "Boss")
            {
                distance = 0;

                Animator.SetBool("isDeadE", true);
                gameObject.layer = LayerMask.NameToLayer("DeadEnemies");
                Instantiate(LootItem, transform.position, Quaternion.identity);
                Destroy(gameObject, 1f);

            }
            else
            {
                distance = 0;
                Animator.SetBool("isDead", true);
                gameObject.layer = LayerMask.NameToLayer("DeadEnemies");
                Destroy(gameObject, 1f);

            }
        }
    }

    public void _ShootEnemy()
    {
        GameObject Sting = Instantiate(StingPrefab, transform.position, Quaternion.identity);

        Vector2 direction = (Character.position - transform.position).normalized;

        Sting.GetComponent<Rigidbody2D>().AddForce(direction * speedSting, ForceMode2D.Impulse);

        Destroy(Sting, 5f);

    }


}
