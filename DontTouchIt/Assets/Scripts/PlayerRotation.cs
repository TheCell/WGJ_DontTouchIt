﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private bool useMouseRotation = false;
    private Gyroscope phoneGyro;
    private Quaternion correctionQuaternion;

    // Start is called before the first frame update
    void Start()
    {
        phoneGyro = Input.gyro;
        phoneGyro.enabled = true;
        correctionQuaternion = Quaternion.Euler(90f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (useMouseRotation)
        {
            Quaternion currentRotation = transform.rotation;
            currentRotation = currentRotation * Quaternion.Euler(0f, Input.GetAxis("Mouse X"), 0f);
            transform.rotation = currentRotation;
        }
        else
        {
            GyroModifyCamera();
        }
    }

    // The Gyroscope is right-handed.  Unity is left handed.
    // Make the necessary change to the camera.
    void GyroModifyCamera()
    {
        Quaternion gyroQuaternion = GyroToUnity(Input.gyro.attitude);
        // rotate coordinate system 90 degrees. Correction Quaternion has to come first
        Quaternion calculatedRotation = correctionQuaternion * gyroQuaternion;
        transform.rotation = calculatedRotation;
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
