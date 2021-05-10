using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 100;
    public Transform groundCheck;
    public float speed;
    public LayerMask layer;

    public ParticleSystem effect;
    public ParticleSystem effect2;
    private bool movingLeft = true;
    private bool isDead = false;
    Animator animator;

    public void TakeDamage(int damage)
    {
        AudioManager.instance.PlaySound("enemydamage");
        effect2.Play();
        health -= damage;
        if (health<= 0)
        {
            Die();
        }
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Die()
    {
        effect.Play();
        isDead = true;
        animator.SetBool("isDead", true);
        GetComponent<CapsuleCollider2D>().enabled = false;
        Destroy(gameObject,1f);
    }
    private void OnDestroy()
    {
        animator.SetBool("StopAllAnim", true);
    }
    private void Update()
    {
        if (!isDead)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector3.down, 2f, layer);
            RaycastHit2D groundInfoLeft = Physics2D.Raycast(groundCheck.position, Vector3.left, 0.2f, layer);
            RaycastHit2D groundInfoRight = Physics2D.Raycast(groundCheck.position, Vector3.right, 0.2f, layer);
            if (groundInfo.collider == false)
            {
                ChangeDirection();
            }
            if (groundInfoLeft.collider == true || groundInfoRight.collider == true)
            {
                ChangeDirection();
            }
        }
    }
    void ChangeDirection()
    {
        if (movingLeft)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingLeft = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingLeft = true;
        }
    }
}
