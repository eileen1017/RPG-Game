using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackEnemy : MonoBehaviour
{
    [SerializeField] private float thrust;
    [SerializeField] private float knockTime;
    [SerializeField] private string otherTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if (other.gameObject.CompareTag("hittable") && this.gameObject.CompareTag("Projectile"))
        {
            other.GetComponent<Vase>().Smash();
        }
        */
        if (other.gameObject.CompareTag(otherTag))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                
                if (other.gameObject.CompareTag("Player"))
                {
                    if (other.GetComponent<PlayerController>().currentState != PlayerState.stagger)
                    {
                        hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                        other.GetComponent<Enemy>().Knock(hit, knockTime);
                    }
                   
                }
                if (other.gameObject.CompareTag("Enemies") && other.isTrigger)
                {
                    hit.GetComponent<PlayerController>().currentState = PlayerState.stagger;
                    other.GetComponent<PlayerController>().Knock(knockTime);
                }

            }
        }
    }

}
