using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> tanks;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private float spawnTime = 4f;

    private void Start()
    {
        StartCoroutine(SpawnTank());
    }

    IEnumerator SpawnTank()
    {
        while(true)
        {
            int limit;

            if (Stats.Level < tanks.Count)
                limit = Stats.Level;
            else limit = tanks.Count;

            if (Stats.Level > 5)
                spawnTime = 4;
            else if (Stats.Level > 7)
                spawnTime = 3;
            else if (Stats.Level > 10)
                spawnTime = 2;
            else if (Stats.Level > 15)
                spawnTime = 1;

            Instantiate(tanks[Random.Range(0, limit)], spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
