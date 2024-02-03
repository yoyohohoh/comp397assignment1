using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    GrimReaper_LossofMemories _inputs;
    Vector2 _move;

    [Header("Character Controller")]
    [SerializeField] CharacterController _controller;

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

        _inputs.Player.Move.performed += context => _move = context.ReadValue<Vector2>();
        _inputs.Player.Move.canceled += context => _move = Vector2.zero;

        _inputs.Player.Jump.performed += context => Jump();

        // New: Handle shooting
        _inputs.Player.Fire.performed += context => Shoot();
    }

    void FixedUpdate()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundRadius, _groundMask);
        if (_isGrounded && _velocity.y < 0.0f)
        {
            _velocity.y = -2.0f;
        }
        Vector3 movement = new Vector3(_move.x, 0.0f, _move.y) * _speed * Time.fixedDeltaTime;
        _controller.Move(movement);
        _velocity.y += _gravity * Time.fixedDeltaTime;
        _controller.Move(_velocity * Time.fixedDeltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_groundCheck.position, _groundRadius);
    }

    void Jump()
    {
        if (_isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2.0f * _gravity);
        }
    }


    void Shoot()
    {
        if (projectilePrefab != null)
        {
            // Calculate the spawn position on the left side of the player
            Vector3 spawnPosition = transform.position + transform.right * 1.0f;

            // Instantiate the projectile with the player's forward direction as the rotation
            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.LookRotation(transform.forward));

            // Get the Projectile component from the instantiated projectile
            Projectile projectileComponent = projectile.GetComponent<Projectile>();

            if (projectileComponent != null)
            {
                // Set the velocity of the projectile based on the player's right direction and speed
                Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
                if (projectileRigidbody != null)
                {
                    projectileRigidbody.velocity = transform.right * projectileComponent.speed;
                }
            }
        }
    }

}


