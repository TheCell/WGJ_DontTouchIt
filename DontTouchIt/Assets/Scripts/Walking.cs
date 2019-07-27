using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{

    [SerializeField] private float movementspeed;

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 planeMovement = transform.forward;
        planeMovement.x = 0f;
        planeMovement = planeMovement.normalized;
        transform.Translate(planeMovement * movementspeed * Time.deltaTime);
        */
    }
}
