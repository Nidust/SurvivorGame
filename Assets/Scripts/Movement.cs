using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(
            x: horizontal * moveSpeed * Time.deltaTime, 
            y: vertical * moveSpeed * Time.deltaTime, 
            z: 0f
        );

        UpdateAnimation(horizontal);
    }

    private void UpdateAnimation(float horizontal)
    {
        animator.SetFloat("horizontal", horizontal);
    }
}
