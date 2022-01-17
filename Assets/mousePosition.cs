using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousePosition : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Debug.Log(mainCamera.ScreenToWorldPoint(Input.mousePosition));
       // Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
       // mouseWorldPosition.z = 0f;
       // transform.position = mouseWorldPosition;
    }
}
