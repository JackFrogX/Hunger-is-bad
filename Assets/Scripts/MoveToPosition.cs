using UnityEngine;

public class MoveToPosition
{
    private Rigidbody2D rigidbody2D;
    private float minDis;
    private float moveSpeed;
    
    public MoveToPosition(Rigidbody2D rigidbody2DMeter,float minDisMeter, float moveSpeedMeter)
    {
        rigidbody2D = rigidbody2DMeter;
        minDis = minDisMeter;
        moveSpeed = moveSpeedMeter;
    } 
    public void Move(Vector2 origin, Vector2 destination)
    {
        Vector2 posDirection = VectorLib.VectorToDestination(origin, destination, minDis);
        rigidbody2D.velocity = posDirection.normalized * moveSpeed * Time.deltaTime;
    }
}