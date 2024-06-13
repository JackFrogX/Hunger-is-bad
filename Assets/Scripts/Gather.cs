using UnityEngine;

public class Gather : MonoBehaviour
{
    [SerializeField]private Player player;
    [SerializeField]private float searchRange;
    [SerializeField]private float minDis;

    enum GatherState
    {
        MoveTo,
        NodeGathering,
        Finish
    }

    private GatherState gatherState;
    private ResourceNode closestResource;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, searchRange);
        Gizmos.DrawWireSphere(transform.position, minDis);
    }
    public void Gathering()
    {
        switch (gatherState)
        {
            case GatherState.MoveTo:
                if ( closestResource != null)
                {
                    MoveToPosition moveToPosition = new MoveToPosition(minDis,player.MoveSpeed);
                    moveToPosition.Move(transform.position,closestResource.transform.position,player.Rb2D);
                    if (VectorLib.VectorToDestination(closestResource.transform.position,transform.position,minDis) == Vector2.zero)
                    {
                        gatherState = GatherState.NodeGathering;
                    }
                }
                break;
            case GatherState.NodeGathering:
                if (closestResource != null)
                {
                    closestResource.GetDamage();
                }
                else
                {
                    gatherState = GatherState.Finish;
                }
                
                break;
            case GatherState.Finish:
                break;
        }
    }
    public void CloseResourceFinder()
    {
        FindClosestInRange findClosestInRange = new FindClosestInRange();
        closestResource = findClosestInRange.Find(transform.position,searchRange);
        gatherState = GatherState.MoveTo;
    }
}
