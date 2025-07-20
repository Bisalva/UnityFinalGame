using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class FollowCam : MonoBehaviour
{
    public GameObject Character;
    public Camera mainCam;
    public Camera zoomCam;

    void Update()
    {
        Vector3 position = transform.position;
        position.x = Character.transform.position.x;
        position.y = Character.transform.position.y + 1;
        transform.position = position;

        _CamInEnd();
    }

    public void _CamInEnd()
    {
        if (GameManager.Instance._getInDoor() == true)
        {
            zoomCam.depth = 0f;    
        }
        
    }
}
