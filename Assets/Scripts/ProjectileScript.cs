using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public float _rotationSpeed = 0.1f;
    public float _movementSpeed = 0.1f;
    public Transform _player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion lookOnLook =
            Quaternion.LookRotation(_player.transform.position - transform.position);
 
        transform.rotation =
            Quaternion.Slerp(transform.rotation, lookOnLook, Time.deltaTime * _rotationSpeed);

        transform.position += transform.forward * _movementSpeed;
    }
}
