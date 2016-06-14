using UnityEngine;
using System.Collections;

public class Waves : MonoBehaviour
{
    public float time;
    public string mob;
    //liste de prefab
    //liste des positions
    //liste des Boss
    //Spawn du Boss
    //fonction spawn de arena button, verifier qui c'est un mutliple de 5
    
    public int compteur;

    public Waves(string pMob, int pCompteur)
    {
        time = 30;
        mob = pMob;
        compteur = pCompteur;
    }

    public Waves(string pMob, int pCompteur, float pTime)
    {
        time = pTime;
        mob = pMob;
        compteur = pCompteur;
    }

    public void toString()
    {
        Debug.Log("vague " + compteur + " mob " + mob + " temps " + time);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}

