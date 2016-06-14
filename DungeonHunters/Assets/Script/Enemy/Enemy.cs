using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    public string enemyName;
    public int level;
    public Text nameText;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
        nameText.text = enemyName + " - " + level;
    }
}
