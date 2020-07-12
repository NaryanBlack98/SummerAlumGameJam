using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawning : MonoBehaviour
{
    public GameObject[] spawnees;
    public Transform spawnPos;
    int randomInt;
    public float spawnTime;
    public float spawnDelay;
    public GameObject clone;
    //public float despawnTime;
    public float despawnDelay;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay  );
        InvokeRepeating("DestroyObjectDelayed", spawnTime+5, despawnDelay);
    }

    public void SpawnObject()
    {
        randomInt = Random.Range(0, spawnees.Length);
        clone = Instantiate(spawnees[randomInt], spawnPos.position, spawnPos.rotation);
    }
    void DestroyObjectDelayed()
    {
        if ((clone.GetComponent<ClickDetection>().clicked) == false)
        {
            UnityEngine.Debug.Log("inside");
            SceneManager.LoadScene("EndGame");

        }
        clone.GetComponent<ClickDetection>().clicked = false;
        UnityEngine.Debug.Log(clone.GetComponent<ClickDetection>().clicked);

        // Kills the game object in 5 seconds after loading the object
        Destroy(clone);
        
    }


}
