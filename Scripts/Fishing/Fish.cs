using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D rb;
    public float fishSpeed = 0.8f;
    public float hookSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name.Contains("R"))
        {
            rb.velocity = Vector2.left * fishSpeed;
        }
        else
        {
            rb.velocity = Vector2.right * fishSpeed;
        }

    }



    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
