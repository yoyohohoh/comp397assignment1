using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

//To make sure the object contains the required components
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    public static PlayerController _instance;
    public static PlayerController Instance
    {
        get
        {
            return _instance;
        }
    }

    GrimReaper_LossofMemories _inputs;
    Vector2 _move;
    bool isOgKey;
    public bool isjumped;
    public bool isAttacking;


    [Header("Character Controller")]
    [SerializeField] CharacterController _controller;
    [SerializeField] Vector3 initialPosition;

    [Header("Joystick")]
    [SerializeField] private Joystick _joystick;

    [Header("Movements")]
    [SerializeField] float _speed;
    [SerializeField] float _gravity = -30.0f;
    [SerializeField] float _jumpHeight = 3.0f;
    [SerializeField] Vector3 _velocity;
    [SerializeField] float bounceForce = 5.0f;    

    [Header("Ground Detection")]
    [SerializeField] Transform _groundCheck;
    [SerializeField] float _groundRadius = 0.5f;
    [SerializeField] LayerMask _groundMask;
    [SerializeField] bool _isGrounded;

    [Header("Bounce Detection")]
    [SerializeField] public string bounceTag = "BounceObject"; 

    [Header("Shooting")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] private float _lastHorizontalInput = 1.0f;


    void Awake()
    {
        _instance = this;
        _controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        //player initial position
        if(DataKeeper.Instance.save1 != new Vector3 (0f, 0f, 0f))
        {
            _controller.enabled = false;
            transform.position = DataKeeper.Instance.save1;
            _controller.enabled = true;
        }
        else
        {
            InitiatePlayerPosition();
        }
        
        isjumped = false;
        isAttacking = false;
    }

    void FixedUpdate()
    {
        _move = _joystick.Direction;

        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundRadius, _groundMask);
        if (_isGrounded && _velocity.y < 0.0f)
        {
            _velocity.y = -2.0f;
        }

        // Create movement vector, keeping Z component as 0
        Vector3 movement = new Vector3(_move.x, 0.0f, 0.0f) * _speed * Time.fixedDeltaTime;
        _controller.Move(movement);
        _velocity.y += _gravity * Time.fixedDeltaTime;

        // Move the player vertically (jumping/falling), without affecting the Z-axis
        _controller.Move(new Vector3(0, _velocity.y, 0) * Time.fixedDeltaTime);

        //Fixed Z position
        Vector3 position = transform.position;
        position.z = initialPosition.z;
        transform.position = position;

        // Update _lastHorizontalInput if there's any horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            _lastHorizontalInput = horizontalInput;
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_groundCheck.position, _groundRadius);
    }

    public void InitiatePlayerPosition()
    {
        _controller.enabled = false;
        transform.position = initialPosition;
        _controller.enabled = true;
    }
    public void Jump() // method will be called from clicking jump button
    {
        Debug.Log("Jump");
        if (_isGrounded)
        {
            isjumped = true;
            SoundController.instance.Play("Jump");
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2.0f * _gravity);
        }
    }

    public void Shoot() // method will be called from clicking jump button
    {
        Debug.Log("Shoot");
        SoundController.instance.Play("Attack");
        isAttacking = true;
        if (projectilePrefab != null)
        {
            // Calculate the spawn position on the right side of the player
            Vector3 spawnPosition = transform.position + transform.right * 1.0f;

            // Use the last horizontal input to determine the movement direction
            Vector3 movementDirection = new Vector3(_lastHorizontalInput, 0f, 0f).normalized;

            // Instantiate the projectile with the calculated forward direction as the rotation
            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.LookRotation(movementDirection));

            Projectile projectileComponent = projectile.GetComponent<Projectile>();

            if (projectileComponent != null)
            {
                Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
                if (projectileRigidbody != null)
                {
                    // Set the projectile's velocity in the movement direction
                    projectileRigidbody.velocity = movementDirection * projectileComponent.speed;
                }
            }
        }

    }

    private void SendMessage(InputAction.CallbackContext context)
    {
        Debug.Log($"Move Performed x = {context.ReadValue<Vector2>().x}, y = {context.ReadValue<Vector2>().y}");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player touch" + other.name);
        if (other.gameObject.tag == "Enemy")
        {
            //when player touch enemy, player's health will decrease
            Debug.Log("Player hit by enemy");
            SoundController.instance.Play("EnemyAttack");
            GamePlayUIController.Instance.UpdateHealth(-1.0f);
            //connect to datakeeper (stage 3)
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag(bounceTag) && _isGrounded)
        {          
            Debug.Log("Player hit bounce object");
            _velocity.y = Mathf.Sqrt(bounceForce * -2f * _gravity);
            SoundController.instance.Play("Jump");
        }
    }



}