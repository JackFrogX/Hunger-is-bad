using UnityEngine;

public class Gather : MonoBehaviour
{
    [SerializeField]private Player player;
    [SerializeField]private float searchRange;
    [SerializeField]private float minDis;

    private ResourceNode closestResource;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, searchRange);
        Gizmos.DrawWireSphere(transform.position, minDis);
    }
    public void Gathering()
    {
        FindClosestInRange findClosestInRange = new FindClosestInRange();
        closestResource = findClosestInRange.Find(transform.position,searchRange);
        if ( closestResource != null)
        {
            MoveToPosition moveToPosition = new MoveToPosition(minDis,player.MoveSpeed);
            moveToPosition.Move(transform.position,closestResource.transform.position,player.GetRigidbody2D);
        }
        if (player.GetRigidbody2D != null)
        {
            Debug.Log("in gather have rigidbody -> "+ player.GetRigidbody2D);
        }
    }
}
