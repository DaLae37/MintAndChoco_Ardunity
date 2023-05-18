using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ardunity;
public class Player : MonoBehaviour
{
    public ArdunityApp ardunityApp;
    public DigitalInput digitalInput;
    public MPUSeries mpu;

    private Rigidbody rb;
    
    public GameObject bulletPrefab;
    public GameObject bullets;
    public GameObject bomb;

    private Transform beforeRotation;
    public Transform playerCamera;
    public Transform bulletPos;

    private bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        ardunityApp.OnConnected.AddListener(StartedGame);
        ardunityApp.OnDisconnected.AddListener(StopGame);
        mpu.OnStartCalibration.AddListener(OnStartCalibration);
        mpu.OnCalibrated.AddListener(OnCalibrated);
        digitalInput.OnValueChanged.AddListener(OnDigitalInputChanged);

        rb = GetComponent<Rigidbody>();
        beforeRotation = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            Quaternion rot = mpu.rotation;
            transform.rotation = playerCamera.rotation;
            if (rot.x < 0.2 && rot.x > -0.2)
            {
                StopFowrad();
            }
            else if((rot.x < -0.4) || (rot.x > 0.4))
            {
                MoveFoward((rot.x < -0.4), (rot.x > 0.4));
            }
            if (Input.GetKey(KeyCode.Q))
            {
            }
            beforeRotation.rotation = transform.rotation;
        }
    }

    public void ShotBullet()
    {
        GameObject b = Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
        b.transform.SetParent(bullets.transform);
    }

    public void MoveFoward(bool fastMoved, bool slowMoved)
    {
        int speed = 15;
        if (fastMoved)
            speed = 20;
        if (slowMoved)
            speed = 10;

        rb.AddForce(transform.forward * speed);
    }

    public void StopFowrad()
    {
        rb.velocity = Vector3.zero;
    }

    public void OnDigitalInputChanged(bool value)
    {
        if (value)
        {
            ShotBullet();
        }
    }

    public void MPUCalibration()
    {
        mpu.Calibration();
    }
    void OnStartCalibration()
    {

    }

    void OnCalibrated()
    {

    }

    void StartedGame()
    {
        isStarted = true;
    }

    void StopGame()
    {
        isStarted = false;
    }
}
