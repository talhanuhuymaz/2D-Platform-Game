using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public float bulletLife = 1f;
    bool isMoving = true;
    public float rotationSpeed = 200;
    [SerializeField] Transform rotateAround;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Invoke("DestroyBullet",bulletLife);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isMoving)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
            isMoving = false;
            DestroyBullet();
        }
    }
    public void DestroyBullet()
    {
        rb.gravityScale = 2;
    }
    private void Update()
    {
        if (transform.position.y <= -20)
        {
            Shooting.bulletNumber += 1;
            Destroy(gameObject);
        }
        if (isMoving)
        {
            transform.RotateAround(rotateAround.position, new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
        }
        if (rb.velocity == Vector2.zero)
        {
            isMoving = false;
        }
    }
}
