using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Door : MonoBehaviour
{
    //Make an empty game object and call it "Door"
    //Rename your 3D door model to "Body"
    //Parent a "Body" object to "Door"
    //Make sure thet a "Door" object is in left down corner of "Body" object. The place where a Door Hinge need be
    //Add a box collider to "Door" object and make it much bigger then the "Body" model, mark it trigger
    //Assign this script to a "Door" game object that have box collider with trigger enabled
    //Press "f" to open/close the door
    //Make sure the main character is tagged "player"

    public Text lblInfos;

    // Smothly open a door
    private float smooth = 2.0f;
    private float DoorOpenAngle = 90.0f;
    private float informationDelay = 3f;

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

        if (Input.GetButtonDown("Interact") && canInteract)
        {
            isOpen = !isOpen;
        }
    }

    void OnGUI()
    {
        if (canInteract)
        {
            StartCoroutine(ShowMessage("Appuyer sur 'F' pour Intéragir", informationDelay));
            //GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 50), "Appuyer sur 'F' pour Intéragir");
        }
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        if (canInteract)
        {
            lblInfos.text = message;
            lblInfos.enabled = true;
            yield return new WaitForSeconds(delay);
            lblInfos.enabled = false;
        }
        else
        {
            lblInfos.text = "";
            lblInfos.enabled = false;
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
