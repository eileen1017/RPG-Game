using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryPauseManager : MonoBehaviour
{
    private bool isPause;
    public GameObject inventoryPaused;
    public GameObject menuPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isPause = !isPause;
            if (isPause)
            {
                inventoryPaused.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                inventoryPaused.SetActive(false);
                Time.timeScale = 1f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
            if (isPause)
            {
                menuPaused.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                menuPaused.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    public void Resume()
    {
        isPause = !isPause;
    }

}
