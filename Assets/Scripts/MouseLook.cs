using UnityEngine;

/// <summary>
/// Class that controlls a camera via mouse input.
/// </summary>
public class MouseLook : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Transform playerCore;

    public bool canPlay;
    public float mouseSensetivity = 100f;
    
    private float xRotation = 0f;

    void Start()
    {
        canPlay = true;
    }

    void Update()
    {
        if (canPlay)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerCore.Rotate(Vector3.up * mouseX);
        }
    }
}
