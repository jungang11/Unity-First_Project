using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class homeworkTank : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private float rotateSpeed;

    private float applySpeed;
    
    private Rigidbody rb;
    private Vector3 moveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        applySpeed = walkSpeed;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    public void Move()
    {
        applySpeed = walkSpeed;
        transform.Translate(Vector3.forward * moveDir.z * applySpeed * Time.deltaTime, Space.Self);
    }

    public void Rotate()
    {
        applySpeed = rotateSpeed;
        transform.Rotate(Vector3.up, moveDir.x * applySpeed * Time.deltaTime * 5f, Space.Self);
    }

    public void OnJump(InputValue value)
    {
        applySpeed = jumpSpeed;
        rb.velocity = transform.up * applySpeed;
    }

    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }
}
