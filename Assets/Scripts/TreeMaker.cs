using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMaker : MonoBehaviour
{
    public GameObject tree;
    public GameObject player;

    public float treeDistance = 10;
    public float treeRange = 30;
    private float treeSpawnTime = 10f;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawnTimer");
    }

    void SpawnTrees(int toSpawn)
    {
        for (int i = 0; i < toSpawn; i++)
        {
            Vector2 offset = Random.insideUnitCircle.normalized;
            Vector3 spawnPos = new Vector3(offset.x, 0, offset.y) * (treeDistance + Random.value * treeRange);
            GameObject t = Instantiate(tree, spawnPos, Quaternion.identity);
        }
    }

    private IEnumerator spawnTimer()
    {
        int toSpawn = 1;
        while (player)
        {
            SpawnTrees(toSpawn);
            yield return new WaitForSeconds(treeSpawnTime);
            toSpawn++;
        }

    }
}
