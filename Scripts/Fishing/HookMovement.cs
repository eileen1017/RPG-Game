using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HookMovement : MonoBehaviour
{
    //rotation z
    public float minZ, maxZ;
    public float rotateSpeed;

    public bool canCatch;
    private float rotateAngle;
    private bool rotateRight;
    private bool canRotate;


    public float moveSpeed;
    private float initialMoveSpeed;

    public float minY;
    private float initialY;

    private bool moveDown;

    public SignalScript healthSignal;

    private RopeRenderer fishinglineRender;

    void Awake()
    {
        fishinglineRender = GetComponent<RopeRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        initialY = transform.position.y;
        initialMoveSpeed = moveSpeed;
        canRotate = true;
        healthSignal.Raise();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        GetInput();
        MoveRope();
    }

    void Rotate()
    {
        if (!canRotate)
            return;

        if (rotateRight)
        {
            rotateAngle += rotateSpeed * Time.deltaTime;
        }
        else
        {
            rotateAngle -= rotateSpeed * Time.deltaTime;
        }

        transform.rotation = Quaternion.AngleAxis(rotateAngle, Vector3.forward);

        if (rotateAngle >= maxZ)
        {
            rotateRight = false;
        } 
        else if (rotateAngle <= minZ)
        {
            rotateRight = true;
        }
    }

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            if (canRotate)
            {
                canRotate = false;
                moveDown = true;
            }
        }
    }

    void MoveRope()
    {
        if (canRotate)
        {
            return;
        }

        if (!canRotate)
        {
            Vector3 tempPos = transform.position;
            Destroy(GameObject.FindWithTag("Projectile"));

            if (moveDown)
            {
                tempPos -= transform.up * Time.deltaTime * moveSpeed;
            } 
            else
            {
                tempPos += transform.up * Time.deltaTime * moveSpeed;
            }

            transform.position = tempPos;

            if (tempPos.y <= minY)
            {
                moveDown = false;
                canCatch = true;
            }

            if (tempPos.y >= initialY)
            {
                canRotate = true;
                canCatch = false;
                fishinglineRender.RenderLine(tempPos, false);
                moveSpeed = initialMoveSpeed;
            }

            fishinglineRender.RenderLine(transform.position, true);
        }
    }

    public void HookAttackedItem()
    {
        moveDown = false;
    }
}
