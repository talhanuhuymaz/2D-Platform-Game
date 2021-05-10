using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    
    public float total_coin;
    public float hitForce;
    [SerializeField] Rigidbody2D playerRB;

    public static float health = 100;
    public float MaxHealth;
    public ParticleSystem dieEffect;
    public ParticleSystem hitEffect;

    // Start is called before the first frame update
    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -16)
        {
            StartCoroutine(PlayerDieinTime());
            this.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            AudioManager.instance.PlaySound("coin");
            PlayerHeal(25);
            total_coin++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Trigger") && LevelManagerScript.instance.isDialogueStarted == false)
        {
            LevelManagerScript.instance.isDialogueStarted = true;
            DialogueTrigger.instance.TriggerDialogue();
        }
        if (collision.gameObject.CompareTag("Baby"))
        {
            LevelManagerScript.instance.GotoNextScene();
            AudioManager.instance.PlaySound("win");
        }
        if (collision.gameObject.CompareTag("RespawnPoint"))
        {
            LevelManagerScript.instance.UpdateRespawnPoint(collision.transform);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerTakeDamage(25);
            Vector2 force = transform.position - collision.transform.position;
            force.Normalize();
            playerRB.AddForce(force * hitForce);

        }
    }
    void PlayerTakeDamage(int damage)
    {
        AudioManager.instance.PlaySound("damage");
        health -= damage;
        if (health <= 0)
        {
            StartCoroutine(PlayerDieinTime());
        }
        HealthBarScript.instance.SetHealth(health);
        hitEffect.Play();
    }
    void PlayerDie()
    {
        Destroy(gameObject);
        GameObject respawnedPlayer = LevelManagerScript.instance.Respawn();
        playerRB = respawnedPlayer.GetComponent<Rigidbody2D>();
        health = MaxHealth;
        dieEffect.Play();
    }
    void PlayerHeal(int healPoint)
    {
        if (health < MaxHealth)
        {
            health += healPoint;
        }
        HealthBarScript.instance.SetHealth(health);
    }
    IEnumerator PlayerDieinTime()
    {
        dieEffect.Play();
        AudioManager.instance.PlaySound("die");
        GetComponent<SpriteRenderer>().sortingLayerName = "Grounds";
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        GameObject respawnedPlayer = LevelManagerScript.instance.Respawn();
        playerRB = respawnedPlayer.GetComponent<Rigidbody2D>();
        health = MaxHealth;
        HealthBarScript.instance.SetHealth(health);
    }
}
