using UnityEngine;
using System.Collections;

public class EnemyAggro : MonoBehaviour {

    public GameObject enemyCanvas;

    private NavMeshAgent agent;
    private GameObject player;
    private bool playerIsAggro;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(playerIsAggro)
        {
            agent.destination = player.transform.position;
            transform.parent.transform.position = agent.transform.position;
        }
	}


    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            enemyCanvas.SetActive(true);
            playerIsAggro = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            enemyCanvas.SetActive(false);
            playerIsAggro = false;
        }
    }

}
