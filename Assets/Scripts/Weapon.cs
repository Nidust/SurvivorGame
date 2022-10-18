using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    
    private void Start()
    {
        Destroy(gameObject, 3.0f);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionTarget = collision.gameObject;
        if (collisionTarget.CompareTag("Player"))
        {
            return;
        }

        Destroy(gameObject);
    }

    public Weapon LootAt(Vector3 targetPosition)
    {
        Vector2 direction = targetPosition - transform.position;

        // 마우스 거리로 부터 각도 계산
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //축으로부터 방향과 각도의 회전값
        Quaternion rotation = Quaternion.AngleAxis(angle - 90.0f, Vector3.forward);
        transform.rotation = rotation;

        return this;
    }
}
