using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    [SerializeField] private Player player;
    private Vector2 moveDir;
    private void Update()
    {
        moveDir = PlayerInput.Instance.MoveInputNormalized();
    }
    private void FixedUpdate()
    {
        player.Rb2D.velocity = moveDir * player.MoveSpeed * Time.deltaTime;
    }
}
