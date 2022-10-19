using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private static ObjectManager Instance;

    [SerializeField]
    private float managedRange = 5f;

    private GameObject player;
    private List<ManagedObject> EnemyList;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        EnemyList = new List<ManagedObject>();

        Instance = this;
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 position = transform.position;
        if (player != null)
        {
            position = player.transform.position;
        }

        // Draw a semitransparent red cube at the transforms position
        Gizmos.color = new Color(0, 1.0f, 0, 0.5f);
        Gizmos.DrawWireSphere(position, managedRange);
    }

    public static void OnEnter(ManagedObject obj)
    {
        if (obj.ObjectType == ManagedObjectType.Enemy)
        {
            if (Instance.EnemyList.Contains(obj))
            {
                Debug.Log("ObjectManager.OnEnter - ??? ????? ????? ??????.");
                return;
            }

            Instance.EnemyList.Add(obj);
        }
    }

    public static void OnExit(ManagedObject obj)
    {
        if (obj.ObjectType == ManagedObjectType.Enemy)
        {
            if (Instance.EnemyList.Contains(obj) == false)
            {
                Debug.Log("ObjectManager.OnEnter - ??? ????? ????? ??????.");
                return;
            }

            Instance.EnemyList.Remove(obj);
        }
    }

    public static float GetManagedRange()
    {
        return Instance.managedRange;
    }

    public static GameObject GetNearestEnemy()
    {
        float minDistance = float.MaxValue;
        GameObject enemy = null;

        foreach (ManagedObject obj in Instance.EnemyList)
        {
            if (minDistance > obj.GetLastDistance())
            {
                enemy = obj.gameObject;
                minDistance = obj.GetLastDistance();
            }
        }

        return enemy;
    }
}
