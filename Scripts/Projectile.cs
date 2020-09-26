using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D myrigidbody;

    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myrigidbody.velocity = transform.right * 10f;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("hittable"))
        {
            other.GetComponent<Vase>().Smash();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
