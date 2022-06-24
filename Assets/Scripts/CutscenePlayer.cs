using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutscenePlayer : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    public bool startCut;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!startCut) return;


    }
}
