using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotinSeuranta : MonoBehaviour
{
    public Transform kohde;
    Vector3 et�isyys;
    

    void Start()
    {
        et�isyys = transform.position - kohde.position;
    }


    void LateUpdate()
    {
        transform.position = kohde.position + et�isyys;
    }
}
