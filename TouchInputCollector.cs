using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputCollector : MonoBehaviour {
    public GameObject cube;
    GameObject[] cubes = new GameObject[32];

    void touchBegin(Touch fingerID, float x, float y)
    {
        cubes[fingerID.fingerId] = Instantiate(cube);
        cubes[fingerID.fingerId].GetComponent<TouchMarker>().OnCreated(x,y,fingerID);
    }
    void touchMove(Touch fingerID, float x, float y)
    {
        
        cubes[fingerID.fingerId].GetComponent<TouchMarker>().OnMoved(x, y);
    }
    void touchEnd(Touch fingerID, float x, float y)
    {
        Destroy(cubes[fingerID.fingerId]);
        cubes[fingerID.fingerId] = null;

    }
    void Update () {
		for(int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);
            fingerPhase(t);
        }
	}

    void fingerPhase(Touch finger)
    {
        float x = finger.position.x;
        float y = finger.position.y;
        switch (finger.phase)
        {
            case TouchPhase.Began:
                touchBegin(finger,x,y);
                break;

            case TouchPhase.Moved:
                touchMove(finger, x, y);
                break;

            case TouchPhase.Ended:
                touchEnd(finger, x, y);
                break;
            case TouchPhase.Canceled:
                touchEnd(finger, x, y);
                break;
        }
    }
    public GameObject[] getTouches()
    {
        return cubes;
    }
}
