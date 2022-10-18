using System.Collections;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject sword;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Fire");
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Instantiate(sword, transform.position, Quaternion.identity)
                .GetComponent<Weapon>()
                .LootAt(mousePosition);

            yield return new WaitForSeconds(1);
        }
    }
}
