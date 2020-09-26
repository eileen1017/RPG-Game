using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResePosition : MonoBehaviour
{
    public Vector3 resetPoint;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var playerObject = GameObject.FindGameObjectWithTag("Player");
            playerObject.transform.position = resetPoint;
        }
    }
}
