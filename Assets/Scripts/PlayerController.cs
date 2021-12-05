using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private CapsuleCollider _collider;
    public Transform _spawnPoint;
    private GameManager _gameManager;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {

        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.transform.CompareTag("Red"))
        {
            this.transform.position = _spawnPoint.position;
        }
    }

}
