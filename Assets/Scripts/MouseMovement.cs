using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private MousePosition2D mousePosition2D;
    [SerializeField] private Player player;

    [SerializeField] private float clickRange;
    private Vector2 destination;
    
    private Vector2 mouseDirection;

    private ResourceNode mouseNode;

    enum MouseMoveState 
    {
        Idle,
        Normal,
        Gathering
    }

    private MouseMoveState mouseMoveState = MouseMoveState.Idle;

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(mousePosition2D.MousePosition(), clickRange);
    }
    #endif  


    public void SetDestination()
    {
        FindClosestInRange findClosestInRange = new FindClosestInRange();
        destination = mousePosition2D.MousePosition();
        if (findClosestInRange.Find(destination,clickRange) != null)
        {
            mouseNode = findClosestInRange.Find(destination,clickRange);
            mouseMoveState = MouseMoveState.Gathering;

        }
        else
        {
            mouseMoveState = MouseMoveState.Normal;
        }
    }

    public void Movement()
    {
        switch (mouseMoveState)
        {
            case MouseMoveState.Idle:break;
            case MouseMoveState.Normal:
                NormalMovement();
                break;
            case MouseMoveState.Gathering:
                GatherMovement();
                break;
        }
    }
    
    public void NormalMovement()
    {  
        mouseDirection = VectorLib.VectorToDestination(destination,transform.position,player.MinDis);
    }
    public void GatherMovement()
    {
        if (mouseNode != null)
        {
            mouseDirection = VectorLib.VectorToDestination(mouseNode.transform.position,transform.position,player.MinDis);
            if (VectorLib.VectorToDestination(mouseNode.transform.position,transform.position,player.MinDis) == Vector2.zero)
            {
                mouseNode.GetDamage();
                mouseNode = null;
            }
        }
    }
    
    public void Excute()
    {
        player.Rb2D.velocity = player.MoveSpeed * Time.deltaTime * mouseDirection.normalized;
    }


}