using UnityEngine;
using System.Collections;

public class ArenaButton : MonoBehaviour {

    public int wave ;
    public float spawnTime = 10f;
    public Transform pos;
    public GameObject mobPrefab;

    private bool canInteract;
    private bool isActive;
    private float timer;
	public Transform[] spawnPoints;   

    // Use this for initialization
    void Start () {
        isActive = false;
        wave = -1;
    }
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= Time.deltaTime + spawnTime)
            {
                Spawn();

                timer = 0;
            }
        }

        if (Input.GetButtonUp("Interact") && canInteract)
        {
            isActive = !isActive;
        }
    }

    void OnGUI()
    {
        if (canInteract)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 50), "Appuyer sur 'F' pour Intéragir");
        }
    }

    //Activate the Main function when player is near the door
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canInteract = true;
        }
    }

    //Deactivate the Main function when player is go away from door
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canInteract = false;
        }
    }

    void Spawn()
    {
        if (isActive)
        {
			Instantiate(mobPrefab, pos.position, pos.rotation);
			//Instantiate(mobPrefab, pos.position, pos.rotation);

			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
            Instantiate(mobPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

			//Instantiate (mobPrefab, spawnPoints[spawnPointIndex].rotation, spawnPoints[spawnPointIndex].rotation);

        }
    }
}
