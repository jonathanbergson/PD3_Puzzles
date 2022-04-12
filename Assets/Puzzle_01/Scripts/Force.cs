using UnityEngine;

public class Force : MonoBehaviour
{
    private const float FloatingBoxHeight = 1.0f;
    private const int RaycastDistance = 3;
    private static readonly Color RaycastColor = Color.red;

    private FixedJoint _joint;
    private bool _useForce;
    private bool _hasBoxGrabbed;

    private Rigidbody _boxRigidbody;
    private GameObject _boxGameObject;

    private void Awake()
    {
        _joint = GetComponent<FixedJoint>();
    }

    private void Update()
    {
        HandleUseForce();
        HandleRaycast();

        Debug.DrawRay(transform.position, transform.forward * RaycastDistance, RaycastColor);
    }

    private void HandleUseForce()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _useForce = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _useForce = false;
            DropBox();
        }
    }

    private void HandleRaycast()
    {
        Vector3 position = transform.position;
        Vector3 forward = transform.forward;

        bool collided = Physics.Raycast(position, forward, out var hit, RaycastDistance, Constants.ForceIgnoreLayerMask);
        if (collided && _useForce && _hasBoxGrabbed == false)
        {
            _boxRigidbody = hit.rigidbody;
            _boxGameObject = hit.collider.gameObject;

            GrabBox();
        }
    }

    private void GrabBox()
    {
        _hasBoxGrabbed = true;

        Vector3 position = transform.position + transform.forward * RaycastDistance;
        Vector3 newPosition = new Vector3(position.x, FloatingBoxHeight, position.z);

        _boxRigidbody.useGravity = false;
        _boxGameObject.transform.rotation = Quaternion.identity;
        _boxGameObject.transform.position = newPosition;
        _joint.connectedBody = _boxRigidbody;
    }

    private void DropBox()
    {
        _hasBoxGrabbed = false;

        if (_boxGameObject != null)
        {
            _boxRigidbody.useGravity = true;

            _joint.connectedBody = null;
            _boxGameObject = null;
            _boxRigidbody = null;
        }
    }
}
