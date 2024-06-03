using UnityEngine;

public class MoveToPosition
{
    private float minDis;
    private float moveSpeed;
    
    public MoveToPosition(float minDisMeter, float moveSpeedMeter)
    {
        // rigidbody2D = rigidbody2DMeter;
        minDis = minDisMeter;
        moveSpeed = moveSpeedMeter;
    } 
    public void Move(Vector2 origin, Vector2 destination,Rigidbody2D rigidbody2DMeter)
    {
        Vector2 posDirection = VectorLib.VectorToDestination(origin, destination, minDis);
        rigidbody2DMeter.velocity = posDirection.normalized * moveSpeed * Time.deltaTime;
        if (rigidbody2DMeter != null)
        {
            Debug.Log("in moveToPosition there are rigidbody ->" + rigidbody2DMeter);
        }
    }
}