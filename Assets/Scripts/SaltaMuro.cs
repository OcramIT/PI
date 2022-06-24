using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class SaltaMuro : MonoBehaviour
{
    [SerializeField] Transform destinationPlace;
    [SerializeField] GameObject JumpText;
    private float myFloat;

    public bool isCompleted=false;


    private void Start()
    {
        JumpText = GameObject.FindGameObjectWithTag("JumpText");
        JumpText.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        JumpText.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (other.GetComponent<FirstPersonController>().shouldJump)
                {
                    other.transform.DOJump(destinationPlace.position, 2f, 1, 1);

                    other.GetComponent<FirstPersonController>().shouldJump = false;
                    StartCoroutine(Delay());
                    other.GetComponent<FirstPersonController>().shouldJump = true;
                }
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        JumpText.SetActive(false);
    }



    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
    }
}
