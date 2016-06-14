using UnityEngine;
using System.Collections;

public class WavesSystem : MonoBehaviour {
    public int compteur;
    public float time;
    public bool test;
	
        void Start()
    {
        test = true;
        compteur = 1;
        time = 5f;
     }
    
    void Update()
    {
        if (test)
        {

            StartCoroutine(WaitAndPrint(time));

        }
    }
        
    IEnumerator WaitAndPrint(float waitTime)
    {
        test = false;
        Waves maVague;
        
        yield return new WaitForSeconds(waitTime);
        maVague = new Waves("mob1 ", compteur, time);
        maVague.toString();
        compteur++;
        test = true;
        
        
    }
}

