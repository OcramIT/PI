using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject MainMenuObj;
    [SerializeField] GameObject OptionsObj;
    [SerializeField] GameObject CreditsObj;
    [SerializeField] GameObject Cutscene;
    [SerializeField] GameObject BGVideo;
    [SerializeField] GameObject SoundS;


    [SerializeField] CutscenePlayer CutPlayer;







    public void Play()
    {
        BGVideo.SetActive(false);
        MainMenuObj.SetActive(false);
        SoundS.SetActive(false);
        Cutscene.SetActive(true);
        StartCoroutine(StartGame());

    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(80f);
        SceneManager.LoadScene("AssetsParaSeManterem");
        SceneManager.LoadScene("florest", LoadSceneMode.Additive);
    }

    public void Options()
    {
        MainMenuObj.SetActive(false);
        OptionsObj.SetActive(true);
    }

    public void Credits()
    {
        MainMenuObj.SetActive(false);
        CreditsObj.SetActive(true);
    }

    public void BackButton()
    {
        CreditsObj.SetActive(false);
        OptionsObj.SetActive(false);
        MainMenuObj.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
