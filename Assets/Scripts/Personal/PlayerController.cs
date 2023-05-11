using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //���ǵ� ���� ����
    [SerializeField]
    private float walkSpeed;

    // applySpeed�� walkSpeed, runSpeed, crouchSpeed �� �� �ϳ��� �Ҵ� �ȴ�.
    private float applySpeed;

    [SerializeField]
    private float jumpForce;

    private float originPosY;
   
    private bool isGround = true;
    private bool isWalk = false;

    //������ üũ ����
    private Vector3 lastPos;

    //�ΰ���
    [SerializeField]
    private float lookSensitivity;

    //ī�޶� �Ѱ�
    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;

    //�ʿ��� ������Ʈ
    [SerializeField]
    private Camera theCamera;

    // �� ���� ����
    [SerializeField]
    private BoxCollider boxCollider;

    [SerializeField]
    private Rigidbody myRigid;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        myRigid = GetComponent<Rigidbody>();

        //�ʱ�ȭ
        applySpeed = walkSpeed;
        originPosY = theCamera.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        IsGround();
        TryJump();

        Move();
        // CameraRotation();
        CharacterRotation();
    }

    void FixedUpdate()
    {
        MoveCheck();
    }

    private void LateUpdate()
    {
        CameraRotation();
    }

    //���� üũ
    private void IsGround()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, boxCollider.bounds.extents.y + 0.1f);
        // Debug.Log("isGround");
    }

    //���� �õ�
    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
            Jump();
    }

    private void Jump()
    {
        myRigid.velocity = transform.up * jumpForce;
        Debug.Log("����");
    }

    // ������ ����
    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed;

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
    }

    private void MoveCheck()
    {
        if (isGround)
        {
            if (Vector3.Distance(lastPos, transform.position) >= 0.01f)
                isWalk = true;
            else
                isWalk = false;

            lastPos = transform.position;
        }
    }

    private void CameraRotation()
    {
        //���� ī�޶� ȸ��
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    private void CharacterRotation()
    {
        //�¿� ĳ���� ȸ��
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
    }
}
