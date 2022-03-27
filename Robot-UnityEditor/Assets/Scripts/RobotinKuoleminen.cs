using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotinKuoleminen : Kuoleminen
{
    void Update()
    {
        El�m�pisteet += Time.deltaTime;
    }

    protected override void Kuole()
    {
        gameObject.SetActive(false);
        Time.timeScale = 0f;
        print("Prlaaja h�visi!");
    }
}
