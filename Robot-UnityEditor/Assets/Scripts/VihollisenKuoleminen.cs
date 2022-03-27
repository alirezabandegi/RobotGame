using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VihollisenKuoleminen : Kuoleminen
{
    public int pisteAnsio;
    protected override void Kuole(){
        Pisteet.instanssi.Lisää(pisteAnsio);
        Destroy(gameObject);
    }
}
