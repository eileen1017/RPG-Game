using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    AudioSource audioSource; 
    public AudioClip hitGhost;
    public AudioClip killGhost;
    public AudioClip clickButton;
    public AudioClip loseHealth;
    public AudioClip inventory; 

    void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        instance = this;
    }

    public void PlayHitGhost()
    {
        audioSource.PlayOneShot(hitGhost); 
    }

    public void PlayKillGhost()
    {
        audioSource.PlayOneShot(killGhost);
    }

    public void ClickButton()
    {
        audioSource.PlayOneShot(clickButton);
    }

    public void LostHealth()
    {
        audioSource.PlayOneShot(loseHealth);
    }

    public void InventoryUptake()
    {
        audioSource.PlayOneShot(inventory); 
    }
}
