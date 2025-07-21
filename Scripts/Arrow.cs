using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public GameObject Arrow1, Arrow2, Arrow3, Arrow4, Arrow5;
    private int arrowsAcount;
    void Start()
    {
        Arrow1.gameObject.SetActive(true);
        Arrow2.gameObject.SetActive(true);
        Arrow3.gameObject.SetActive(true);
        Arrow4.gameObject.SetActive(true);
        Arrow5.gameObject.SetActive(true);
    }

    void Update()
    {
        arrowsAcount = GameManager.Instance._getArrowsAmount();
        switch (arrowsAcount)
        {
            case 5:
                Arrow1.gameObject.SetActive(true);
                Arrow2.gameObject.SetActive(true);
                Arrow3.gameObject.SetActive(true);
                Arrow4.gameObject.SetActive(true);
                Arrow5.gameObject.SetActive(true);
                break;
            case 4:
                Arrow1.gameObject.SetActive(true);
                Arrow2.gameObject.SetActive(true);
                Arrow3.gameObject.SetActive(true);
                Arrow4.gameObject.SetActive(true);
                Arrow5.gameObject.SetActive(false);
                break;
            case 3:
                Arrow1.gameObject.SetActive(true);
                Arrow2.gameObject.SetActive(true);
                Arrow3.gameObject.SetActive(true);
                Arrow4.gameObject.SetActive(false);
                Arrow5.gameObject.SetActive(false);
                break;
            case 2:
                Arrow1.gameObject.SetActive(true);
                Arrow2.gameObject.SetActive(true);
                Arrow3.gameObject.SetActive(false);
                Arrow4.gameObject.SetActive(false);
                Arrow5.gameObject.SetActive(false);
                break;
            case 1:
                Arrow1.gameObject.SetActive(true);
                Arrow2.gameObject.SetActive(false);
                Arrow3.gameObject.SetActive(false);
                Arrow4.gameObject.SetActive(false);
                Arrow5.gameObject.SetActive(false);
                break;
            case 0:
                Arrow1.gameObject.SetActive(false);
                Arrow2.gameObject.SetActive(false);
                Arrow3.gameObject.SetActive(false);
                Arrow4.gameObject.SetActive(false);
                Arrow5.gameObject.SetActive(false);
                break;
        }
    }

    

}
