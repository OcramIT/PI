using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOffBounds : MonoBehaviour
{
    [SerializeField] GameObject outOfBoundsText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) outOfBoundsText.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) outOfBoundsText.SetActive(false);
    }
}
