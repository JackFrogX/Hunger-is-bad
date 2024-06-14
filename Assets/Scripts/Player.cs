using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float moveSpeed;
    [SerializeField]private Rigidbody2D rb2D;
    [SerializeField]private float minDis;
    [SerializeField]private Gather gather;
    [SerializeField]private KeyboardMovement keyboardMovement;
    [SerializeField]private MouseMovement mouseMovement;

    public float MoveSpeed
    {
        get { return moveSpeed; }
    }
    public Rigidbody2D Rb2D
    {
        get { return rb2D;}
        set { rb2D = value;}
    }

    public float MinDis
    {
        get { return minDis; }
        set { minDis = value; }
    }
    
    enum PlayerState
    {
        Moving,
        Gathering,
        MouseMovement
    }

    private PlayerState state;

    private void Update() 
    {
        if (PlayerInput.Instance.MoveInputNormalized() != Vector2.zero)
        {
            state = PlayerState.Moving;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            state = PlayerState.Gathering;
            gather.CloseResourceFinder();
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            state = PlayerState.MouseMovement;
            mouseMovement.SetDestination();        
        }

    }
    private void FixedUpdate()
    {
        switch (state)
        {
            case PlayerState.Moving: keyboardMovement.Execute(); break;
            case PlayerState.Gathering: gather.Gathering(); break;  
            case PlayerState.MouseMovement: mouseMovement.Movement(); break;
        }
    }
}
