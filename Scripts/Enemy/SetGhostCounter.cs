using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGhostCounter : MonoBehaviour
{
    public Text textScore;
    public GhostKilled gKilled;

    // Start is called before the first frame update
    void Start()
    {
        textScore.text = "Ghosts killed: " + gKilled.ghostKilled.ToString();
    }

    // Update is called once per frame
    public void Update()
    {
        textScore.text = "Ghosts killed: " + gKilled.ghostKilled.ToString();
    }
}
