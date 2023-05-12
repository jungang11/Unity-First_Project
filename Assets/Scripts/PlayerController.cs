using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float rotateSpeed;

    private float applySpeed;

    [SerializeField]
    private float jumpForce;

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

    // �����¿� �̵�
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

    public void Rotation()
    {
        // Ʈ�������� ȸ������ Euler���� ǥ���� �ƴ� Quaternion�� �����
        transform.rotation = Quaternion.identity;

        // Euler������ Quaternion���� ��ȯ
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    public void LookAt()
    {
        transform.LookAt(new Vector3(0, 0, 0));
    }

    private void Jump()
    {
        Debug.Log("Jump");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }

    private void OnJump(InputValue value)
    {
        Jump();
    }
}
