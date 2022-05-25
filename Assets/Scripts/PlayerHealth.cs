using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health =50;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(addHealth());
    }

    IEnumerator addHealth()
    {
        while (true)
        {
            if (health < 100)
            { 
                health += 1;
                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return null;
            }
        }
    }
}
