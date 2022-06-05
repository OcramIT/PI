using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamparinaPickup : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject lamparinaRef;

    public void Pickup()
    {
        lamparinaRef.SetActive(true);
        Destroy(this.gameObject);
    }
}
