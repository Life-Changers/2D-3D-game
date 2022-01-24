using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook2 : MonoBehaviour
{
    bool isgrounded = true;
    [SerializeField] public LineRenderer line;
    public DistanceJoint2D joint;
    public Vector3 targetPos;
    public RaycastHit2D hit;
    [SerializeField] public float maxDistance = 1f;
    [SerializeField]  public LayerMask canCollideWith;
    public float step = 0.2f;
    [SerializeField] private Camera mainCamera;
    public Rigidbody2D player;
    // ili transformator da vzemem ne sum siguren


    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        player = GetComponent<Rigidbody2D>();
        joint.enabled = false;
        line.enabled = false;
        Hook();
    }

    // Update is called once per frame
    void Update()
    {

        Hook();

    }
    void Hook()
    {
        if (joint.distance > 1f)
        {
            joint.distance -= step;
        }
        else
        {
            line.enabled = false;
            joint.enabled = false;
        }
        if (Input.GetMouseButton(0))
        {
            targetPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;
            hit = Physics2D.Raycast(transform.position, targetPos - transform.position, maxDistance, canCollideWith);
            if (hit.collider != null)
            {

                joint.enabled = true;
                // player.AddForce(); 
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.connectedAnchor = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                joint.distance = Vector2.Distance(transform.position, hit.point);

                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);
            }
        }
    }
}
