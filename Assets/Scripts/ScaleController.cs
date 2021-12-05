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
    public float _pushForce = 1000.0f;

    public Transform map;
    public float scaleStepSize = 0.1f;

    public ParticleSystem explosionParticle = null;

    
    
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


        if (_currentObject != null)
        {
            if (Input.GetKeyDown("1"))
            {
                explosionParticle.transform.position = _currentObject.transform.position;
                explosionParticle.Play();
                Debug.Log($"Scale set to small");
                _currentObject.GetComponent<Interactable>().SetScale(scaleSmall);
            }else if (Input.GetKeyDown("2"))
            {
                explosionParticle.transform.position = _currentObject.transform.position;
                explosionParticle.Play();
                Debug.Log($"Scale set to normal");
                _currentObject.GetComponent<Interactable>().SetScale(scaleNormal);
            }else if (Input.GetKeyDown("3"))
            {
                explosionParticle.transform.position = _currentObject.transform.position;
                explosionParticle.Play();
                Debug.Log($"Scale set to big");
                _currentObject.GetComponent<Interactable>().SetScale(scaleLarge);
            }
        }
        

        //pickup - release
        if (Input.GetKeyDown("e"))
        {
            //hand empty
            if (_pickedUpObject == null)
            {
                if (_currentObject != null)
                {
                    if (_currentObject.transform.localScale.x == 0.5f && (Vector3.Distance(_currentObject.transform.position, this.transform.position) < pickUpDistance))
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
        
        //throw
        if (Input.GetMouseButtonDown(0))
        {
            if (_pickedUpObject != null)
            {
                _pickedUpObject.GetComponent<Interactable>().Release();
                _pickedUpObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * _pushForce);
                _pickedUpObject = null;
            }
        }
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
        {
            map.localScale = new Vector3(map.localScale.x + scaleStepSize, map.localScale.y + scaleStepSize, map.localScale.z + scaleStepSize);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
        {
            if (map.localScale.x - scaleStepSize > 0)
            {
                map.localScale = new Vector3(map.localScale.x - scaleStepSize, map.localScale.y - scaleStepSize, map.localScale.z - scaleStepSize);
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
