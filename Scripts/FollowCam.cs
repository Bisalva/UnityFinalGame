using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Character;

    void Update()
    {
        Vector3 position = transform.position;
        position.x = Character.transform.position.x;
        position.y = Character.transform.position.y+1;
        transform.position = position; 
 

    }
}
