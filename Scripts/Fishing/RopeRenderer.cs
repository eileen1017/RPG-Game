using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [SerializeField]
    private Transform ropeStartPoint;

    private float lineWidth = 0.05f;


    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;

        lineRenderer.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RenderLine(Vector3 endPosition, bool enableRenderer)
    {
        if (enableRenderer)
        {
            if (!lineRenderer.enabled)
            {
                lineRenderer.enabled = true;
            }

            lineRenderer.positionCount = 2;
        }
        else
        {
            lineRenderer.positionCount = 0;
            if (lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
            }
        }

        if (lineRenderer.enabled)
        {
            Vector3 t = ropeStartPoint.position;
            t.z = 0f;
            ropeStartPoint.position = t;

            t = endPosition;
            t.z = 0f;

            endPosition = t;

            lineRenderer.SetPosition(0, ropeStartPoint.position);
            lineRenderer.SetPosition(1, endPosition);


        }
    }
}
