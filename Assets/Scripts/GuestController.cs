using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestController : MonoBehaviour
{
    void Update()
    {
        // Move the vehicle forward based on vertical input
        transform.Translate(20.0f * Time.deltaTime * Vector3.forward);
    }
}
