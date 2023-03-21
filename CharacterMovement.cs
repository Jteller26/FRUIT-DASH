/*
 * This class contains the movement functionality for the player-controlled character.
 */


using UnityEngine;

//needs chracter controller to matter what
[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    private GameObject dashEffect;
    public CharacterController controller;
    public Animator animator;
    public Transform ground;
    //Speed of the player using range
    [Range(4, 8)]
    public float speed;
    public float gravity;
    public float jumpHeight;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private Vector3 velocity;
    private bool isGrounded;

    private void Start()
    {
        dashEffect = GameObject.FindGameObjectWithTag("DashEffect");
    }

    void Update()
    { 
        isGrounded = Physics.CheckSphere(ground.position, groundDistance, groundMask);
        animator.SetBool("Grounded", isGrounded);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            dashEffect.SetActive(false);
        }

        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        if (zMove != 0)
        {
            dashEffect.SetActive(true);
        }
        
        if (xMove != 0 || zMove != 0)
        {
            animator.SetFloat("MoveSpeed", 1);
        }
        else
        {
            animator.SetFloat("MoveSpeed", 0);
        }
        
        Vector3 move = (transform.right * xMove + transform.forward * zMove).normalized;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

}