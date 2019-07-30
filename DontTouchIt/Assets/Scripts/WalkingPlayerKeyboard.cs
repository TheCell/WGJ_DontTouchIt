using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingPlayerKeyboard : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 5f;

    void Update()
    {
        Vector3 walkDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.Translate(walkDirection * Time.deltaTime * speedMultiplier);
    }
}
