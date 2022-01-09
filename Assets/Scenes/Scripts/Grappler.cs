using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour {

    public Camera camera;
    public LineRenderer lRenderer;
    public DistanceJoint2D dJoint;

    // Start is called before the first frame update
    void Start()
    {
        dJoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Vector2 mPos = camera.ScreenToWorldPoint(Input.mousePosition);
            lRenderer.SetPosition(0, mPos);
            lRenderer.SetPosition(1, transform.position);
            dJoint.connectedAnchor = (Vector2) mPos;
            dJoint.enabled = true;
            lRenderer.enabled = true;
        }else if(Input.GetKeyDown(KeyCode.Mouse1)){
            dJoint.enabled = false;
            lRenderer.enabled = false;
        }

        if (dJoint.enabled)
        {
            lRenderer.SetPosition(1, transform.position); 
        }




    }
}
