using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class VihollisenLiikkumenen : MonoBehaviour
{
    NavMeshAgent agentti;
    Transform robotti;
    Vector3 m��r�np��;
    RobotinKuoleminen robotinKuoleminen;
    public float hy�kk�ysLujuus = 15f;
    public float hy�kk�ysNopeus = 2f;
    float viimeHy�kk�ys;

    void Start()
    {
        agentti = GetComponent<NavMeshAgent>();
        m��r�np�� = agentti.destination;
        robotti = GameObject.Find("Robotti").transform;
        robotinKuoleminen = robotti.GetComponent<RobotinKuoleminen>();
    }

    void Update()
    {
        if(Time.time - viimeHy�kk�ys >= hy�kk�ysNopeus)
        {
            if(agentti.hasPath && agentti.remainingDistance <= agentti.stoppingDistance)
            {
                robotinKuoleminen.El�m�pisteet -= hy�kk�ysLujuus;
                viimeHy�kk�ys = Time.time;
            }
        }

        if (Vector3.Distance(robotti.position, m��r�np��) > 1.0f)
        {
            m��r�np�� = robotti.position;
            agentti.destination = m��r�np��;
        }
    }
}
