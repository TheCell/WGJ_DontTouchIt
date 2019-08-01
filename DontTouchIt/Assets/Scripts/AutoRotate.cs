using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    void Update()
    {
        Quaternion currentRotation = transform.rotation;
        Vector3 angles = currentRotation.eulerAngles;
        angles.y += 10 * Time.deltaTime;
        transform.rotation = Quaternion.Euler(angles);
    }
}
