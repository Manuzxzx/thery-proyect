using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Enemys;
    public int[] spawnPosx;
    public int spawnPosz;
    private int spawnRange = 5;
    private int spawnPosxInt;
    private int spawnIndex;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosx = new int[2];
        spawnPosx[0] = -spawnRange;
        spawnPosx[1] = spawnRange;
        InvokeRepeating("SpawnEnemy", 4, 1);
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector3 GenerateRandomPosition()
    {
        spawnPosz = Random.Range(spawnRange, -spawnRange);
        if (spawnPosz == spawnRange || spawnPosz == -spawnRange)
        {
            spawnPosxInt = Random.Range(spawnRange, -spawnRange);
        }
        else
        {
            spawnPosxInt = spawnPosx[Random.Range(0, 2)];
        }
        Vector3 randomPos = new Vector3(spawnPosxInt, 1.1f, spawnPosz);
        return randomPos;
        
    }
    private void SpawnEnemy()
    {
        spawnIndex = Random.Range(0, 2);
        Instantiate(Enemys[spawnIndex], GenerateRandomPosition(), Enemys[spawnIndex].transform.rotation);
    }
}
