using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody2D;
    [SerializeField] Player player;
    private Vector2 moveDir;
    private void Update()
    {
        moveDir = PlayerInput.Instance.MoveInputNormalized();
    }
    private void FixedUpdate()
    {
        rigidbody2D.velocity = moveDir * player.MoveSpeed * Time.deltaTime;
    }
}
