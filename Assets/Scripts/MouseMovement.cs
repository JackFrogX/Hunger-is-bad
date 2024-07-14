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

    private ResourceNode mouseNode;
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(mousePosition2D.MousePosition(), clickRange);
    }
    #endif
    public void SetDestination()
    {
        FindClosestInRange findClosestInRange = new FindClosestInRange();
        mouseNode = findClosestInRange.Find(destination,clickRange);
        destination = mousePosition2D.MousePosition();
    }   
    public void Movement()
    {  
        mouseDirection = VectorLib.VectorToDestination(destination,transform.position,player.MinDis);
    }
    public void Excute()
    {
        player.Rb2D.velocity = player.MoveSpeed * Time.deltaTime * mouseDirection.normalized;
    }


}