using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMarker : MonoBehaviour {
    float lastX, lastY;
    float deltaX, deltaY;
    float firstX, firstY;
    Vector2 position;
    int identity;
    Touch touch;

    /// <summary>
    /// Called when a new input touches the screen
    /// </summary>
    public void OnCreated(float x, float y, Touch t = new Touch())
    {
        firstX = x;
        firstY = y;
        gameObject.name = "Touch Marker #" + t.fingerId;
        identity = t.fingerId;
        transform.position = TouchWorldPoint(x, y);
        touch = t;
    }
    /// <summary>
    /// Called every time an input changes positions
    /// </summary>
    public void OnMoved(float x, float y)
    {
        GetDelta(x, y);
        transform.position = TouchWorldPoint(x, y);
        lastX = x;
        lastY = y;
        position = new Vector2(x, y);
    }
    /// <summary>
    /// Changes screen coordinates into world coordinates
    /// </summary>
    Vector3 TouchWorldPoint(float x, float y)
    {
        Camera c = Camera.main;
        Ray ray = c.ScreenPointToRay(new Vector3(x, y, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, 512))
        {
            return hit.point;
        }
        else
        {
            return new Vector3(lastX,lastY,0);
        }
    }
    void GetDelta(float x, float y)
    {
        deltaX = lastX - x;
        deltaY = lastY - y;
    }
    /// <summary>
    /// The change from the position in the last frame
    /// </summary>
    public Vector2 Delta()
    {
        return new Vector2(deltaX,deltaY);
    }
    
    public Touch TouchIdentity()
    {
        return touch;
    }
    /// <summary>
    /// The position when this touch was created
    /// </summary>
    public Vector2 CreatedPosition()
    {
        return new Vector2(firstX, firstY);
    }
    /// <summary>
    /// The current position of this touch
    /// </summary>
    public Vector2 GetPosition()
    {
        return position;
    }
}
