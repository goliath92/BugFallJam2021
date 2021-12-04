using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Debug.Log($"Scale set to small");
        }else if (Input.GetKeyDown("2"))
        {
            Debug.Log($"Scale set to normal");
        }else if (Input.GetKeyDown("3"))
        {
            Debug.Log($"Scale set to big");
        }
    }
}
