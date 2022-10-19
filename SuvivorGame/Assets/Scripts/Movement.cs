using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D limit;
    [SerializeField]
    private float moveSpeed = 5f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector3(horizontal, vertical).normalized;

        if (direction.x != 0f || direction.y != 0f)
        {
            animator.SetBool("IsLeftMove", direction.x < 0.0f);

            Vector3 translation = direction * moveSpeed * Time.deltaTime;
            Vector3 nextPosition = transform.position + translation;

            transform.position = ClampPosition(nextPosition);
        }
    }

    Vector3 ClampPosition(Vector3 position)
    {
        position.x = Mathf.Clamp(
            value: position.x,
            min: limit.bounds.min.x,
            max: limit.bounds.max.x
        );

        position.y = Mathf.Clamp(
            value: position.y,
            min: limit.bounds.min.y,
            max: limit.bounds.max.y
        );

        return position;
    }
}