using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    [SerializeField]
    private Transform itemHolder;

    private bool itemAttached;
    private bool cantAttachedMore;

    private HookMovement hookMovement;

    public Transform[] SpawnPoints;
    public GameObject[] LeftFishPrefabs;
    public GameObject[] RightFishPrefabs;

    public PlayerHealth playerHealth;
    public SignalScript healthSignal;

    public float FishDelay = 2f;

    public FishCatched catched;

    private bool ropeUp;

    public AchievementInfo sharkGot;
    public AchievementInfo turtleGot;

    // Start is called before the first frame update
    void Awake()
    {
        hookMovement = GetComponentInParent<HookMovement>();
    }

    void Start()
    {
        StartCoroutine("FishSpawnTimer");
    }


    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D target)
    {
        if ((target.tag == Tags.LFish1 || target.tag == Tags.LFish3 ||
            target.tag == Tags.LFish5 || target.tag == Tags.LFish7 ||
            target.tag == Tags.RFish2 || target.tag == Tags.RFish4 ||
            target.tag == Tags.RFish6 || target.tag == Tags.RFish8 ||
            target.tag == Tags.LSha || target.tag == Tags.RTurt) && !cantAttachedMore && !hookMovement.canCatch)
        {
            itemAttached = true;
            cantAttachedMore = true;
            target.transform.parent = itemHolder;
            target.transform.position = itemHolder.position;
            target.GetComponent<Fish>().fishSpeed = 0;
            hookMovement.moveSpeed = target.GetComponent<Fish>().hookSpeed;
            hookMovement.HookAttackedItem();

        }

        if (target.tag == Tags.DeliverItem)
        {
            if (itemAttached)
            {
                itemAttached = false;
                cantAttachedMore = false;
                Transform objChild = itemHolder.GetChild(0);
                objChild.parent = null;
                if (objChild.gameObject.tag == Tags.LFish1 || objChild.gameObject.tag == Tags.LFish3 ||
                    objChild.gameObject.tag == Tags.LFish5 || objChild.gameObject.tag == Tags.LFish7 ||
                    objChild.gameObject.tag == Tags.RFish2 || objChild.gameObject.tag == Tags.RFish4 ||
                    objChild.gameObject.tag == Tags.RFish6 || objChild.gameObject.tag == Tags.RFish8)
                {
                    catched.fishCatched++;
                } 
                else if (objChild.gameObject.tag == Tags.LSha) 
                {
                    if (!sharkGot.isAchieved)
                    {
                        sharkGot.isAchieved = true;
                    }
                    catched.sharkCatched++;
                    playerHealth.playerHealth -= 10;
                    healthSignal.Raise();
                }
                else if (objChild.gameObject.tag == Tags.RTurt)
                {
                    if (!turtleGot.isAchieved)
                    {
                        turtleGot.isAchieved = true;
                    }
                    catched.turtleCatched++;
                }
                objChild.gameObject.SetActive(false);
            }
        }

    }

    IEnumerator FishSpawnTimer()
    {
        yield return new WaitForSeconds(FishDelay);

        SpawnFish();

        StartCoroutine("FishSpawnTimer");
    }

    void SpawnFish()
    {
        Transform RandomSpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        GameObject LeftRandomFishPrefabs = LeftFishPrefabs[Random.Range(0, LeftFishPrefabs.Length)];
        GameObject RightRandomFishPrefabs = RightFishPrefabs[Random.Range(0, RightFishPrefabs.Length)];

        if (RandomSpawnPoint.name.Contains("L"))
        {
            Instantiate(LeftRandomFishPrefabs, RandomSpawnPoint.position, Quaternion.identity);
        } else
        {
            Instantiate(RightRandomFishPrefabs, RandomSpawnPoint.position, Quaternion.identity);
        }
    }
 
}
