using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TutorialController : MonoBehaviour
{
    public static TutorialController instance; 
    public Button tutorialButton; 
    public Text tutorialText;
    public int numOfClicks;

    void Awake()
    {
        instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        numOfClicks = 0;
        //score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDisplay()
    {
        if (numOfClicks == 0)
        {
            tutorialText.text = "You have a special power to shoot fireballs. To shoot, aim with your mouse and press down.";
            numOfClicks += 1;
        }

        else if (numOfClicks == 1)
        {
            tutorialText.text = "The goal of the game is to explore the map and shoot as many ghosts as you can without dying!";
            numOfClicks += 1;
        }

        else if (numOfClicks == 2)
        {
            tutorialText.text = "Press the esc button to pull up the main menu. This will pause the game!";
            numOfClicks += 1; 
        }
        else if(numOfClicks == 3)
        {
            tutorialText.text = "Press t when you are close to characters! They may give you some hints on where to go next!";
            numOfClicks += 1; 
        }
        else if(numOfClicks == 4)
        {
            tutorialText.text = "Press i to check out the inventory manual -- see what items you have in stock!";
            numOfClicks += 1; 
        }
        else if(numOfClicks == 5)
        {
            tutorialText.text = "Good luck on your journey!  The town needs your help! Click to start the game.";
            numOfClicks += 1; 
        }
        else if (numOfClicks == 6)
        {
            tutorialButton.gameObject.SetActive(false);
        }
    }


}
