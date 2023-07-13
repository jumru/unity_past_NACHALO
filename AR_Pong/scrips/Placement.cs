using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Placement : MonoBehaviour
{
    [Header("It Marker")]
    [SerializeField]private GameObject PlaneMarkerPrefab;
    

    [SerializeField]private ARRaycastManager ARRaycastManagerScrips;
    private Vector2 CameraCenter;
    private Vector2 TouchPosition;


    public GameObject SpawingOBJ;
    
    public bool _ChooseObject = false;
    [SerializeField] private bool _haveGame = false;
    [SerializeField] private ARPointCloudManager _ARPointCloudManager;
  

    void Start()
    {
        _haveGame = false;
        if (ARRaycastManagerScrips == null)
        ARRaycastManagerScrips = FindObjectOfType<ARRaycastManager>();
        if (_ARPointCloudManager == null)
        {
            _ARPointCloudManager = FindObjectOfType<ARPointCloudManager>();
        }
        CameraCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        PlaneMarkerPrefab.SetActive(false);
      
    }

    
    void Update()
    {
        if (_haveGame == false)
        {
            ShowMarkerAndSetOBJ();
        }
    }

    private void ShowMarkerAndSetOBJ()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        ARRaycastManagerScrips.Raycast(CameraCenter, hits, TrackableType.Planes);

        // покажем
        if (hits.Count > 0)
        {
            PlaneMarkerPrefab.SetActive(true);
            PlaneMarkerPrefab.transform.position = hits[0].pose.position;
            _ChooseObject = true;
        }
        else
        {
            PlaneMarkerPrefab.SetActive(false);
            _ChooseObject = false;
        }

        //ставим
        if (_ChooseObject == true)
        {
            if (hits.Count > 0 && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
            {


                //Touch touch = Input.GetTouch(0);
                //TouchPosition = touch.position;
                //ARRaycastManagerScrips.Raycast(TouchPosition, hits, TrackableType.Planes);


                Instantiate(SpawingOBJ, hits[0].pose.position, SpawingOBJ.transform.rotation);
                _ChooseObject = false;
                OffAllAR();

            }
        }
    }

    public void OffAllAR()
    {
        _ARPointCloudManager.enabled = false;
        ARRaycastManagerScrips.enabled = false;
        PlaneMarkerPrefab.SetActive(false);
        _haveGame = true;
    }
}
