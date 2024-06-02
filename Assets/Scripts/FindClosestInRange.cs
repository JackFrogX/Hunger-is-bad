using UnityEngine;

public class FindClosestInRange
{
    public ResourceNode Find(Vector3 origin, float searchRange)
    {
        Debug.Log("find closest run");
        bool firstNode = true;
        ResourceNode nearest = null;
        Collider2D[] findCollider = Physics2D.OverlapCircleAll(origin, searchRange);
        foreach (Collider2D collider2D in findCollider)
        {
            if (collider2D.TryGetComponent<ResourceNode>(out ResourceNode resourceNode))
            {
                if (firstNode == true)
                {
                    nearest = resourceNode;
                    firstNode = false;
                }
                else
                {
                    float nearestResource = VectorLib.DistantBetween2D((Vector2)nearest.transform.position, (Vector2)origin);
                    float compareResource = VectorLib.DistantBetween2D((Vector2)resourceNode.transform.position, (Vector2)origin);

                    if (nearestResource > compareResource)
                    {
                        nearest = resourceNode;
                    }
                }
            }
        }
        if (nearest == null)
        {
            Debug.Log("cant found nearest");
        }
        return nearest;
    }
}
