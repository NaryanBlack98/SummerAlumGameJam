﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombeManager : MonoBehaviour
{
    public GameObject zombe;
    public GameObject player;
    public int totalWaves = 0;
    public float spawnDist = 30;
    private Collider myCollider;
    private float timeBetweenWaves = 10f;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        DontDestroyOnLoad(gameObject);
        StartCoroutine("waveTimer");
    }

    void SpawnZombes(int toSpawn)
    {
        for (int i = 0; i < toSpawn; i++)
        {
            Vector2 offset = Random.insideUnitCircle.normalized;
            Vector3 spawnPos = new Vector3(offset.x, 0, offset.y) * spawnDist;
            GameObject zom = Instantiate(zombe, player.transform.position + spawnPos, Quaternion.identity);
        }
    }

    private IEnumerator waveTimer()
    {
        int toSpawn = 3;
        while (player)
        {
            SpawnZombes(toSpawn);
            yield return new WaitForSeconds(timeBetweenWaves);
            toSpawn++;
            totalWaves++;
        }
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
