using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Kuoleminen : MonoBehaviour
{
    [SerializeField]
    private float el�m�pisteet = 100f;
    public float vaurioKerroin = 1f;

    public float El�m�pisteet
    {
        get
        {
            return el�m�pisteet;
        }
        set
        {
            float uusiArvo = value;
            if(uusiArvo < el�m�pisteet)
            {
                float muutos = uusiArvo - el�m�pisteet;
                uusiArvo = el�m�pisteet + muutos * vaurioKerroin;
            }

            el�m�pisteet = Mathf.Clamp(uusiArvo, 0f, 100f);
            if(el�m�pisteet == 0f)
            {
                Kuole();
            }
        }
    }

    protected abstract void Kuole();


}
