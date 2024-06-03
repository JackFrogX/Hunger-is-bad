using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float moveSpeed;
    [SerializeField]private Rigidbody2D rigidbody2D;
    [SerializeField]private Gather gather;

    public float MoveSpeed
    {
        get { return moveSpeed; }
    }
    public Rigidbody2D GetRigidbody2D
    {
        get { return rigidbody2D;}
        set { rigidbody2D = value;}
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gather.Gathering();
        }    
    }
}
