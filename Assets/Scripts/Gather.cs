using UnityEngine;

public class Gather : MonoBehaviour
{
    [SerializeField]private Player player;
    [SerializeField]private float searchRange;
    [SerializeField]private float minDis;
    private FindClosestInRange findClosestInRange;
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
            MoveToPosition moveToPosition = new MoveToPosition(player.GetRigidbody2D,minDis,player.MoveSpeed);
            moveToPosition.Move(transform.position,closestResource.transform.position);
        }
    }
}
