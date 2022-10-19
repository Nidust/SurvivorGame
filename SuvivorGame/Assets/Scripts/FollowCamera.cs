using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D limit;
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
        Vector3 newPosition = new Vector3(
            x: player.position.x,
            y: player.position.y,
            z: transform.position.z
        );

        transform.position = ClampPosition(newPosition);
    }

    private Vector3 ClampPosition(Vector3 position)
    {
        position.x = Mathf.Clamp(
            value: position.x,
            min: limit.bounds.min.x + cameraHalfSize.x,
            max: limit.bounds.max.x - cameraHalfSize.x
        );

        position.y = Mathf.Clamp(
            value: position.y,
            min: limit.bounds.min.y + cameraHalfSize.y,
            max: limit.bounds.max.y - cameraHalfSize.y
        );

        return position;
    }
}
