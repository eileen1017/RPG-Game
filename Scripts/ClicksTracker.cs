using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClicksTracker : MonoBehaviour
{
    public static int totalClicks = 0;
    public KeyCode mouseCode;

    public VectorValue characterStor;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(mouseCode))
        {
            totalClicks += 1;
        }
        if (totalClicks >= 5)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
