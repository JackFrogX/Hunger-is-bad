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
    // public void SetDestination()
    // {
    //     FindClosestInRange findClosestInRange = new FindClosestInRange();
    //     destination = mousePosition2D.MousePosition();
    // }
    // public void Movement()
    // {  
    //     mouseDirection = VectorLib.VectorToDestination(destination,transform.position,player.MinDis);
    // }

    public void SetGatheNode()
    {
        FindClosestInRange findClosestInRange = new FindClosestInRange();
        destination = mousePosition2D.MousePosition();
        mouseNode = findClosestInRange.Find(destination,clickRange);
    }
    public void Movement()
    {
        if (mouseNode != null)
        {
            mouseDirection = VectorLib.VectorToDestination(mouseNode.transform.position,transform.position,player.MinDis);
        }
        if (mouseNode != null && VectorLib.VectorToDestination(mouseNode.transform.position,transform.position,player.MinDis) == Vector2.zero)
        {
            mouseNode.GetDamage();
            mouseNode = null;
        }
    }
    

    public void Excute()
    {
        player.Rb2D.velocity = player.MoveSpeed * Time.deltaTime * mouseDirection.normalized;
    }


}