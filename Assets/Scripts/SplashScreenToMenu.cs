using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenToMenu : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(10.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
