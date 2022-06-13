using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PickupObject : MonoBehaviour
{
    [SerializeField] UnityEvent PickupLamparina;
    [SerializeField] ToolTipScript TTRef;
    [TextArea(0,8)]
    [SerializeField] string pickupText= "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris id tempus nulla. Sed auctor neque ac purus convallis pretium. Sed id sem vehicula, mattis sem non, viverra est.";

    
    public void Pickup()
    {
        
        if(PickupLamparina!=null) PickupLamparina.Invoke();
        TTRef.ShowToolTip(pickupText);
        Destroy(this.gameObject);
    }
}
