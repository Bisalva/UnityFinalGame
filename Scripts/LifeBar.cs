using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{

    public Image fillLifeBar;
    private float MaxLife = 100;

    

    // Update is called once per frame
    void Update()
    {
        fillLifeBar.fillAmount = GameManager.Instance._getLifeBar() / MaxLife;
    }
}
