using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private static PlayerInput instance;
    public static PlayerInput Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (PlayerInput.instance != null)
        {
            Debug.LogError("Only 1 PlayerInput allow to exist");
        }
        PlayerInput.instance = this;
    }
    public Vector2 MoveInputNormalized()
    {
        Vector2 moveDir = new Vector2();
        if (Input.GetKey(KeyCode.W))
        {
            moveDir.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDir.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir.x = +1;
        }
        if (!Input.GetKey(KeyCode.W) && 
            !Input.GetKey(KeyCode.S) && 
            !Input.GetKey(KeyCode.A) && 
            !Input.GetKey(KeyCode.D)){
            moveDir = Vector2.zero;
        }
        moveDir = moveDir.normalized;
        return moveDir;
    }
    
    // public bool GatherClosestInput()
    // {
    //     return Input.GetKey(KeyCode.Space);
    // }

    public bool MoveToInput()
    {
        return Input.GetKey(KeyCode.Mouse0);
    }
}