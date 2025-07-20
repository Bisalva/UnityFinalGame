using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{


    public GameObject Arrow, Life, Key,Death;

    void Start()
    {
        Death.gameObject.SetActive(false);
    }
    void Update()
    {
        _InDeath();
    }


    public void _InDeath()
    {
        if (GameManager.Instance._getAlive() == false)
        {

            Arrow.gameObject.SetActive(false);
            Life.gameObject.SetActive(false);
            Key.gameObject.SetActive(false);
            Death.gameObject.SetActive(true);
        }
    }

}
