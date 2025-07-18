using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    private float lifeBar = 100;
    public int arrows = 5;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }


    public void _damageTaken(int Damage)
    {
        lifeBar -= Damage;
    }

    public void _potionTaken(int Potion)
    {
        lifeBar += Potion;
        Debug.Log("vida : " + lifeBar);
    }

    public void _takeArrow()
    {
        arrows += 1;
    }

    public void _shootArrow()
    {
        arrows -= 1;
    }

    public float _getLifeBar()
    {
        return lifeBar;
    }

    public int _getArrowsAmount()
    {
        return arrows;
    }

}
