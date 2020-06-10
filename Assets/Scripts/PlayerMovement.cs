using UnityEngine;

/// <summary>
/// Controls player's movement.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public Transform groundCheck;
    public CharacterController characterController;
    public GameManager gameManager;
    public LayerMask groundMask;


    public float speed = 12f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 2f;
    public bool canPlay = true;

    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        
    }

    void Update()
    {
        if (canPlay)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            characterController.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            characterController.Move(velocity * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("loss"))
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameManager.Loss();
        }
        else if (other.gameObject.CompareTag("obstacle"))
        {
            other.gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
