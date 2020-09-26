using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWrapper : MonoBehaviour
{
    Rigidbody2D myrigidbody;
    

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
    }




    // Update is called once per frame
    void Update()
    {
        myrigidbody.velocity = Vector2.left * 300;
    }

}
