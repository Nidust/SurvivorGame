using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ManagedObjectType
{
    Enemy
}

public class ManagedObject : MonoBehaviour
{
    public ManagedObjectType ObjectType;

    private GameObject player;
    private float distance;
    private float lastDistance;

    private bool onEnter = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        distance = ObjectManager.GetManagedRange();
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }

        bool prevEnter = onEnter;

        lastDistance = Vector2.Distance(transform.position, player.transform.position);
        onEnter = distance >= lastDistance;
        
        if (prevEnter != onEnter)
        {
            if (onEnter)
            {
                ObjectManager.OnEnter(this);
            }
            else
            {
                ObjectManager.OnExit(this);
            }
        }
    }

    private void OnDestroy()
    {
        if (onEnter == false)
        {
            return;
        }

        ObjectManager.OnExit(this);
    }

    public float GetLastDistance()
    {
        return lastDistance;
    }
}
