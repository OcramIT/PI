using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneSwitcher : MonoBehaviour
{
    public GameObject CutSceneDiogo;
    public PlayableDirector TimeLineDiogo;


    public GameObject CameraMarco;
    public GameObject TimelineMarcoObject;
    public PlayableDirector TimeLineMarco;
    public void MostraDiogo()
    {

        if (TimelineMarcoObject.activeSelf)
        {
            TimeLineMarco.Stop();
            CameraMarco.SetActive(false);
            TimelineMarcoObject.SetActive(false);
        }
        if (CutSceneDiogo.activeSelf)
        {
            TimeLineDiogo.Stop();
            TimeLineDiogo.Play();
        }
        else
        {
            CutSceneDiogo.SetActive(true);
            TimeLineDiogo.Play();
        }

    }

    public void MostraMarco()
    {
        if (CutSceneDiogo.activeSelf)
        {
            TimeLineDiogo.Stop();
            CutSceneDiogo.SetActive(false);
        }

        if (TimelineMarcoObject.activeSelf && CameraMarco.activeSelf)
        {
            TimeLineMarco.Stop();
            TimeLineMarco.Play();

        }
        else
        {
            TimelineMarcoObject.SetActive(true);
            CameraMarco.SetActive(true);
            TimeLineMarco.Play();
        }
        
    }
}
