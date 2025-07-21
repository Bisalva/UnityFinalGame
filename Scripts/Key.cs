using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{

    [SerializeField] private AudioClip KeySound;
    public GameObject KeyUI;
    private bool KeyInBag;
    void Start()
    {
        KeyInBag = false;
    }

    void Update()
    {
        KeyInBag = GameManager.Instance._getKeyStatus();
        if (KeyInBag)
        {
            KeyUI.gameObject.SetActive(true);
        }
        else
        {
            KeyUI.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (GameManager.Instance._getKeyStatus() == false))
        {
            SoundManager.Instance._PlaySound(KeySound);
            Destroy(gameObject);
            GameManager.Instance._getKeyInBag();
        }
    }
}
