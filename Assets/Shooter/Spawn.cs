using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {



    public GameObject[] frankenstein;

    public int ilosc;

    public Vector2 punktspawnu;

	void Update () 
    {
        frankenstein = GameObject.FindGameObjectsWithTag("Enemy");
        ilosc = frankenstein.Length;

        if (ilosc != -1)
        {
            InvokeRepeating("spawnWroga", 5f, 10);
        }

	}
    void spawnWroga()
    {
        punktspawnu.x = Random.Range(-20, -55);
        punktspawnu.y = 0.2f;

        Instantiate(frankenstein[UnityEngine.Random.Range(0, frankenstein.Length - 1)], punktspawnu, Quaternion.identity);
        CancelInvoke();
    }

}
