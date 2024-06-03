using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float moveSpeed;
    [SerializeField]private Rigidbody2D rb2D;
    [SerializeField]private Gather gather;

    public float MoveSpeed
    {
        get { return moveSpeed; }
    }
    public Rigidbody2D Rb2D
    {
        get { return rb2D;}
        set { rb2D = value;}
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gather.Gathering();
        }    
    }
}
