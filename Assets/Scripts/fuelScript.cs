using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuelScript : MonoBehaviour
{
    [SerializeField] private LightScript luzRef;
    [SerializeField] private float fuelQuantity;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        luzRef.IncreaseFuel(fuelQuantity);
        Destroy(this.gameObject);

    }
}
