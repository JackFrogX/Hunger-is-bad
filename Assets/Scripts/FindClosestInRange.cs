using UnityEngine;

public class FindClosestInRange : MonoBehaviour
{
    // public ResourceNode Scan(ResourceNode nearest,Vector3 origin,float searchRange)
    // {
    //     Collider2D[] actionCollider = Physics2D.OverlapCircleAll(origin, searchRange);
    //     foreach (Collider2D collider2D in actionCollider)
    //     {
    //         if (collider2D.TryGetComponent<ResourceNode>(out ResourceNode resourceNode))
    //         {
    //             if (nearest == null)
    //             {
    //                 nearest = resourceNode;
    //             }
    //             else
    //             {
    //                 float nearestResource = VectorLib.DistantBetween2D((Vector2)nearest.transform.position, (Vector2)origin);
    //                 float compareResource = VectorLib.DistantBetween2D((Vector2)resourceNode.transform.position, (Vector2)origin);

    //                 if (nearestResource > compareResource)
    //                 {
    //                     nearest = resourceNode;
    //                 }
    //             }
    //         }
    //     }
    //     return nearest;
    // }
}
