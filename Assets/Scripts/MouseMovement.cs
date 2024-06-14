using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private MousePosition2D mousePosition2D;
    [SerializeField] private Player player;

    [SerializeField] private float clickRange;
    private Vector2 destination;
    
    enum DestinationState
    {
        Ground,
        Node
    }

    private DestinationState destinationState;
    private ResourceNode mouseNode;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(mousePosition2D.MousePosition(), clickRange);
    }
    public void SetDestination()
    {
        FindClosestInRange findClosestInRange = new FindClosestInRange();
        mouseNode = findClosestInRange.Find(destination,clickRange);
        if (mouseNode ==null)
        {
            destination = mousePosition2D.MousePosition();
            destinationState = DestinationState.Ground;
            Debug.Log(destinationState);
        }
        else
        {
            destinationState = DestinationState.Node;
            Debug.Log(destinationState);

        }
    }
    public void Movement()
    {  
        if (destinationState == DestinationState.Ground)
        {
            MoveToPosition moveToPosition = new MoveToPosition(player.MinDis,player.MoveSpeed);
            moveToPosition.Move(transform.position,destination,player.Rb2D);
        }
        if (destinationState == DestinationState.Node)
        {
            if (mouseNode != null)
            {
                MoveToPosition moveToPosition = new MoveToPosition(player.MinDis,player.MoveSpeed);
                moveToPosition.Move(transform.position,mouseNode.transform.position,player.Rb2D);
                if (VectorLib.VectorToDestination(mouseNode.transform.position,transform.position,player.MinDis) == Vector2.zero)
                {
                    mouseNode.GetDamage();
                    mouseNode = null;
                }
            }
        }
    }
}
