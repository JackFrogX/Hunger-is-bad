using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float moveSpeed;
    [SerializeField]private new Rigidbody2D rigidbody2D;
    [SerializeField]private Gather gather;

    public float MoveSpeed
    {
        get { return moveSpeed; }
    }
    public Rigidbody2D GetRigidbody2D
    {
        get { return rigidbody2D;}
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gather.Gathering();
        }    
    }
}
