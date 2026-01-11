using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float timeBetweenAttacks = 0.5f;
    [SerializeField] private float attackRadius;
    [SerializeField] private Animator anim;
    [SerializeField] private Player player; 

    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeBetweenAttacks && Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
            timer = 0;
        }

        
    }

    //this method will be called through the animation event
    private void AttackHit()
    {
        Collider2D[] results = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);
        foreach (Collider2D item in results)
        {
            Debug.Log("test1");
            if (item.gameObject.CompareTag("Enemy"))
            {
                if (item.TryGetComponent(out IDamageable objectHit))
                {
                    Debug.Log("test2");
                    objectHit.TakeDamage(player.attackDamage);
                }
            }
            Debug.Log("test3");

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
