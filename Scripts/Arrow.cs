using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myrigidbody;
    public Transform target;
    public float attackRadius;
    public PlayerInfoObjects playerInfo;

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myrigidbody.velocity = transform.right * speed;
        target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {

        if (Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            Destroy(this.gameObject);
        }
        
    }

    public void Setup(Vector3 direction)
    {
        transform.rotation = Quaternion.Euler(direction);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("hittable")){
            other.GetComponent<Vase>().Smash();
        }
        if (other.CompareTag("Enemies")){
            other.GetComponent<Enemy>().Damage(playerInfo.damage);
        }
        Destroy(this.gameObject);
    }
}
