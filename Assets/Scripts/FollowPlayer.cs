using System.Collections;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = player.position.x;
        newPosition.y = player.position.y;

        transform.position = newPosition;
    }
}
