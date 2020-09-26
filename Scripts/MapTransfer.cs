using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MapTransfer : MonoBehaviour
{
    public Vector2 minCameraChange;
    public Vector2 maxCameraChange;
    public Vector3 playerChange;
    private CameraMovement c;
    public string mapName;
    public Text mapText;
    public bool requireText;
    public GameObject textWrapper;
    Vector3 originalPos;

    public MapTravelTracker MTT;
    public AchievementInfo Traveler;

    // Start is called before the first frame update
    void Start()
    {
        c = Camera.main.GetComponent<CameraMovement>();
        originalPos = new Vector3(textWrapper.transform.position.x, textWrapper.transform.position.y, textWrapper.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CheckMapTravel()
    {
        if (mapName != "")
        {
            if (mapName == "Desert" && !MTT.Desert)
            {
                MTT.Desert = true;
            }
            else if (mapName == "Village" && !MTT.Village)
            {
                MTT.Village = true;
            }
            else if (mapName == "Lava" && !MTT.Lava)
            {
                MTT.Lava = true;
            }
            else if (mapName == "Underground" && !MTT.Underground)
            {
                MTT.Underground = true;
            }
            else if (mapName == "Island" && !MTT.Island)
            {
                MTT.Island = true;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            c.minPos += minCameraChange;
            c.maxPos += maxCameraChange;
            other.transform.position += playerChange;
            if (requireText)
            {
                CheckMapTravel();
                StartCoroutine(TextWrapperCo());
                textWrapper.transform.position = originalPos;
            }
        }
    }
    

    private IEnumerator TextWrapperCo()
    {
        yield return new WaitForSeconds(0.5f);
        textWrapper.SetActive(true);
        mapText.text = mapName;
        float distanceFromCamera = Camera.main.nearClipPlane; // Change this value if you want
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.8f, distanceFromCamera));
        Instantiate(textWrapper, topRight, Quaternion.identity);
        yield return new WaitForSeconds(4f);
        textWrapper.SetActive(false);
    }
}
