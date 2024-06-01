using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float searchRange;
    [SerializeField] private float interactRange;
    private float minDis = 0.01f;
    [SerializeField] private MousePosition2D mousePos;
    [SerializeField] private FindClosestInRange findClosestInRange;
    private new Rigidbody2D rigidbody2D;
    private Vector2 moveDir;
    private Vector2 mouseDir;
    private Vector2 nearestDir;
    private Vector2 destination;
    private ResourceNode nearest;
    private MoveType moveType;
    enum MoveType { Mouse, KeyBoard, SpaceToResource }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, searchRange);
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
    private void Awake()
    {
        destination = (Vector2)transform.position;
        rigidbody2D = GetComponent<Rigidbody2D>();
        nearest = null;
    }
    private void Update()
    {
        moveDir = PlayerInput.Instance.MoveInputNormalized();
        //change move type if using wasd
        if (moveDir != Vector2.zero)
        {
            moveType = MoveType.KeyBoard;
        }

        //move to mouse position
        if (PlayerInput.Instance.MoveToInput())
        {
            moveType = MoveType.Mouse;
            destination = mousePos.MousePosition();
        }
        mouseDir = VectorLib.VectorToDestination(destination, transform.position, minDis);
        
        //reset nearest target here
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nearest = null;
        }
        if (PlayerInput.Instance.GatherClosestInput())
        {
                
            nearest = findClosestInRange.Scan(nearest, transform.position, searchRange);
            moveType = MoveType.SpaceToResource;
        }

        //set direction to neareast resource if there is one
        if (nearest != null)
        {
            nearestDir = VectorLib.VectorToDestination(nearest.transform.position, transform.position, interactRange);
        }
    }
    
    private void FixedUpdate()
    {
        switch (moveType)
        {
            case MoveType.KeyBoard:
                rigidbody2D.velocity = moveDir * moveSpeed * Time.deltaTime;
                break;
            case MoveType.Mouse:
                rigidbody2D.velocity = mouseDir.normalized * moveSpeed * Time.deltaTime;
                break;
            case MoveType.SpaceToResource:
                rigidbody2D.velocity = nearestDir.normalized * moveSpeed * Time.deltaTime;
                break;
        }
    }
}