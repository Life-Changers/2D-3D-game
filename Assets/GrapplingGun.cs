using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector2 grapplePoint;
    public LayerMask whatIsGrappleable;
    [SerializeField] public Transform gunTip, mousePosition, playerPosition;
    [SerializeField] private float maxDistance = 100f;
    private SpringJoint joint;
    [SerializeField] private Camera mainCamera;


    void Awake() {
        lr = GetComponent<LineRenderer>();   
    }

    private void Update() {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
     
        if (Input.GetMouseButtonDown(0)) {
            StartGrapple();
        } else if (Input.GetMouseButtonUp(0)) {
            StopGrapple();
        }

        void StartGrapple() {
    
            RaycastHit2D hit;
            if (Physics.Raycast(mousePosition., mousePosition.forward, out hit, maxDistance))
            grapplePoint = hit.point;
            joint = mousePosition.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(mousePosition.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = 5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

        }

        void StopGrapple() {

        }
    }
}
