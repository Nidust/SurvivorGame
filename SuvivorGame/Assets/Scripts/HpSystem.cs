using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class HpSystem : MonoBehaviour
{
    [SerializeField]
    private float hp = 0.0f;
    [SerializeField]
    private string[] excludeTag;
    [SerializeField]
    private UnityEvent onDie;

    private bool die = false;

    private void OnCollisionEnter2D(Collision2D collision)
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

        hp -= 1f;
        if (hp <= 0.0f && die == false)
        {
            if (onDie != null)
            {
                onDie.Invoke();
            }

            die = true;
            Destroy(gameObject);
        }
    }
}
