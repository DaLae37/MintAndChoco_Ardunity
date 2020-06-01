using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ardunity;

public class MovingController : MonoBehaviour
{
    public MPUSeries mpu;
    // Start is called before the first frame update
    void Start()
    {
        mpu.OnStartCalibration.AddListener(OnStartCalibration);
        mpu.OnCalibrated.AddListener(OnCalibrated);
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rot = mpu.rotation;
        Debug.Log(rot);
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
}
