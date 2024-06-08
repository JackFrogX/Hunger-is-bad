using UnityEngine;

public class Gather : MonoBehaviour
{
    [SerializeField]private Player player;
    [SerializeField]private float searchRange;
    [SerializeField]private float minDis;
    // [SerializeField]private Rigidbody2D rb2D;


    private ResourceNode closestResource;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, searchRange);
        Gizmos.DrawWireSphere(transform.position, minDis);
    }
    public void Gathering()
    {
        if ( closestResource != null)
        {
            MoveToPosition moveToPosition = new MoveToPosition(minDis,player.MoveSpeed);
            moveToPosition.Move(transform.position,closestResource.transform.position,player.Rb2D);
        }
    }
    public void CloseResourceFinder()
    {
        FindClosestInRange findClosestInRange = new FindClosestInRange();
        closestResource = findClosestInRange.Find(transform.position,searchRange);
    }
}
