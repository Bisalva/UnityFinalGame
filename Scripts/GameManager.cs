using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    public TMP_Text screenTextTimer;


    private float lifeBar = 100;
    private int arrows = 5;
    private bool key = false;
    private bool takingDamage = false;
    private bool lifeStatus = true;
    private bool inDoor = false;
    private float timerCount = 300;
    



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
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

    public void _LevelReset()
    {

        StartCoroutine(_ResetDelay());
        _fullLife();
    }

    public void _potionTaken(int Potion)
    {

        lifeBar += Potion;
    }
    public void _fullLife()
    {
        lifeBar = 100;
        lifeStatus = true;
        arrows = 5;
        timerCount = 300;
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

    public void _useKeyInBag()
    {
        key = false;
    }

    public void _IsInDoor()
    {
        inDoor = true;

    }
    public bool _getInDoor()
    {
        return inDoor;
    }


    public void _timer()
    {

        timerCount -= Time.deltaTime;
        screenTextTimer.text = timerCount.ToString("F0"); 
        if (timerCount <= 0)
        {
            lifeStatus = false;
        }

    }






    IEnumerator _ResetDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
