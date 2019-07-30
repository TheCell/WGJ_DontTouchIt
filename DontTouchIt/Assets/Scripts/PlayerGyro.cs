using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGyro : MonoBehaviour
{
    [SerializeField] private GameObject objectToTurn;
    private Gyroscope phoneGyro;
    private Vector3 previousRotationPosition = Vector3.zero;

    private void Start()
    {
        phoneGyro = Input.gyro;
        phoneGyro.enabled = true;
    }

    private void Update()
    {
        GyroModifyCamera();
    }

    // The Gyroscope is right-handed.  Unity is left handed.
    // Make the necessary change to the camera.
    void GyroModifyCamera()
    {
        /*
        Quaternion gyroRotation = GyroToUnity(Input.gyro.attitude);
        Quaternion objectRotation = transform.rotation;
        objectRotation = Quaternion.Euler(objectRotation.eulerAngles.x, gyroRotation.eulerAngles.y, objectRotation.eulerAngles.z);
        transform.rotation = objectRotation;
        transform.rotation = gyroRotation;
        */

        Quaternion gyroQuaternion = GyroToUnity(Input.gyro.attitude);
        Vector3 playerRotation = objectToTurn.transform.rotation.eulerAngles;
        float currentRotation = GetCurrentRotation(gyroQuaternion);
        Debug.Log(currentRotation);
        playerRotation.y = playerRotation.y + currentRotation;
        objectToTurn.transform.rotation = Quaternion.Euler(playerRotation);
        //objectToTurn.transform.rotation = 
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    private float GetCurrentRotation(Quaternion currentRotationstate)
    {
        float xzAngle = 0f;
        Vector3 newRotationPos = currentRotationstate.eulerAngles;
        xzAngle = Vector3.Angle(new Vector3(newRotationPos.x, 0f, newRotationPos.z), new Vector3(previousRotationPosition.x, 0f, previousRotationPosition.z));
        previousRotationPosition = currentRotationstate.eulerAngles;
        return xzAngle;
    }
}
