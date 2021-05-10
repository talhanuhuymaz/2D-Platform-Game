using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeattack : MonoBehaviour
{
    public Animator anm;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    private bool playing;
  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            AudioManager.instance.PlaySound("whoosh");
            Attack();
        }
    }

    void Attack()
    {
        if (!playing)
        {
            playing = true;
            anm.ResetTrigger("AttackStop");
            anm.SetTrigger("Attack");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


            foreach (Collider2D enemy in hitEnemies)
            {

                enemy.GetComponent<EnemyScript>().TakeDamage(attackDamage);

            }
            Invoke(nameof(StopAnimation), 0.2f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;


        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }

    void StopAnimation()
    {
        playing = false;
        anm.ResetTrigger("Attack");
        anm.SetTrigger("AttackStop");
    }

}
