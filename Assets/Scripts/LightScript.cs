using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{

    [SerializeField] private float lightIntensity;
    [SerializeField] private float startLightIntensity;

    [SerializeField] private Light luz;


    private void Awake()
    {
        luz = GetComponent<Light>();
        lightIntensity=startLightIntensity=luz.intensity;
    }
    void Start()
    {
        StartCoroutine(DecreaseIntensity());
    }

    IEnumerator DecreaseIntensity()
    {
        while (true)
        {
            if (lightIntensity > 0f)
            {
                luz.intensity=lightIntensity -= 0.2f;
                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return null;
            }
        }
    }

    public void IncreaseFuel( float quantity)
    {

        if (lightIntensity < startLightIntensity)
        {
            if (lightIntensity + quantity > startLightIntensity)
            {
                luz.intensity = lightIntensity = startLightIntensity;
            }
            else luz.intensity = lightIntensity += quantity;
        }
        
    }
}
