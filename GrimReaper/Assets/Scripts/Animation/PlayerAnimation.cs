using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;

    private CharacterController controller;
    private Animator anim;
    private bool isGrounded = false;
    private bool isWalking = false;
    private bool isJumped = false;
    private bool isAttacking = false;
    private bool isIdle = true;

    GrimReaper_LossofMemories _inputs;

    private void Awake()
    {
        _inputs = new GrimReaper_LossofMemories();
        _inputs.Enable();
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
        // Jump
        if (_inputs.Player.Jump.triggered && isGrounded && !isAttacking)
        {
            isJumped = true;
            anim.SetBool("isJumped", isJumped);
            isGrounded = false;
        }
        else if (isGrounded)
        {
            isJumped = false;
            anim.SetBool("isJumped", isJumped);
        }
        
        // Attack
        if (_inputs.Player.FireA.triggered || _inputs.Player.FireB.triggered)
        {
            isAttacking = true;
            anim.SetBool("isAttacking", isAttacking);
        }
        else
        {
            isAttacking = false;
            anim.SetBool("isAttacking", isAttacking);
        }

        // Walk
        Vector2 moveInput = _inputs.Player.MoveA.ReadValue<Vector2>() + _inputs.Player.MoveB.ReadValue<Vector2>();
        float moveMagnitude = moveInput.magnitude;

        if (moveMagnitude > 0.1f)
        {
            isWalking = true;
            anim.SetBool("isWalking", isWalking);
        }
        else
        {
            isWalking = false;
            anim.SetBool("isWalking", isWalking);
        }

        // Idle
        if (!isWalking && !isJumped && !isAttacking)
        {
            isIdle = true;
            anim.SetBool("isIdle", isIdle);
        }
        else
        {
            isIdle = false;
            anim.SetBool("isIdle", isIdle);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("TerrainObj"))
        {
            isGrounded = true;
        }

        if (hit.gameObject.name == "RockPlatform")
        {
            transform.parent = hit.transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RockPlatform")
        {
            transform.parent = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "RockPlatform")
        {
            transform.parent = null;
        }
    }

    // Other methods like Flip() can be added here if needed
}
