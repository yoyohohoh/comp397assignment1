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

    //Private variables
    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _inputs = new GrimReaper_LossofMemories();
        _inputs.Enable();

    }

    private void Update()
    {
        isOgKey = DataKeeper.Instance.isOgKey;
        if (!isOgKey)
        {
            Debug.Log("PlayerController say Move B " + isOgKey);
            _inputs.Player.MoveB.Enable();
            _inputs.Player.FireB.Enable();
            _inputs.Player.MoveB.performed += context => _move = context.ReadValue<Vector2>();
            _inputs.Player.MoveB.canceled += context => _move = Vector2.zero;
            _inputs.Player.Jump.performed += context => Jump();
            _inputs.Player.FireB.performed += context => Fire();
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
            _inputs.Player.FireA.performed += context => Fire();
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
            SoundController.instance.Play("Jump");
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2.0f * _gravity);
        }
    }

    void Fire()
    {
        Debug.Log("Fire");
        SoundController.instance.Play("Attack");

    }

    private void SendMessage(InputAction.CallbackContext context)
    {
        Debug.Log($"Move Performed x = {context.ReadValue<Vector2>().x}, y = {context.ReadValue<Vector2>().y}");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Player hit by enemy");
            SoundController.instance.Play("EnemyAttack");
            GamePlayUIController.Instance.health.GetComponent<Slider>().value -= 1.0f;
            //connect to datakeeper (stage 3)
        }
    }
}
