using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Weapon
{
    public float CoolTime;
    public GameObject Prefab;
    public Vector2 pivot;
}

public class WeaponSystem : MonoBehaviour
{
    [SerializeField]
    private Weapon[] weaponList;

    private GameObject player;
    private SpriteRenderer playerRenderer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRenderer = player.GetComponent<SpriteRenderer>();
        
        foreach (Weapon spawner in weaponList)
        {
            StartCoroutine("Spawn", spawner);
        }
    }

    private IEnumerator Spawn(Weapon spawner)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawner.CoolTime);

            if (player == null)
            {
                break;
            }

            GameObject enemy = ObjectManager.GetNearestEnemy();
            if (enemy != null)
            {
                Vector3 spawnPos = player.transform.position;
                Vector3 offset = playerRenderer.bounds.size * spawner.pivot;

                Instantiate(spawner.Prefab, spawnPos + offset, Quaternion.identity, transform)
                    .GetComponent<Movement>()
                    .SetTarget(enemy)
                    .SetDestroyWhenOut(true);
            }
        }

        yield return null;
    }

    void OnDrawGizmosSelected()
    {
        if (player == null)
        {
            return;
        }

        
        Vector3 spawnPos = player.transform.position;

        foreach (var weapon in weaponList)
        {
            Vector3 offset = playerRenderer.bounds.size * weapon.pivot;

            // Draw a semitransparent red cube at the transforms position
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            Gizmos.DrawSphere(spawnPos + new Vector3(offset.x, offset.y, 0f), 0.1f);
        }
    }
}
