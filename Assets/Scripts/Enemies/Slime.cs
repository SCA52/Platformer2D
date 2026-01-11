using UnityEngine;

public class Slime : MonoBehaviour, IDamageable
{
    [SerializeField] private float health;
    
    private Rigidbody2D rb;
    private float damage;
    private Vector3 knockback;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damage = 10;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0)
        {
            enabled = false;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        rb.AddForce(knockback * -20, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out IDamageable objectHit))
        {
            Vector3 facing = collision.transform.position - transform.position;
            float distance = facing.magnitude;
            knockback = facing / distance;
            objectHit.TakeDamage(damage);
        }
    }
}
