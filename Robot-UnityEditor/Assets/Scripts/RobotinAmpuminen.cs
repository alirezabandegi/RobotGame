using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotinAmpuminen : MonoBehaviour
{

    public LineRenderer[] tykit;
    public float ampimisLujuus = 50f;
    public float ampumisEtäisyys = 12f;
    public float ampumisNopeus = 50f;
    public float laserSäteenNopeus;
    float viimeAmpuminen;
    int ampumistenLukumäärä;
    
        void Update()
    {
        if(Input.GetMouseButton(0) && Time.time - viimeAmpuminen >= ampumisNopeus){
            Ammu();
        }
        SädeidenLento();
    }

    void Ammu(){
        LineRenderer tykki = tykit[++ampumistenLukumäärä % 2];
        Ray säde = new Ray(tykki.transform.position, tykki.transform.forward);
        RaycastHit osuma;
        Vector3 päätePiste;
        if(Physics.Raycast(säde, out osuma, ampumisEtäisyys)){
            päätePiste = osuma.point;
            if(osuma.transform.CompareTag("Vihollinen")){
                osuma.transform.GetComponent<VihollisenKuoleminen>().Elämäpisteet -= ampimisLujuus;
            }
        }
        else{
            päätePiste = säde.origin + säde.direction * ampumisEtäisyys;
        }
        tykki.SetPositions(new Vector3[]{säde.origin, päätePiste});
        tykki.enabled = true;
        viimeAmpuminen = Time.time;
    }

    void SädeidenLento(){
        foreach(LineRenderer tykki in tykit){
            if(!tykki.enabled)
                continue;
                        
            Vector3[] pisteet = new Vector3[2];
            tykki.GetPositions(pisteet);
            pisteet[0] = Vector3.MoveTowards(pisteet[0], pisteet[1], Time.deltaTime * laserSäteenNopeus);
            tykki.SetPositions(pisteet);
            if(Vector3.Distance(pisteet[0], pisteet[1]) < 1f){
                tykki.enabled = false;
            }
        }
    }
}
