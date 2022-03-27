using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VihollistenLuoja : MonoBehaviour
{
    public Transform[] syntymiskohdat;
    public GameObject[] vihollistenPrefabit;
    float viimeksiLuodunAjankohta;
  
    void Update()
    {
        if (Time.time - viimeksiLuodunAjankohta > 3f)
        {
            LuoUusiVihollinen();
        }
    }

    void LuoUusiVihollinen()
    {
        Transform kohta = syntymiskohdat[Random.Range(0, syntymiskohdat.Length)];
        GameObject vihollinen = vihollistenPrefabit[Random.Range(0, vihollistenPrefabit.Length)];
        Instantiate(vihollinen, kohta.position, kohta.rotation);
        viimeksiLuodunAjankohta = Time.time;
    }
}
