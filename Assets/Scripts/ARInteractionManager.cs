using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARInteractionManager : MonoBehaviour
{
    [SerializeField] private Camera arCamera;
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private bool isInitialPosition;

    [SerializeField] private GameObject aRPointer;
    private GameObject itemModel;

    public GameObject ItemModel { set { 
            itemModel = value;
            itemModel.transform.position = aRPointer.transform.position; 
            itemModel.transform.parent = aRPointer.transform;
            isInitialPosition = true;
    } }
    void Start()
    {
        aRPointer = transform.GetChild(0).gameObject;
        arRaycastManager=FindAnyObjectByType<ARRaycastManager>();
        GameManager.instance.OnMainMenu += SetItemPosition;
    }

    private void SetItemPosition()
    {
        if(itemModel != null)
        {
            itemModel.transform.parent = null;
            aRPointer.SetActive(false);
            itemModel = null;
        }
    }
    public void OnDestroy()
    {
        Destroy(itemModel);
        aRPointer?.SetActive(false);
        GameManager.instance.MainMenu();
    }
    // Update is called once per frame
    void Update()
    {
        if (isInitialPosition)
        {
            Vector2 middlePointScreen=new Vector2 (Screen.width/2, Screen.height/2);
            arRaycastManager.Raycast(middlePointScreen, hits, TrackableType.Planes);
            if(hits.Count > 0) {
                transform.position = hits[0].pose.position;
                transform.rotation = hits[0].pose.rotation;
                aRPointer.SetActive (true);
                isInitialPosition=false;
            }
        }
    }
}
