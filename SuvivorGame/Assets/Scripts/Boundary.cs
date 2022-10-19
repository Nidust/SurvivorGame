using UnityEngine;

public class Boundary : MonoBehaviour
{
    [SerializeField]
    private Vector2 offset;

    [SerializeField]
    private Vector2 size;

    public Bounds GetBounds()
    {
        return new Bounds(
            center: transform.position + new Vector3(offset.x, offset.y, 0f), 
            size: new Vector3(size.x, size.y, 0f)
        );
    }

    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent red cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireCube(transform.position + new Vector3(offset.x, offset.y, 0f), new Vector3(size.x, size.y, 0f));
    }
}
