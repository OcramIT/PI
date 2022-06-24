using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupObject : MonoBehaviour
{
    [SerializeField] enum TipoObjetos {Lamparina,Outro }
    [SerializeField] TipoObjetos tipoObjetos = TipoObjetos.Lamparina;

    [SerializeField] GameObject Player;

    [SerializeField] GameObject CercasInteiras;
    [SerializeField] GameObject CercasPartidas;
    [SerializeField] AudioSource audioSource;
    [SerializeField] CameraShaker camShaker;
    [SerializeField] GameObject mainCamera;

    [SerializeField] GameObject Lamparina;

    //[SerializeField] ToolTipScript TTRef;
    //[TextArea(0,8)]
    //[SerializeField] string pickupText= "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris id tempus nulla. Sed auctor neque ac purus convallis pretium. Sed id sem vehicula, mattis sem non, viverra est.";


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        Lamparina = GameObject.FindGameObjectWithTag("Lamparina");
        Lamparina.SetActive(false);
        camShaker = mainCamera.GetComponent<CameraShaker>();



    }


    public void Pickup()
    {
        switch (tipoObjetos)
        {
            case TipoObjetos.Lamparina:
                PickupLamparinaFunc();
                break;
            case TipoObjetos.Outro:
                break;
            default:
                break;
        }

        
        //TTRef.ShowToolTip(pickupText);
    }

    void PickupLamparinaFunc()
    {
        CercasInteiras.SetActive(false);
        CercasPartidas.SetActive(true);
        audioSource.Play();
        camShaker.ShakeCamera();
        Lamparina.SetActive(true);
        Destroy(gameObject);

    }
}
