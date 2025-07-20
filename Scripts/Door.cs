using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;
using TMPro;


public class Door : MonoBehaviour
{

    public TMP_Text screenText;
    public float timeTransition = 5f;
    public string sceneName;
    public Rigidbody2D PlayerEnding;
    public GameObject Character;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (GameManager.Instance._getKeyStatus() == true))
        {

            StartCoroutine(_NextLevel());
            GameManager.Instance._useKeyInBag();


        }
    }

    IEnumerator _NextLevel()
    {
        GameManager.Instance._IsInDoor();
        Character.GetComponent<PlayerController>().enabled = false;


        screenText.text = "¡NIVEL COMPLETADO!";
        screenText.enabled = true;

        yield return new WaitForSeconds(timeTransition);


        SceneManager.LoadScene(sceneName);

    }


}
