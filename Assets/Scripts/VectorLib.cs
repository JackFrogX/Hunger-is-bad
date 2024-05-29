using UnityEngine;
public static class VectorLib
{
    public static Vector2 VectorToDestination(Vector2 destination, Vector3 startPos, float minDis)
    {
        if (Vector2.SqrMagnitude(destination - (Vector2)startPos) >= minDis)
        {
            return destination - (Vector2)startPos;
        }
        else
        {
            return Vector2.zero;
        }
    }
    public static float DistantBetween2D(Vector2 pointA, Vector2 pointB)
    {
        return Vector2.SqrMagnitude(pointA - pointB);

    }
}
