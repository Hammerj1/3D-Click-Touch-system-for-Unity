using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools{

	public static float Distance(float x1, float x2, float y1, float y2)
    {
        return Mathf.Sqrt(((x2 - x1)* (x2 - x1)) + ((y2 - y1)* (y2 - y1)));
    }
}
