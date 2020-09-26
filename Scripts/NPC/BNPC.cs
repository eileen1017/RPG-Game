using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BNPC : Interactable
{
    private Vector3 characterDirection;
    private Transform trans;
    public float speed;
    private Rigidbody2D myrigidbody;
    private Animator anim;
    public Collider2D bounds;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        myrigidbody = GetComponent<Rigidbody2D>();
        DirectionChanged();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerInRange)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 t = trans.position + characterDirection * speed * Time.deltaTime;
        if (bounds.bounds.Contains(t))
        {
            myrigidbody.MovePosition(t);
        }
        else
        {
            DirectionChanged();
        }
        
    }

    void DirectionChanged()
    {
        int direction = Random.Range(0, 4);
       
        switch (direction)
        {
            case 0:
                characterDirection = Vector3.right;
                break;
            case 1:
                characterDirection = Vector3.up;
                break;
            case 2:
                characterDirection = Vector3.left;
                break;
            case 3:
                characterDirection = Vector3.down;
                break;
            default:
                break;
        }
        updateAnimation();
    }

    void updateAnimation()
    {
        anim.SetFloat("MoveX", characterDirection.x);
        anim.SetFloat("MoveY", characterDirection.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 temp = characterDirection;
        DirectionChanged();
        int loops = 0;
        while (temp == characterDirection && loops < 100)
        {
            loops++;
            DirectionChanged();
        }
    }
}
