using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorScript : MonoBehaviour
{
    public GameObject Peter;
    public GameObject Lin;
    public GameObject Viv;
    public GameObject Aditya;
    private int characterInt = 1;



    private SpriteRenderer peterRender, linRender, vivRender, adityaRender;

    private readonly string selectedChar = "SelectedCharacter"; 

    private Vector3 CharacterPosition;
    private Vector3 OffScreenPosition;

    private void Awake()
    {
        CharacterPosition = Peter.transform.position;
        OffScreenPosition = Lin.transform.position;

        peterRender = Peter.GetComponent<SpriteRenderer>();
        linRender = Peter.GetComponent<SpriteRenderer>();
        vivRender = Peter.GetComponent<SpriteRenderer>();
        adityaRender = Peter.GetComponent<SpriteRenderer>();
    }

    public void NextCharacter()
    { 
        switch (characterInt)
        {
            case 1:
         
                PlayerPrefs.SetInt(selectedChar, 1);
                peterRender.enabled = false;
                Peter.transform.position = OffScreenPosition;
                Lin.transform.position = CharacterPosition;
                linRender.enabled = true;
                characterInt++; 
                break;
            case 2:
                
                PlayerPrefs.SetInt(selectedChar, 2);
                linRender.enabled = false;
                Lin.transform.position = OffScreenPosition;
                Viv.transform.position = CharacterPosition;
                vivRender.enabled = true;
                characterInt++;
                break;
            case 3:
                
                PlayerPrefs.SetInt(selectedChar, 3);
                vivRender.enabled = false;
                Viv.transform.position = OffScreenPosition;
                Aditya.transform.position = CharacterPosition;
                adityaRender.enabled = true;
                characterInt++;
                break;
            case 4:
                
                PlayerPrefs.SetInt(selectedChar, 4);
                adityaRender.enabled = false;
                Aditya.transform.position = OffScreenPosition;
                Peter.transform.position = CharacterPosition;
                peterRender.enabled = true;
                characterInt = 1;
                break;
            default:
                break; 
        }
    }

    public void PrevCharacter()
    {
        switch (characterInt)
        {
            case 1:
                
                PlayerPrefs.SetInt(selectedChar, 3);
                peterRender.enabled = false;
                Peter.transform.position = OffScreenPosition;
                Aditya.transform.position = CharacterPosition;
                adityaRender.enabled = true;
                characterInt++;
                break;
            case 2:
                
                PlayerPrefs.SetInt(selectedChar, 2);
                adityaRender.enabled = false;
                Aditya.transform.position = OffScreenPosition;
                Viv.transform.position = CharacterPosition;
                vivRender.enabled = true;
                characterInt++;
                break;
            case 3:
                
                PlayerPrefs.SetInt(selectedChar, 1);
                vivRender.enabled = false;
                Viv.transform.position = OffScreenPosition;
                Lin.transform.position = CharacterPosition;
                linRender.enabled = true;
                characterInt++;
                break;
            case 4:
               
                PlayerPrefs.SetInt(selectedChar, 4);
                linRender.enabled = false;
                Lin.transform.position = OffScreenPosition;
                Peter.transform.position = CharacterPosition;
                peterRender.enabled = true;
                characterInt = 1;
                break;
            default:
                break;
        }
    }

    public void ChangeScene()
    {
        
        SceneManager.LoadScene(0);

    }

}
