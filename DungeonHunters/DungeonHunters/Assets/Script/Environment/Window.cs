using UnityEngine;
using System.Collections;

public class Window : MonoBehaviour
{
    public GameObject shutter;

    // Smothly open a door
    private float smooth = 2.0f;
    private float DoorOpenAngle = 95.0f;
    private float holdingTime = 0.0f;
    private float holdTime = 0.5f;

    private bool isOpen;
    private bool canInteract;

    private Vector3 defaultRot;
    private Vector3 openRot;

    void Start()
    {
        defaultRot = transform.eulerAngles;
        openRot = new Vector3(defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
    }

    void Update()
    {
        if (isOpen)
        {
            //Open door
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
        }
        else
        {
            //Close door
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
        }

        if (canInteract)
        {
            if (Input.GetButton("Interact"))
            {
                holdingTime += Time.deltaTime;
            }
            if (Input.GetButtonUp("Interact"))
            {

                if(holdingTime >= Time.deltaTime + holdTime)
                {
                    // si la fenetre est fermee 
                    if(!isOpen)
                        // on peut intergir avec les volets
                        shutter.SetActive(!shutter.activeSelf);
                }
                else
                {
                    // si les volets sont ouverts
                    if(!shutter.activeSelf)
                        // on peut intergir avec la fenetre
                        isOpen = !isOpen;
                }
                holdingTime = 0.0f;
            }
        }
    }

    void OnGUI()
    {
        if (canInteract)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 200, 50), "Appuyer sur 'F' pour Intéragir\nMaintener pour ourir/fermer les volets");
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
}
