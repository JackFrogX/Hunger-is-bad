using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    [SerializeField] private Player player;
    private Vector2 moveDir;
    public void Execute()
    {
        moveDir = PlayerInput.Instance.MoveInputNormalized();
        player.Rb2D.velocity = moveDir * player.MoveSpeed * Time.deltaTime;
    }
}
