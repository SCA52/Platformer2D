using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LightTransport;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private float movementForce;
    [SerializeField] private float jumpForce;
    [SerializeField] private UnityEngine.UI.Image healthBar;

    private float hInput;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector3 knockback;
    private bool jumpAvailable;

    internal float attackDamage;
    private float health;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        jumpAvailable = true;
        attackDamage = 2f;
        health = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        anim.SetFloat("xSpeed", Mathf.Abs(hInput));
        anim.SetFloat("ySpeed", rb.linearVelocityY);
        FaceMovement();

        if(Input.GetKeyDown(KeyCode.Space) && jumpAvailable == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }
    private void FaceMovement()
    {
        if(hInput < 0 && transform.eulerAngles.y == 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (hInput > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
    private void FixedUpdate()
    {
        //normalizes a value (health) from 0 to 1 (value - maxvalue)/ (maxvalue - minvalue)
        healthBar.fillAmount = (health - 0)/(100 - 0);
        rb.AddForce(new Vector2(hInput, 0) * movementForce, ForceMode2D.Force);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        rb.AddForce(knockback * -20, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //to calculate knockback, we get the direction by the position of the other collision - current position 
            Vector3 facing = collision.transform.position - transform.position;
            //distance is the magnitude of the direction
            float distance = facing.magnitude;
            //divide direction by distance
            knockback = facing / distance;
            TakeDamage(attackDamage);
        }
    }
}
