using UnityEngine;
using System.Collections;
using System;

public class Aggro : MonoBehaviour
{
    public bool isAggroPlayer;
    public Transform target;
    public int range;
    public int minDistance = 5;

    private bool asMoving;

    private Vector3 startPos;
    private Transform startTransform;
    private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        // temp
        agent.SetDestination(target.transform.position);
        // ..

        if (range > minDistance)
            agent.stoppingDistance = range / 2;
        else
            agent.stoppingDistance = range;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isAggroPlayer)
        //{
        //    //Debug.Log("Remaining Dist: " + agent.remainingDistance);
        //    //Debug.Log("Stopping Dist: " + agent.stoppingDistance);
        //    float distanceBetweenIAAndPlayer = Vector3.Distance(transform.position, target.position);
        //    //Debug.Log("distanceBetweenIAAndPlayer: " + distanceBetweenIAAndPlayer);
        //    if ( distanceBetweenIAAndPlayer < 4)
        //    {
        //        //Debug.Log("back");
        //        Vector3 v = new Vector3(transform.position.x - (4 - distanceBetweenIAAndPlayer), transform.position.y, transform.position.z - (4 - distanceBetweenIAAndPlayer));
        //        Debug.Log("v: " + v + " target: " + target.transform.position);
        //        agent.SetDestination(v);
        //        Debug.Log("destination: " + agent.destination);
        //    }
        //    else
        //    {
        agent.SetDestination(target.transform.position);
        transform.LookAt(target.transform);
        //    
        transform.position = agent.transform.position;

        //    asMoving = true;
        //}
        //else if (asMoving)
        //{
        //    agent.SetDestination(startPos);
        //    transform.position = agent.transform.position;
        //    asMoving = false;
        //}
    }
}
