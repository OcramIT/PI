using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reach : MonoBehaviour
{
    #region Attributes

    [Header("ATTRIBUTES")]
    [SerializeField] private float MaxDistanceRay = 2.0f;
    [SerializeField] private float waitSecondsToClosePanel;

    [Header("KEYS")]
    [SerializeField] private KeyCode keyCodeInteraction = KeyCode.E;
    public bool hasKey1=false;
    public bool hasFalcao=false;
    public bool hasCruzVerm=false;
    public bool hasCullen=false;


    [Header("Imagens")]

    [SerializeField] private GameObject mCloseDoor;
    [SerializeField] private GameObject mOpenDoor;
    [SerializeField] private GameObject mDoorLocked;
    [SerializeField] private GameObject mPickup;

    public static Reach instance { get; private set; }

    #endregion

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyUp(keyCodeInteraction))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(ray, out RaycastHit hit, MaxDistanceRay))
                CheckHitPoint(hit);
        }

        UpdateIcon();
    }

    #region PUBLIC



    
    #endregion

    #region PRIVATE

    private void CheckHitPoint(RaycastHit hit)
    {
        if (hit.transform == null)
            return;

        if (hit.transform.CompareTag("Door"))
        {
            if (hit.transform.GetComponent<Door>().isUnlocked)
            {
                if (!hit.transform.GetComponent<Door>().Opened)
                    hit.transform.GetComponent<Door>().opening = true;
                else if (!hit.transform.GetComponent<Door>().Closed)
                    hit.transform.GetComponent<Door>().closing = true;
            }
            else hit.transform.GetComponent<Door>().TryUnlockDoor(this);


        }

        if (hit.transform.CompareTag("Key"))
        {
            keyScript keyRef= hit.transform.GetComponent<keyScript>();
            if (!keyRef) return;

            switch (keyRef.id)
            {
                case "key1":
                    hasKey1 = true;
                    break;
                case "falcao":
                    hasFalcao = true;
                    break;
                case "cruzVerm":
                    hasCruzVerm = true;
                    break;
                case "cullen":
                    hasCullen = true;
                    break;
                default:
                    break;
            }

            Destroy(keyRef.gameObject);
        }

        if (hit.transform.CompareTag("LamparinaPickup"))
        {
            var pickupLamparinaRef = hit.transform.GetComponent<PickupObject>();
            if (pickupLamparinaRef) pickupLamparinaRef.Pickup();
        }
    }



    private void UpdateIcon()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, MaxDistanceRay))
        {

            if (hit.transform.CompareTag("Door"))
            {
                if (hit.transform.GetComponent<Door>().isUnlocked)
                {
                    if (hit.transform.GetComponent<Door>().Closed)
                    {
                        mCloseDoor.SetActive(false);
                        mOpenDoor.SetActive(true);
                    }
                    else if (hit.transform.GetComponent<Door>().Opened)
                    {
                        mCloseDoor.SetActive(true);
                        mOpenDoor.SetActive(false);
                    }
                    mDoorLocked.SetActive(false);
                }
                else
                {

                    mDoorLocked.SetActive(true);
                    mCloseDoor.SetActive(false);
                    mOpenDoor.SetActive(false);
                }
            }
            else if ((hit.transform.CompareTag("Key"))||(hit.transform.CompareTag("LamparinaPickup")))
            {
                mPickup.SetActive(true);
            }
            else
            {
                mDoorLocked.SetActive(false);
                mCloseDoor.SetActive(false);
                mOpenDoor.SetActive(false);
                mPickup.SetActive(false);
            }
        }
        else
        {
            mDoorLocked.SetActive(false);
            mCloseDoor.SetActive(false);
            mOpenDoor.SetActive(false);
            mPickup.SetActive(false);
        }
    }

    #endregion
}
