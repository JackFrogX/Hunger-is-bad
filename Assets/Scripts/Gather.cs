using UnityEngine;

public class Gather : MonoBehaviour
{
    [SerializeField]private Player player;
    [SerializeField]private float searchRange;

    private ResourceNode closestResource;
    private Vector2 nodeDirection;
    
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, searchRange);
        Gizmos.DrawWireSphere(transform.position, player.MinDis);
    }
#endif
    public void CloseResourceFinder()
    {
        FindClosestInRange findClosestInRange = new FindClosestInRange();
        closestResource = findClosestInRange.Find(transform.position,searchRange);
    }
    public void Gathering()
    {
        if (closestResource != null)
        {
            nodeDirection = VectorLib.VectorToDestination(closestResource.transform.position,transform.position,player.MinDis);
            if (VectorLib.VectorToDestination(closestResource.transform.position,transform.position,player.MinDis) == Vector2.zero)
            {
                closestResource.GetDamage();
                closestResource = null;
            }
        }
    }
    public void Excute()
    {
        player.Rb2D.velocity = nodeDirection.normalized * player.MoveSpeed * Time.deltaTime;
    }
}
