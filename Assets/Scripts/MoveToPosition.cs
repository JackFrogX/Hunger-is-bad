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
    public void Move(Vector2 origin, Vector2 destination,Rigidbody2D rb2D)
    {
        Vector2 posDirection = VectorLib.VectorToDestination(destination,origin, minDis);
        rb2D.velocity = posDirection.normalized * moveSpeed * Time.deltaTime;
        if (rb2D != null)
        {
            Debug.Log("in moveToPosition there are rigidbody ->" + rb2D);
        }
    }
}