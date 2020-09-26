using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CloseShop : MonoBehaviour
{
    public string sceneToLoad;
    public PreviousMap _pname;
    
    public VectorValue characterStor;

    public Vector2 DcharacterPosition;
    public Vector2 DcameraNewMax;
    public Vector2 DcameraNewMin;

    public Vector2 IcharacterPosition;
    public Vector2 IcameraNewMax;
    public Vector2 IcameraNewMin;


    public VectorValue cameraMin;
    public VectorValue cameraMax;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }


    void OnClick()
    {
        if (_pname.mName == "Desert")
        {
            ResetDCameraBounds();
            characterStor.initialValue = DcharacterPosition;
            SceneManager.LoadScene(sceneToLoad);
        }
        if (_pname.mName == "Island")
        {
            ResetICameraBounds();
            characterStor.initialValue = IcharacterPosition;
            SceneManager.LoadScene(sceneToLoad);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetDCameraBounds()
    {
        cameraMax.initialValue = DcameraNewMax;
        cameraMin.initialValue = DcameraNewMin;
    }

    public void ResetICameraBounds()
    {
        cameraMax.initialValue = IcameraNewMax;
        cameraMin.initialValue = IcameraNewMin;
    }
}
