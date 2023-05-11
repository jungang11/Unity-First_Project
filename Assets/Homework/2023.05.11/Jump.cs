using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // ���� ���� ����
    [SerializeField]
    public float jumpForce;

    Rigidbody myRigid;

    void Awake()
    {
        myRigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        name = "Player";

        Jumper();
    }

    void Jumper()
    {
        myRigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        // myRigid.velocity = transform.up * jumpForce;
        Debug.Log("����");
    }
}
