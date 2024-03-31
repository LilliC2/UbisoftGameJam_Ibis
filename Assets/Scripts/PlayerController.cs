using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PlayerController : GameBehaviour
{
    public int playerNum; //are they player 1 - 4?

    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float headSpeed;

    PlayerControls controls; 
    CharacterController controller;
    CharacterController controllerHead;
    GameObject groundCheck;
    Vector3 movementBody;
    Vector3 directionBody;

    //ibis head controlls
    Vector3 movementNeck;
    Vector3 defaultNeckRotation = new Vector3(-71.566f,0,0); 

    [SerializeField] float headRadius;

    [SerializeField]
    Animator anim;

    [SerializeField]
    public GameObject ibisHead;
    [SerializeField]
    public GameObject ibisNeck;

    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        //anim.enabled = false;
        //ExecuteAfterFrames(5, () => anim.enabled = true);
        controls = new PlayerControls();

        groundCheck = transform.Find("GroundCheck").gameObject;
    }

    // Update is called once per frame
    void Update()
    {


        #region Body Movement
        //apply animation
        anim.SetFloat("WalkSpeed", controller.velocity.magnitude);

        //gravity check
        if (!Physics.CheckSphere(groundCheck.transform.position, 1, _GM.groundMask))
        {
            movementBody += Physics.gravity;

        }

        //move body
        controller.Move(movementBody * movementSpeed * Time.deltaTime);
        if (transform.localEulerAngles != Vector3.zero) directionBody = transform.localEulerAngles;
        if (controller.velocity.magnitude < 1) transform.localEulerAngles = directionBody;
        #endregion

    }

    private void LateUpdate()
    {
        #region Neck/Head Movement

        //neck movement
        /*
         * up/down on joystick moves head on rotation X axis
         * 
         * left/right on joystick moves head on rotation y axis
        */
        print(movementNeck);
        ibisNeck.transform.Rotate(movementNeck * headSpeed, Space.Self);

        //Mathf.Clamp(ibisNeck.transform.localEulerAngles.x, -105f, 35f);

        //head movement

        /*if head is head object that can be picked up, (use ovrelap sphere find closests)
         * then look at it
         */

        #endregion
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

    public void OnResetHeadRotations()
    {
        ibisNeck.transform.DOLocalRotate(defaultNeckRotation, 0.5f);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        movementBody = new Vector3(move.x, 0, move.y);
        transform.rotation = Quaternion.LookRotation(movementBody);

    }

    public void OnMoveHead(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        movementNeck = new Vector3(move.y,move.x, 0);
        

    }
}
