using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private MousePosition2D mousePosition2D;
    [SerializeField] private Player player;

    [SerializeField] private float clickRange;
    private Vector2 destination;
    
    private Vector2 mouseDirection;
    enum DestinationState
    {
        Ground,
        Node
    }

    private DestinationState destinationState;
    private ResourceNode mouseNode;
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(mousePosition2D.MousePosition(), clickRange);
    }
    #endif
    public void SetDestination()
    {
        Vector2 destinationCheck = mousePosition2D.MousePosition();
        FindClosestInRange checkClosestInRange = new FindClosestInRange();
        if ( checkClosestInRange.Find(destinationCheck,clickRange) ==null)
        {
            destinationState = DestinationState.Ground;
        }
        else
        {
            destinationState = DestinationState.Node;
        }
        Debug.Log(checkClosestInRange.Find(destinationCheck,clickRange));
    }

    // public void Deselect()
    // {
    //     mouseDirection = Vector2.zero;
    // }

    
    public void Movement()
    {  
        FindClosestInRange findClosestInRange = new FindClosestInRange();
        mouseNode = findClosestInRange.Find(destination,clickRange);
        switch (destinationState)
        {
            case DestinationState.Ground:
                destination = mousePosition2D.MousePosition();
                mouseDirection = VectorLib.VectorToDestination(destination,transform.position,player.MinDis);
                break;
            case DestinationState.Node:
                if (mouseNode != null)
                {
                    mouseDirection = VectorLib.VectorToDestination(mouseNode.transform.position,transform.position,player.MinDis);
                    if (VectorLib.VectorToDestination(mouseNode.transform.position,transform.position,player.MinDis) == Vector2.zero)
                    {
                        mouseNode.GetDamage();
                        mouseNode = null;
                    }
                }
                break;
        }
    }
    public void Excute()
    {
        player.Rb2D.velocity = player.MoveSpeed * Time.deltaTime * mouseDirection.normalized;
    }

}
