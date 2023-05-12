using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityBasic : MonoBehaviour
{
    [Header("This GameObject")]
    public GameObject thisGameObject;
    public string thisName;
    public bool thisActive;
    public string thisTag;
    public int thisLayer;

    [Header("Find GameObject")]
    public GameObject findWithName;
    public GameObject findWithTag;
    public GameObject[] findsWithTag;

    [Header("New & Destory GameObject")]
    public GameObject newGameObject;
    public GameObject destroyGameObject;

    [Space(30)]

    [Header("GetComponent On SameGameObject")]
    public AudioSource gameObjectGetComponent;
    public AudioSource componentGetComponent;

    [Header("GetComponent On OtherGameObject")]
    public GameObject otherGameObject;

    public AudioSource component;
    public AudioSource childComponent;
    public AudioSource parentComponent;
    public AudioSource[] components;
    public AudioSource[] childComponents;
    public AudioSource[] parentComponents;

    [Header("Find Component")]
    public Rigidbody findWithType;
    public Rigidbody[] findsWithType;
    public AudioSource findAudioSource;

    [Header("Add & Destroy Component")]
    public GameObject addComponent;
    public Component destroyComponent;

    private void Start()
    {
        GameObjectBasic();
        ComponentBasic();
    }

    void GameObjectBasic()
    {
        // <���ӿ�����Ʈ ����>
        // ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ�� gameObject �Ӽ��� �̿��Ͽ� ���ٰ���
        thisGameObject = gameObject;                // ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ

        thisName = gameObject.name;                 // ���ӿ�����Ʈ�� �̸� ����
        thisActive = gameObject.activeSelf;         // ���ӿ�����Ʈ�� Ȱ��ȭ ���� ����
        thisTag = gameObject.tag;                   // ���ӿ�����Ʈ�� �±� ����
        thisLayer = gameObject.layer;               // ���ӿ�����Ʈ�� ���̾� ����

        // <�� ���� ���ӿ�����Ʈ Ž��>
        findWithName = GameObject.Find("Capsule");           // �̸����� ã��
        // findWithTag = GameObject.FindGameObjectWithTag("MyTag");    // �±׷� �ϳ� ã��
        // findsWithTag = GameObject.FindGameObjectsWithTag("MyTag");  // �±׷� ��� ã��

        // <���ӿ�����Ʈ ����>
        newGameObject = new GameObject();

        // <���ӿ�����Ʈ ����>
        if (destroyGameObject != null)
            Destroy(destroyGameObject);
    }

    void ComponentBasic()
    {
        // <���ӿ�����Ʈ �� ������Ʈ ����>
        // GetComponent�� �̿��Ͽ� ���ӿ�����Ʈ �� ������Ʈ ����
        gameObjectGetComponent = gameObject.GetComponent<AudioSource>();
        // ������Ʈ���� GetComponent�� ����� ��� �����Ǿ� �ִ� ���ӿ�����Ʈ�� �������� ����
        componentGetComponent = GetComponent<AudioSource>();    // == gameObject.GetComponent<AudioSource>();

        component = otherGameObject.GetComponent<AudioSource>();                    // ���ӿ�����Ʈ�� ������Ʈ ����
        components = otherGameObject.GetComponents<AudioSource>();                  // ���ӿ�����Ʈ�� ������Ʈ�� ����
        childComponent = otherGameObject.GetComponentInChildren<AudioSource>();     // �ڽ� ���ӿ�����Ʈ ���� ������Ʈ ����
        childComponents = otherGameObject.GetComponentsInChildren<AudioSource>();   // �ڽ� ���ӿ�����Ʈ ���� ������Ʈ�� ����
        parentComponent = otherGameObject.GetComponentInParent<AudioSource>();      // �θ� ���ӿ�����Ʈ ���� ������Ʈ ����
        parentComponents = otherGameObject.GetComponentsInParent<AudioSource>();    // �θ� ���ӿ�����Ʈ ���� ������Ʈ�� ����

        // <�� ���� ������Ʈ Ž��>
        findWithType = FindObjectOfType<Rigidbody>();                               // �� ���� ������Ʈ �ϳ� ã��
        findsWithType = FindObjectsOfType<Rigidbody>();                             // �� ���� ������Ʈ ��� ã��
        findAudioSource = FindObjectOfType<AudioSource>();

        // <������Ʈ �߰�>
        // Rigidbody rigid = new Rigidbody();	// �����ϳ� �ǹ̾���, ������Ʈ�� ���ӿ�����Ʈ�� �����Ǿ� �����Կ� �ǹ̰� ����
        Rigidbody rigid = addComponent.AddComponent<Rigidbody>();                   // ���ӿ�����Ʈ�� ������Ʈ �߰�

        // <������Ʈ ����>
        Destroy(destroyComponent);
    }
}
