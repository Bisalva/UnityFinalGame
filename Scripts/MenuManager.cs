using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public Button[] buttons;
    private int currentButton = 0;

    void Start()
    {
        SelectButton(currentButton);
    }

    void Update()
    {
        _SelectionMenu();
    }

    public void _SelectionMenu()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            currentButton++;
            if (currentButton >= buttons.Length) currentButton = 0;
            SelectButton(currentButton);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            currentButton--;
            if (currentButton < 0) currentButton = buttons.Length - 1;
            SelectButton(currentButton);
        }

    }

    void SelectButton(int index)
    {
        EventSystem.current.SetSelectedGameObject(buttons[index].gameObject);
    }

    public void _play()
    {
        SceneManager.LoadSceneAsync(1);
    }


    public void _quit()
    {
        Application.Quit(); 
    }

}
