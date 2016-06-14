using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    public string SceneName;
    private GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == player)
        {
            Application.LoadLevel(SceneName);
        }
    }
}
