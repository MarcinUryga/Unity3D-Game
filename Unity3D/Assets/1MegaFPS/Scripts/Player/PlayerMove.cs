using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    //variables for keyboard
    public float moveSpeed;
    public float runSpeed;
    public float jumpHeight;
    public float actualJumpHeight;

    //variables for mouse
    public float mouseSensitive;
    public float mouseUpDown = 0.0f;
    private float mouseBoundary = 90;

    public CharacterController heroController;

    // Use this for initialization
    void Start()
    {
        heroController = GetComponent<CharacterController>();
    }

    void Keyboard()
    {
        float moveLeftRight = Input.GetAxis("Horizontal") * moveSpeed;
        float moveForwardBack = Input.GetAxis("Vertical") * moveSpeed;

        if (heroController.isGrounded && Input.GetButton("Jump"))
            actualJumpHeight = jumpHeight;
        else if (!heroController.isGrounded)
            actualJumpHeight += Physics.gravity.y * Time.deltaTime;

        if (Input.GetKeyDown("left shift"))
            moveSpeed += runSpeed;
        else if (Input.GetKeyUp("left shift"))
            moveSpeed -= runSpeed;

        Vector3 move = new Vector3(moveLeftRight, actualJumpHeight, moveForwardBack);
        move = transform.rotation * move;

        heroController.Move(move * Time.deltaTime);
    }

    void Mouse()
    {
        float mouseLeftright = Input.GetAxis("Mouse X") * mouseSensitive;
        transform.Rotate(0, mouseLeftright, 0);

        mouseUpDown -= Input.GetAxis("Mouse Y") * mouseSensitive;

        mouseUpDown = Mathf.Clamp(mouseUpDown, -mouseBoundary, mouseBoundary);
        Camera.main.transform.localRotation = Quaternion.Euler(mouseUpDown, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard();
        Mouse();
    }
}
