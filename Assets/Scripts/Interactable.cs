using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Rigidbody _rb;

    private float changeScaleRevertTime = 5.0f;
    
    public Transform player;
    
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
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

    public void SetScale(float scale)
    {
        StartCoroutine(ChangeScale(scale));
    }

    public IEnumerator ChangeScale(float scale)
    {
        this.transform.localScale = new Vector3(scale, scale, scale);
        yield return new WaitForSeconds(changeScaleRevertTime);
        this.transform.localScale = new Vector3(1, 1, 1);
        player.GetComponent<ScaleController>()._pickedUpObject = null;
        Release();
    }
}
