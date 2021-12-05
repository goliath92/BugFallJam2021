using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.forward, 20*Time.fixedDeltaTime);
    }
}
