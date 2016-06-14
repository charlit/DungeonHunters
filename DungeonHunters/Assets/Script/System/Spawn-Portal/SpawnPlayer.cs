using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour
{

    public Transform pos;

    GameObject player;

    void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {   
            GameObject.FindGameObjectWithTag("Player").transform.position = pos.position;
        }
    }

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
