using UnityEngine;

public class Gather : MonoBehaviour
{
    [SerializeField]private Player player;
    [SerializeField]private float searchRange;

    private ResourceNode closestResource;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, searchRange);
        Gizmos.DrawWireSphere(transform.position, player.MinDis);
    }
    public void Gathering()
    {
        if (closestResource != null)
        {
            MoveToPosition moveToPosition = new MoveToPosition(player.MinDis,player.MoveSpeed);
            moveToPosition.Move(transform.position,closestResource.transform.position,player.Rb2D);
            if (VectorLib.VectorToDestination(closestResource.transform.position,transform.position,player.MinDis) == Vector2.zero)
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
