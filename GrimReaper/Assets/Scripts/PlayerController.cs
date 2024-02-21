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
    GrimReaper_LossofMemories _inputs;
    Vector2 _move;
    bool isOgKey;


    [Header("Character Controller")]
    [SerializeField] CharacterController _controller;
    [SerializeField] Vector3 initialPosition;

    [Header("Movements")]
    [SerializeField] float _speed;
    [SerializeField] float _gravity = -30.0f;
    [SerializeField] float _jumpHeight = 3.0f;
    [SerializeField] Vector3 _velocity;

    [Header("Ground Detection")]
    [SerializeField] Transform _groundCheck;
    [SerializeField] float _groundRadius = 0.5f;
    [SerializeField] LayerMask _groundMask;
    [SerializeField] bool _isGrounded;

    [Header("Shooting")]
    [SerializeField] GameObject projectilePrefab;

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _inputs = new GrimReaper_LossofMemories();
        _inputs.Enable();



    }

    void Start()
    {
        //player initial position
        InitiatePlayerPosition();
    }

    private void Update()
    {
        //get data from datakeeper that which key player chose in the previous scene
        isOgKey = DataKeeper.Instance.isOgKey;
        if (!isOgKey)
        {
            Debug.Log("PlayerController say Move B " + isOgKey);
            _inputs.Player.MoveB.Enable();
            _inputs.Player.FireB.Enable();
            _inputs.Player.MoveB.performed += context => _move = context.ReadValue<Vector2>();
            _inputs.Player.MoveB.canceled += context => _move = Vector2.zero;
            _inputs.Player.Jump.performed += context => Jump();
            _inputs.Player.FireB.performed += context => Shoot();
            _inputs.Player.MoveA.Disable();
            _inputs.Player.FireA.Disable();
        }
        else
        {
            Debug.Log("PlayerController say Move A " + isOgKey);
            _inputs.Player.MoveA.Enable();
            _inputs.Player.FireA.Enable();
            _inputs.Player.FireA.Enable();
            _inputs.Player.MoveA.performed += context => _move = context.ReadValue<Vector2>();
            _inputs.Player.MoveA.canceled += context => _move = Vector2.zero;
            _inputs.Player.Jump.performed += context => Jump();
            _inputs.Player.FireA.performed += context => Shoot();
            _inputs.Player.MoveB.Disable();
            _inputs.Player.FireB.Disable();
        }
    }

    void FixedUpdate()
    {      
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundRadius, _groundMask);
        if (_isGrounded && _velocity.y < 0.0f)
        {
            _velocity.y = -2.0f;
        }

        // Create movement vector, keeping Z component as 0
        Vector3 movement = new Vector3(_move.x, 0.0f, 0.0f) * _speed * Time.fixedDeltaTime;
               
        _controller.Move(movement);

        // Apply gravity to Y velocity
        _velocity.y += _gravity * Time.fixedDeltaTime;

        // Move the player vertically (jumping/falling), without affecting the Z-axis
        _controller.Move(new Vector3(0, _velocity.y, 0) * Time.fixedDeltaTime);

        //Fixed Z position
        Vector3 position = transform.position;
        position.z = initialPosition.z; 
        transform.position = position;




    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_groundCheck.position, _groundRadius);
    }

    void InitiatePlayerPosition()
    {
        initialPosition = new Vector3();
        _controller.enabled = false;
        transform.position = initialPosition;
        _controller.enabled = true;
    }
    void Jump()
    {
        if (_isGrounded)
        {
            SoundController.instance.Play("Jump");
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2.0f * _gravity);
        }
    }

    void Shoot()
    {
        Debug.Log("Shoot");
        SoundController.instance.Play("Attack");
        if (projectilePrefab != null)
        {
            // Calculate the spawn position on the right side of the player
            Vector3 spawnPosition = transform.position + transform.right * 1.0f;

            // Determine the movement direction based on player input
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector3 movementDirection = new Vector3(horizontalInput, 0f, 0f).normalized;

            // Calculate the forward direction based on the movement direction
            Vector3 forwardDirection = movementDirection.magnitude > 0f ? movementDirection : transform.forward;

            // Instantiate the projectile with the calculated forward direction as the rotation
            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.LookRotation(forwardDirection));

            // Get the Projectile component from the instantiated projectile
            Projectile projectileComponent = projectile.GetComponent<Projectile>();

            if (projectileComponent != null)
            {
                Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
                if (projectileRigidbody != null)
                {
                    projectileRigidbody.velocity = forwardDirection * projectileComponent.speed;
                }
            }
        }

    }

    private void SendMessage(InputAction.CallbackContext context)
    {
        Debug.Log($"Move Performed x = {context.ReadValue<Vector2>().x}, y = {context.ReadValue<Vector2>().y}");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //when player touch enemy, player's health will decrease
            Debug.Log("Player hit by enemy");
            SoundController.instance.Play("EnemyAttack");
            GamePlayUIController.Instance.health.GetComponent<Slider>().value -= 1.0f;
            //connect to datakeeper (stage 3)
        }
    }
}