using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    [SerializeField] private Player player;
    private Vector2 moveDir;
    
    public void Movement()
    {
        moveDir = PlayerInput.Instance.MoveInputNormalized();
    }
    public void Execute()
    {
        player.Rb2D.velocity = moveDir * player.MoveSpeed * Time.deltaTime;
    }
}
