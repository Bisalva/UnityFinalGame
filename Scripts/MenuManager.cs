using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void _play()
    {
        SceneManager.LoadSceneAsync(1);
    }


    public void _quit()
    {
        Application.Quit(); 
    }

}
