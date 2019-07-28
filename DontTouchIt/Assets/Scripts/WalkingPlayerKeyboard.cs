using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingPlayerKeyboard : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 5f;
    private Quaternion currentRotation;

    void Start()
    {
        currentRotation = transform.rotation;
    }

    void Update()
    {
        Vector3 walkDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.Translate(walkDirection * Time.deltaTime * speedMultiplier);
        currentRotation = currentRotation * Quaternion.Euler(0f, Input.GetAxis("Mouse X"), 0f);
        transform.rotation = currentRotation;
    }
}
