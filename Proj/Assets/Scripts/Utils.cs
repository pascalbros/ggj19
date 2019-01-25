using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static Vector2 pointOnCircle(Vector2 center, float radius, float angle)
    {
        float x = center.x + radius * Mathf.Cos(angle*Mathf.Deg2Rad);
        float y = center.y + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        return new Vector2(x, y);
    }

}
