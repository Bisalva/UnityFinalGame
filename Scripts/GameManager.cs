using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    private float lifeBar = 100;
    private int arrows = 5;
    private bool key = false;
    private bool takingDamage = false;
    private bool lifeStatus = true;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }


    public void _damageTaken(int Damage)
    {
        _TakingDamageStatusChange();
        lifeBar -= Damage;
        if (lifeBar <= 0)
        {
            lifeStatus = false;
        }

    }

    public bool _getAlive()
    {
        return lifeStatus;
    }

    public void _TakingDamageStatusChange()
    {
        takingDamage = !takingDamage;
    }

    public bool _IsTakingDamage()
    {
        return takingDamage;
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

    public bool _getKeyStatus()
    {
        return key;
    }

    public void _getKeyInBag()
    {
        key = true;
    }

}
