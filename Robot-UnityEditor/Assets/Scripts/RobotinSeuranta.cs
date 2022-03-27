using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotinSeuranta : MonoBehaviour
{
    public Transform kohde;
    Vector3 etäisyys;
    

    void Start()
    {
        etäisyys = transform.position - kohde.position;
    }


    void LateUpdate()
    {
        transform.position = kohde.position + etäisyys;
    }
}
