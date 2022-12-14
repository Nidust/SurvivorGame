using Assets.Scripts.Extensions;
using System;
using UnityEngine;

public enum MovementType
{
    Input,
    Target,
    FindWithTag,
}

public class Movement : MonoBehaviour
{
    [SerializeField]
    private MovementType movementType;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private string targetTag;
    [SerializeField]
    private bool lookAtTarget;
    [SerializeField]
    private float moveSpeed = 5f;

    private Animator animator;
    private Rigidbody2D rigidBody;

    private bool destoryWhenOut = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();

        InitTarget();

        if (lookAtTarget && target != null)
        {
            LookAt();
        }
    }

    void FixedUpdate()
    {
        Vector2 direction = GetDirection();

        if (lookAtTarget)
        {
            MoveToDirection(direction);
            return;
        }

        if (direction.x != 0f || direction.y != 0f)
        {
            UpdateAnimation(direction);

            MoveToDirection(direction);
        }
    }

    void InitTarget()
    {
        if (movementType == MovementType.Target)
        {
            if (target == null)
            {
                Debug.Log("Target을 찾지 못했습니다");
                Destroy(gameObject);
            }
        }
        else if (movementType == MovementType.FindWithTag)
        {
            target = GameObject.FindGameObjectWithTag(targetTag);
        }
    }

    Vector2 GetDirection()
    {
        if (lookAtTarget)
        {
            return transform.up;
        }

        switch (movementType)
        {
            case MovementType.Input:
                return GetInputDirection();
            case MovementType.Target:
            case MovementType.FindWithTag:
                return GetDirectionToTarget();
            default:
                throw new Exception("사용하지 않는 MovementType 입니다");
        }
    }

    Vector2 GetInputDirection()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        return new Vector3(horizontal, vertical).normalized;
    }

    Vector2 GetDirectionToTarget()
    {
        if (target == null)
        {
            return Vector2.zero;
        }

        return (target.transform.position - transform.position).normalized;
    }

    void UpdateAnimation(Vector2 direction)
    {
        if (animator == null)
        {
            return;
        }

        if (animator.HasParameter("IsLeft"))
        {
            bool isLeft = direction.x < 0.0f;

            animator.SetBool("IsLeft", isLeft);
        }
    }

    void MoveToDirection(Vector2 direction)
    {
        Vector3 translation = direction * moveSpeed * Time.deltaTime;
        Vector3 nextPosition = (translation + transform.position).Limit();

        if (destoryWhenOut && MovementBoundary.IsInside(nextPosition, RestrictionType.Object) == false)
        {
            Destroy(gameObject);
        }

        rigidBody.MovePosition(nextPosition);
    }

    void LookAt()
    {
        if (UseTarget() == false)
        {
            return;
        }

        if (target == null)
        {
            return;
        }

        Vector2 direction = target.transform.position - transform.position;

        float radian = Mathf.Atan2(direction.y, direction.x);
        float degree = radian * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(degree - 90.0f, Vector3.forward);
    }

    bool UseTarget()
    {
        switch (movementType)
        {
            case MovementType.Input:
                return false;
            case MovementType.Target:
            case MovementType.FindWithTag:
                return true;
            default:
                throw new Exception("사용하지 않는 MovementType 입니다");
        }
    }

    public Movement SetTarget(GameObject obj)
    {
        target = obj;
        return this;
    }

    public Movement SetDestroyWhenOut(bool destroy)
    {
        destoryWhenOut = destroy;
        return this;
    }
}