using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] GameObject doorToDestroy;
    [SerializeField] GameObject doorToShow;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.UnloadSceneAsync("florest");
            SceneManager.LoadScene("HospitalInterior", LoadSceneMode.Additive);
            Destroy(doorToDestroy);
            doorToShow.SetActive(true);
            Destroy(gameObject);
        }
    }

    //void OnGUI()
    //{
    //    //This displays a Button on the screen at position (20,30), width 150 and height 50. The button?s text reads the last parameter. Press this for the SceneManager to load the Scene.
    //    if (GUI.Button(new Rect(20, 30, 150, 30), "Other Scene Single"))
    //    {
    //        //The SceneManager loads your new Scene as a single Scene (not overlapping). This is Single mode.
    //        SceneManager.LoadScene("YourScene", LoadSceneMode.Single);
    //    }

    //    //Whereas pressing this Button loads the Additive Scene.
    //    if (GUI.Button(new Rect(20, 60, 150, 30), "Other Scene Additive"))
    //    {
    //        //SceneManager loads your new Scene as an extra Scene (overlapping the other). This is Additive mode.
    //        SceneManager.LoadScene("YourScene", LoadSceneMode.Additive);
    //    }
    //}
}
