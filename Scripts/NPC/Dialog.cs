using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog : MonoBehaviour
{
    public GameObject dialogBoard;
    public TextMeshProUGUI dialogText;
    public string dialog;
    public bool playerInRange;

    public SignalScript dialogOn;
    public SignalScript dialogOff;

    public AchievementInfo friendly;

    public NPCTracker _NPCTracker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void checkNPC()
    {
        if (gameObject.name == "Village")
        {
            _NPCTracker.Village = true;
        }
        else if (gameObject.name == "Desert")
        {
            _NPCTracker.Desert = true;
        }
        else if (gameObject.name == "Island")
        {
            _NPCTracker.Island = true;
        }
        else if (gameObject.name == "Lava")
        {
            _NPCTracker.Lava = true;
        }
        else if (gameObject.name == "Underground")
        {
            _NPCTracker.Underground = true;
        }

        if (_NPCTracker.Village && _NPCTracker.Desert && _NPCTracker.Island && _NPCTracker.Lava && _NPCTracker.Underground)
        {
            if (!friendly.isAchieved)
            {
                friendly.isAchieved = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && playerInRange)
        {
            if (dialogBoard.activeInHierarchy)
            {
                dialogBoard.SetActive(false);
            }
            else
            {
                checkNPC();
                dialogBoard.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogOn.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogOff.Raise();
            playerInRange = false;
            dialogBoard.SetActive(false);
        }
    }
}
