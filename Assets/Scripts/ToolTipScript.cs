using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToolTipScript : MonoBehaviour
{
    Animator animComponent;

    private void Start()
    {
        animComponent = GetComponent<Animator>();
    }
    public void ShowToolTip( string TTtext)
    {
        GetComponent<TextMeshProUGUI>().text = TTtext;

        StartCoroutine(DisableObject());
        
    }

    IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(5f);
        animComponent.SetTrigger("Disappear");
    }
    public void DisableText()
    {
        gameObject.SetActive(false);
    }
}
