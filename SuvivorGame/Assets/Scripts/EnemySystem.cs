using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class EnemySpawner
{
    public float CoolTime;
    public GameObject Prefab;
}

public class EnemySystem : MonoBehaviour
{
    [SerializeField]
    private EnemySpawner[] spawnList;

    private Bounds spawnBounds;

    // Start is called before the first frame update
    void Start()
    {
        spawnBounds = MovementRestrictions.GetLimit(RestrictionType.Object);

        foreach (EnemySpawner spawner in spawnList)
        {
            StartCoroutine("SpawnCoroutine", spawner);
        }

        for (int index = 0; index < 30; index++)
        {
            Spawn(spawnList[0]);
        }
    }

    IEnumerator SpawnCoroutine(EnemySpawner spawner)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawner.CoolTime);

            Spawn(spawner);
        }
    }

    void Spawn(EnemySpawner spawner)
    {
        Vector2 newPosition = new Vector2();
        newPosition.x = Random.Range(spawnBounds.min.x, spawnBounds.max.x);
        newPosition.y = Random.Range(spawnBounds.min.y, spawnBounds.max.y);

        Instantiate(spawner.Prefab, newPosition, Quaternion.identity, transform);
    }
}
