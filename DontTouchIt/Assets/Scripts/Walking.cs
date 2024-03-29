﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] private float movementspeed;
    [SerializeField] private float movementspeedMultiplier;
    [SerializeField] private bool isAutowalking;

    // Update is called once per frame
    void Update()
    {
        if (isAutowalking)
        {
            Vector3 planeMovement = transform.forward;
            planeMovement.y = 0f;
            planeMovement = planeMovement.normalized;
            transform.Translate(planeMovement * movementspeed * Time.deltaTime, Space.World);

            movementspeed += Time.deltaTime * movementspeedMultiplier;
        }
    }
}
