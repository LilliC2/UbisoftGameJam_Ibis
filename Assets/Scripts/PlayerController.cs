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

    float Xrotation;
    float Yrotation;

    bool resetingRotations;

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

        controls = new PlayerControls();

        groundCheck = transform.Find("GroundCheck").gameObject;
        OnResetHeadRotations();

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

        if(!resetingRotations)
        {
            float xAxisRot = movementNeck.x * headSpeed;
            float yAxisRot = movementNeck.y * headSpeed;

            //clamp head rotations
            Xrotation -= yAxisRot;
            Xrotation = Mathf.Clamp(Xrotation, -105, 35);
            Yrotation -= xAxisRot;
            Yrotation = Mathf.Clamp(Yrotation, -90, 90);
            //apply rotations
            ibisNeck.transform.localRotation = Quaternion.Euler(Xrotation, Yrotation, 0f);

        }

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
        resetingRotations = true;
        Xrotation = defaultNeckRotation.x;
        Yrotation = defaultNeckRotation.y;
        ibisNeck.transform.DOLocalRotate(defaultNeckRotation, 0.5f);
        ExecuteAfterSeconds(0.5f,()=> resetingRotations = false);
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
        movementNeck = move;
        

    }
}
