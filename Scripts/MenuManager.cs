using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private AudioClip MenuSound;

    public Button[] buttons;
    private int currentButton = 0;

    void Start()
    {
        SelectButton(currentButton);
        SoundManager.Instance._PlayMusic(MenuSound);

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

    public void _playLevel1()
    {
        SceneManager.LoadSceneAsync(1);
        SoundManager.Instance._StopMusic();
    }

    public void _playLevel2()
    {
        SceneManager.LoadSceneAsync(2);
        SoundManager.Instance._StopMusic();

    }

    public void _playLevel3()
    {
        SceneManager.LoadSceneAsync(3);
        SoundManager.Instance._StopMusic();

    }
    



    public void _quit()
    {
        Application.Quit();
    }

}
