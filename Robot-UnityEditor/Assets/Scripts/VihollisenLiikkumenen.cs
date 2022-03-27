using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class VihollisenLiikkumenen : MonoBehaviour
{
    NavMeshAgent agentti;
    Transform robotti;
    Vector3 määränpää;
    RobotinKuoleminen robotinKuoleminen;
    public float hyökkäysLujuus = 15f;
    public float hyökkäysNopeus = 2f;
    float viimeHyökkäys;

    void Start()
    {
        agentti = GetComponent<NavMeshAgent>();
        määränpää = agentti.destination;
        robotti = GameObject.Find("Robotti").transform;
        robotinKuoleminen = robotti.GetComponent<RobotinKuoleminen>();
    }

    void Update()
    {
        if(Time.time - viimeHyökkäys >= hyökkäysNopeus)
        {
            if(agentti.hasPath && agentti.remainingDistance <= agentti.stoppingDistance)
            {
                robotinKuoleminen.Elämäpisteet -= hyökkäysLujuus;
                viimeHyökkäys = Time.time;
            }
        }

        if (Vector3.Distance(robotti.position, määränpää) > 1.0f)
        {
            määränpää = robotti.position;
            agentti.destination = määränpää;
        }
    }
}
