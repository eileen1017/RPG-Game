using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform originalPosition;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;

        //Vector3 healthPos = myRigidbody.transform.position + new Vector3(0,3,0);
        //ghostHealth.transform.SetPositionAndRotation(healthPos, Quaternion.identity);
        //var g = Instantiate(ghealth, healthPos, Quaternion.identity) as GameObject;
        //g.transform.parent = canvas.transform; 
        //currentHealth = maxHealth;
        //ghealth.GetComponent<HealthBar>().SetMaxHealth(maxHealth);

    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {

        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
             && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                
                ChangeState(EnemyState.walk);
                anim.SetBool("startWalking", true);
            }
            
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            anim.SetBool("startWalking", false);
        }
    }

    private void SetDirectionAnim(Vector2 setDirection)
    {
        anim.SetFloat("moveX", setDirection.x);
        anim.SetFloat("moveY", setDirection.y);
    }
    private void changeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetDirectionAnim(Vector2.right);
            } else if (direction.x < 0)
            {
                SetDirectionAnim(Vector2.left);
            }
        }else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetDirectionAnim(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetDirectionAnim(Vector2.down);
            }
        }
    }

    private void ChangeState(EnemyState nState)
    {
        if (currentState != nState)
        {
            currentState = nState;
        }
        
    }
}
