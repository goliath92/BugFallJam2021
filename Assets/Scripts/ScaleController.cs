using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScaleController : MonoBehaviour
{

    private float _rayRange =  100f;
    private Ray _ray;
    private TextMeshProUGUI _objectIdentifierText;
    private GameObject _currentObject;
    private float scaleSmall = 0.5f;
    private float scaleNormal = 1.0f;
    private float scaleLarge = 2.0f;
    public GameObject _pickedUpObject;
    private float pickUpDistance = 10.0f;
    public Transform _pickedUpObjectPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        _objectIdentifierText = GameObject.Find("Canvas/Object Identifier").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        DebugRaycastForward();
        _currentObject = GetObjectInFrontOfCamera();

        if (_pickedUpObject != null)
        {
            _pickedUpObject.transform.position = _pickedUpObjectPosition.position;
        }

        if (Input.GetKeyDown("1"))
        {
            if (_currentObject != null)
            {
                Debug.Log($"Scale set to small");
                _currentObject.transform.localScale = new Vector3(scaleSmall, scaleSmall, scaleSmall);
            }
        }else if (Input.GetKeyDown("2"))
        {
            if (_currentObject != null)
            {
                Debug.Log($"Scale set to normal");
                _currentObject.transform.localScale = new Vector3(scaleNormal, scaleNormal, scaleNormal);
            }
            
        }else if (Input.GetKeyDown("3"))
        {
            if (_currentObject != null)
            {
                Debug.Log($"Scale set to big");
                _currentObject.transform.localScale = new Vector3(scaleLarge, scaleLarge, scaleLarge);
            }
        }

        //pickup
        if (Input.GetKeyDown("e"))
        {
            //hand empty
            if (_pickedUpObject == null)
            {
                if (_currentObject != null)
                {
                    Debug.Log(Vector3.Distance(_currentObject.transform.position, this.transform.position));
                    if (Vector3.Distance(_currentObject.transform.position, this.transform.position) < pickUpDistance)
                    {
                        _currentObject.GetComponent<Interactable>().PickUp();
                        _pickedUpObject = _currentObject;
                    }
                }
            }
            else
            {
                _currentObject.GetComponent<Interactable>().Release();
                _pickedUpObject = null;
            }
        }
    }

    public GameObject GetObjectInFrontOfCamera()
    {
        RaycastHit hit;
        // Check if our raycast has hit anything
        if (Physics.Raycast (_ray.origin, Camera.main.transform.forward, out hit, _rayRange))
        {
            if (hit.transform.gameObject.CompareTag("Scalable"))
            {
                _currentObject = hit.transform.gameObject;
                _objectIdentifierText.text = _currentObject.name;
                return _currentObject;
            }
        }

        _objectIdentifierText.text = "";
        return null;
    }

    public void DebugRaycastForward()
    {
        Debug.DrawLine(_ray.origin, Camera.main.transform.forward * 50000000, Color.red);
    }
}
