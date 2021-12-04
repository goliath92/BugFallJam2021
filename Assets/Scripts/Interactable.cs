using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void PickUp()
    {
        _rb.useGravity = false;
    }
    
    public void Release()
    {
        _rb.useGravity = true;
    }
}
