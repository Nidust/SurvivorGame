using System.Linq;
using UnityEngine;

public class HpSystem : MonoBehaviour
{
    [SerializeField]
    private float hp = 0.0f;
    [SerializeField]
    private string[] excludeTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.CompareTag("Untagged") || obj.CompareTag(gameObject.tag))
        {
            return;
        }

        if (excludeTag.Contains(obj.tag))
        {
            return;
        }

        Destroy(gameObject);
    }
}
