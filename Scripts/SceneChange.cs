using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [Header("New Scene Variables")]
    public string sceneToLoad;
    public Vector2 characterPosition;
    public VectorValue characterStor;
    public KeyFlag keyflag;
    public Vector2 cameraNewMax;
    public Vector2 cameraNewMin;
    public VectorValue cameraMin;
    public VectorValue cameraMax;
    public PreviousMap previousMap;

    public MapTravelTracker MTT;
    public AchievementInfo Traveler;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            ResetCameraBounds();
            CheckMapTravel();
            if (gameObject.name == "Lava2Hidden")
            {
                if (keyflag.keyFlag == true)
                {

                    Debug.Log("cannt enter scene.");
                }
                else
                {
                    characterStor.initialValue = characterPosition;
                    SceneManager.LoadScene(sceneToLoad);
                }
            }
            else
            {
                if (gameObject.name == "Desert2Shop")
                {
                    previousMap.mName = "Desert";

                }
                else if (gameObject.name == "Island2Shop")
                {
                    previousMap.mName = "Island";
                }
                characterStor.initialValue = characterPosition;
                SceneManager.LoadScene(sceneToLoad);
            }
            
        }
    }

    void CheckMapTravel()
    {
        if (sceneToLoad != "")
        {
            if (sceneToLoad == "Chapel" && !MTT.Church)
            {
                MTT.Church = true;
            }
            else if (sceneToLoad == "Undersea" && !MTT.Undersea)
            {
                MTT.Undersea = true;
            }
            
        }

        if (MTT.Desert && MTT.Village && MTT.Lava && MTT.Underground && MTT.Island && MTT.Church && MTT.Undersea)
        {
            if (!Traveler.isAchieved)
            {
                Traveler.isAchieved = true;
            }
        }
    }

    public void ResetCameraBounds()
    {
        cameraMax.initialValue = cameraNewMax;
        cameraMin.initialValue = cameraNewMin;
    }
}
