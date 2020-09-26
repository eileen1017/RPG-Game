using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CloseHidden : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 characterPosition;
    public VectorValue characterStor;
    public KeyFlag keyflag;

    public Vector2 cameraNewMax;
    public Vector2 cameraNewMin;
    public VectorValue cameraMin;
    public VectorValue cameraMax;

    public AchievementInfo keyGot;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        ResetCameraBounds();
        if (HiddenControl.remainItems > 0)
        {
            characterStor.initialValue = characterPosition;
            keyflag.keyFlag = false;
            SceneManager.LoadScene(sceneToLoad);
        } 
        else if (HiddenControl.remainItems == 0)
        {
            if (!keyGot.isAchieved)
            {
                keyGot.isAchieved = true;
            }
            characterStor.initialValue = characterPosition;
            keyflag.keyFlag = true;
            SceneManager.LoadScene(sceneToLoad);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetCameraBounds()
    {
        cameraMax.initialValue = cameraNewMax;
        cameraMin.initialValue = cameraNewMin;
    }
}
