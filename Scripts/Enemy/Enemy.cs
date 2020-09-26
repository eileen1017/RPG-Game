using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}
public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public float moveSpeed;
    public int currentHealth;
    public GhostKilled gKilled;

    public AchievementInfo killOne;
    public AchievementInfo killTen;

    public SignalScript ghostSignal;

    public void Damage(int amount)
    {
        NewMethod();
        currentHealth -= amount;
        moveSpeed /= 2;
        GetComponent<SpriteRenderer>().color += new Color(255f / 255f, 251f / 255f, 123f / 255f, 1f);
        GetComponent<SpriteRenderer>().color /= 2;


        if (currentHealth <= 0)
        {
            SoundManager.instance.PlayKillGhost();
            gKilled.ghostKilled++;
            ghostSignal.Raise();
            if (!killOne.isAchieved)
            {
                killOne.isAchieved = true;
            }
            if (gKilled.ghostKilled == 10 && !killTen.isAchieved)
            {
                killTen.isAchieved = true;
            }

            Destroy(gameObject);

        }
    }

    private static void NewMethod()
    {
        SoundManager.instance.PlayHitGhost();
    }

    public void Knock(Rigidbody2D myrb, float knockTime)
    {
        StartCoroutine(KnockCo(myrb, knockTime));
    }

    private IEnumerator KnockCo(Rigidbody2D myrb, float knockTime)
    {
        if (myrb != null)
        {
            yield return new WaitForSeconds(knockTime);
            myrb.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myrb.velocity = Vector2.zero;
        }
    }
}
