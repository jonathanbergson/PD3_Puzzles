using UnityEngine;

public class Character : MonoBehaviour
{
    private const float Speed = 8.0f;
    private const float RotationSpeed = 5.0f;
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    public Animator animator;
    private CharacterController _controller;

    private Vector3 _moveDirection = Vector3.zero;
    private bool _isMoving;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            _isMoving = true;
            _moveDirection = new Vector3(horizontal, 0, vertical);
        }
        else
        {
            _isMoving = false;
        }

        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        if (_isMoving)
        {
            animator.SetBool(IsMoving, true);
            _controller.Move(_moveDirection * Speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool(IsMoving, false);
        }
    }

    private void HandleRotation()
    {
        if (_isMoving == false) return;

        Vector3 lookDirection = _moveDirection;
        lookDirection.y = 0;

        Quaternion rotation = transform.rotation;
        Quaternion toRotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Slerp(rotation, toRotation, RotationSpeed * Time.deltaTime);
    }
}
