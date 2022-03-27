using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pisteet : MonoBehaviour
{
    public static Pisteet instanssi; 
    public Text teksti;
     int pisteet; 

    void Start()
    { 
        instanssi = this;
    } 
    public void Lisää(int määrä) 
    { 
        pisteet += määrä;
        teksti.text = pisteet.ToString(); 
    } 
    public int PisteidenMäärä() 
    { 
    return pisteet; 
    }

}
