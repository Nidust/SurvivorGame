using Assets.Scripts.Extensions;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform player;
    private Vector2 cameraHalfSize;

    private void Start()
    {
        player = GameObject
            .FindGameObjectWithTag("Player")
            .GetComponent<Transform>();

        Camera camera = GetComponent<Camera>();
        cameraHalfSize.x = camera.aspect * camera.orthographicSize;
        cameraHalfSize.y = camera.orthographicSize;
    }

    private void LateUpdate()
    {
        if (player == null)
        {
            return;
        }

        Vector3 newPosition = new Vector3(
            x: player.position.x,
            y: player.position.y,
            z: transform.position.z
        );

        transform.position = newPosition.Limit(RestrictionType.Camera, cameraHalfSize);
    }
}
