using UnityEngine;
using System.Collections;

public class ScreenShot : MonoBehaviour
{
    public bool screenInProgress;
    private int num = 1;

    // Use this for initialization
    void Start()
    {
        screenInProgress = false;
    }

    void FixedUpdate()
    {
        if (screenInProgress)
        {
            Application.CaptureScreenshot("Docs/Screenshots/screen" + num + ".png");
            num++;
            Debug.Log("Export " + num);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            screenInProgress = !screenInProgress;
        }
    }
}
