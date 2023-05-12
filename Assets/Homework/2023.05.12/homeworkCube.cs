using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class homeworkCube : MonoBehaviour
{
    [SerializeField]
    private float WalkSpeed;
    [SerializeField]
    private float JumpSpeed;

    private float applySpeed;

    private Vector3 moveDir;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        applySpeed = WalkSpeed;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        applySpeed = WalkSpeed;
        rb.AddForce(moveDir.normalized * applySpeed * 3f * Time.deltaTime, ForceMode.Force);
    }

    public void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }

    public void Jump(InputValue value)
    {
        applySpeed = JumpSpeed;
        rb.AddForce(Vector3.up * applySpeed, ForceMode.Impulse);
    }
}
