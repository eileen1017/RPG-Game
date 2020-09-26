using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiddenControl : MonoBehaviour
{
    public static string objName;
    public static int remainKeys = 3;

    public GameObject objText;
    public static int remainItems = 10;
    public Transform succseeClick;
    public KeyFlag kf;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        objName = gameObject.name;
        if ((gameObject.name == "key") && (remainKeys > 1))
        {
            remainKeys--;
            objText.GetComponent<TextMesh>().text = "Keys x" + remainKeys;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Destroy(objText);
            remainItems--;
        }
        ClicksTracker.totalClicks = 0;
        Instantiate(succseeClick, objText.transform.position, succseeClick.rotation);

        /*
        if (remainItems == 0)
        {
            kf.keyFlag = true;

        }
        */

    }
}
