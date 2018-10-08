using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestures : MonoBehaviour {
    GameObject[] touchObjects = new GameObject[32];

	void Update () {
        if(GameObject.Find("Touch Marker #1"))
        {
            Zoom();
        }
    }
    /// <summary>
    /// Returns the expansion scale of the frist two touches on screen
    /// </summary>
    /// <returns></returns>
    public static float Zoom()
    {
        TouchMarker touchOne = GameObject.Find("Touch Marker #0").GetComponent<TouchMarker>();
        TouchMarker touchTwo = GameObject.Find("Touch Marker #1").GetComponent<TouchMarker>();
        float distance1 = Tools.Distance(touchOne.CreatedPosition().x, touchTwo.CreatedPosition().x, touchOne.CreatedPosition().y, touchTwo.CreatedPosition().y);
        float distance2 = Tools.Distance(touchOne.GetPosition().x, touchTwo.GetPosition().x, touchOne.GetPosition().y, touchTwo.GetPosition().y);
        float scale = distance2 / distance1;
        return scale;
    }

}
