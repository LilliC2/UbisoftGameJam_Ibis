using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : GameBehaviour
{
    public int playerNum; //are they player 1 - 4?

    [SerializeField]
    float movementSpeed;

    PlayerControls controls; 
    CharacterController controller;
    GameObject groundCheck;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        controls = new PlayerControls();

        if (controls == null) print("it null");

        groundCheck = transform.Find("GroundCheck").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //gravity check
        if (!Physics.CheckSphere(groundCheck.transform.position, 1, _GM.groundMask))
        {
            movement += Physics.gravity;

        }

        controller.Move(movement * movementSpeed * Time.deltaTime);

    }

    private void OnEnable()
    {
        //transform.position = _GM.spawnPoints[playerNum].transform.position;

       controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        movement = new Vector3(move.x, 0, move.y);
        transform.rotation = Quaternion.LookRotation(movement);

    }
}
