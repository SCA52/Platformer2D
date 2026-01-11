using UnityEngine;

public class Hook : MonoBehaviour
{
    private float timer;
    private float timeBetweenAttacks;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //timer > timeBetweenAttacks &&
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hook = Physics2D.Raycast(transform.position, Input.mousePosition, 10);

            if (hook.rigidbody.gameObject.CompareTag("StaticPoint"))
            {
                Debug.Log("hit static");
                
                Rigidbody2D rbHit = hook.rigidbody;
                GetComponentInParent<Transform>().transform.position = rbHit.position;
            }
            else if (hook.collider.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("hit enemy");
                hook.transform.position = transform.position;
            }

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, Input.mousePosition);
    }
}
