using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private float _xRotation = 0f;
    private Rigidbody _rb;
    private PlayerInput _input;
    private bool _isGrounded;
    [Header("Настройки движения")]
    [SerializeField] public float moveSpeed;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheckPoint;

    [Header("Настройки камеры")]
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] float maxVerticalAngle = 80f;
    [SerializeField] Transform cameraTransform;

    [Header("Настройки спавна врагов")]
    [SerializeField] private GameObject enemyPrefab; 
    [SerializeField] private float spawnDistance = 5f; 
    




    private void Awake()
    {
        _input = new PlayerInput();
        _input.Player.Jump.performed += context => CheckedJump();
        _input.Player.SpawnEnemy.performed += context => SpawnEnemy();


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
            
        
    }
    private void Update()
    {
        CheckGrounded();
        MouseLook();
        Move();
        

        Debug.DrawRay(groundCheckPoint.position, Vector3.down * groundCheckDistance, Color.red);
    }

    private void CheckGrounded()
    {
       
        _isGrounded = Physics.Raycast(groundCheckPoint.position, Vector3.down, groundCheckDistance, groundLayer);
    }

    private void CheckedJump()
    {
        if (_isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
        _rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
    }

    private void Move()
    {
        Vector2 _direction = _input.Player.Move.ReadValue<Vector2>();
        Vector3 forwardDirection = transform.forward * _direction.y;


        Vector3 rightDirection = transform.right * _direction.x;


        Vector3 moveDirection = (forwardDirection + rightDirection).normalized * moveSpeed;
        moveDirection.y = _rb.velocity.y;

        _rb.velocity = moveDirection;
    }
    private void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position + transform.forward * spawnDistance;
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

    }
    private void MouseLook()
    {
        Vector2 mouseDelta = _input.Player.Look.ReadValue<Vector2>() * mouseSensitivity * Time.deltaTime;


        _xRotation -= mouseDelta.y;
        _xRotation = Mathf.Clamp(_xRotation, -maxVerticalAngle, maxVerticalAngle);

        cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseDelta.x);
    }
    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


}