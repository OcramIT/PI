using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfPrototype : MonoBehaviour
{
    [SerializeField] GameObject FimPrototypeText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FimPrototypeText.SetActive(true);
            other.GetComponent<FirstPersonController>().enabled = false;
        }
    }
}
