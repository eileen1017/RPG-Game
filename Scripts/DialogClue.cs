using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogClue : MonoBehaviour
{
    public GameObject dialogClue;

    // Start is called before the first frame update
    public void Enable()
    {
        dialogClue.SetActive(true);
    }

    // Update is called once per frame
    public void Disable()
    {
        dialogClue.SetActive(false);
    }
}
