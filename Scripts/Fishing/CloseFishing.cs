using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CloseFishing : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 characterPosition;
    public VectorValue characterStor;

    public Vector2 cameraNewMax;
    public Vector2 cameraNewMin;
    public VectorValue cameraMin;
    public VectorValue cameraMax;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        ResetCameraBounds();
        characterStor.initialValue = characterPosition;
        SceneManager.LoadScene(sceneToLoad);
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
