using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static Vector2 pointOnCircle(Vector2 center, float radius, float angle)
    {
        float x = center.x + radius * Mathf.Cos(angle);
        float y = center.y + radius * Mathf.Cos(angle);
        return new Vector2(x, y);
    }

}
