using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    private Animator anim;
    public GameObject[] itemsPrefabs;
    private Transform itemPos;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        itemPos = this.gameObject.transform;
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
        itemPos = this.gameObject.transform;
        anim.SetBool("smash", false);
    }
    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
        itemPos = this.gameObject.transform;
        anim.SetBool("smash", false);
    }

    public void Smash()
    {
        
        anim.SetBool("smash", true);
        StartCoroutine("breakCo");
        //Instantiate(randomItems, itemPos.position, Quaternion.identity);
    }

    IEnumerator breakCo()
    {
        GameObject randomItems = itemsPrefabs[Random.Range(0, itemsPrefabs.Length)];
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
        Instantiate(randomItems, itemPos.position, Quaternion.identity);
    }
}
