using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{

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
            Destroy(gameObject);
            GameManager.Instance._getKeyInBag();
        }
    }
}
