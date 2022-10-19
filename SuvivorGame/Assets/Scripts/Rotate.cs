using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float turnSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
    }
}
