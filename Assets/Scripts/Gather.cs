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
        if (closestResource != null)
        {
            MoveToPosition moveToPosition = new MoveToPosition(minDis,player.MoveSpeed);
            moveToPosition.Move(transform.position,closestResource.transform.position,player.Rb2D);
            if (VectorLib.VectorToDestination(closestResource.transform.position,transform.position,minDis) == Vector2.zero)
            {
                closestResource.GetDamage();
                closestResource = null;
            }
        }
    }
    public void CloseResourceFinder()
    {
        FindClosestInRange findClosestInRange = new FindClosestInRange();
        closestResource = findClosestInRange.Find(transform.position,searchRange);
    }
}
