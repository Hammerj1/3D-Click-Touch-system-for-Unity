using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseToTouch : MonoBehaviour {
    public GameObject touchMarkerPrefab;
    GameObject touchMarker;
    GameObject touchMarker2;
	void Update () {
        
        if (Input.GetMouseButtonDown(0))
        {
            touchMarker = Instantiate(touchMarkerPrefab);
            touchMarker.GetComponent<TouchMarker>().OnCreated(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButton(0))
        {
            touchMarker.GetComponent<TouchMarker>().OnMoved(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(touchMarker);
            touchMarker = null;
        }

	}
}
