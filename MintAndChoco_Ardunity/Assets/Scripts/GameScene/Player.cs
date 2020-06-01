using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ardunity;
public class Player : MonoBehaviour
{
    public DigitalInput digitalInput;

    private Rigidbody rb;

    public GameObject bulletPrefab;
    public GameObject bullets;

    private Transform beforeRotation;
    public Transform playerCamera;
    public Transform bulletPos;
    

    // Start is called before the first frame update
    void Start()
    {
        digitalInput.OnValueChanged.AddListener(OnDigitalInputChanged);
        rb = GetComponent<Rigidbody>();
        beforeRotation = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = playerCamera.rotation;
        if (beforeRotation.rotation.y != playerCamera.rotation.y)
        {
            StopFowrad();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShotBullet();
        }

        if (Input.GetKey(KeyCode.V))
        {
            MoveFoward(false, false);
        }
        beforeRotation.rotation = transform.rotation;
    }

    public void ShotBullet()
    {
        GameObject b = Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
        b.transform.SetParent(bullets.transform);
    }

    public void MoveFoward(bool fastMoved, bool slowMoved)
    {
        int speed = 10;
        if (fastMoved)
            speed = 20;
        if (slowMoved)
            speed = 5;

        rb.AddForce(transform.forward * speed);
    }

    public void StopFowrad()
    {
        rb.velocity = Vector3.zero;
    }

    public void OnDigitalInputChanged(bool value)
    {
        ShotBullet();
    }
}
