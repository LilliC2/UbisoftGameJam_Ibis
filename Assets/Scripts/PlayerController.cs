using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using System;

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
    Vector3 defaultHeadRotation = new Vector3(90, 0, 0);

    float neckXrotation;
    float neckYrotation;

    [SerializeField]
    bool isHoldingTrigger;

    bool resetingRotations;

    [SerializeField]
    Animator anim;

    [SerializeField]
    bool isNeckMoving;

    [SerializeField]
    public GameObject ibisHead;
    [SerializeField]
    public GameObject ibisNeck;

    //picking up trash controls
    public GameObject targetTrash;
    [SerializeField] float ibisHeadTrashRange;
    bool isHoldingTrash = false;
    [SerializeField] GameObject holdTrashPos; //GO inside ibis mouth

    // Start is called before the first frame update
    void Start()
    {
        //defaultHeadRotation = ibisHead.transform.localRotation.eulerAngles;
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

        controls = new PlayerControls();

        groundCheck = transform.Find("GroundCheck").gameObject;
        OnResetHeadRotations();

    }

    // Update is called once per frame
    void Update()
    {
        if(movementNeck != Vector3.zero) isNeckMoving = true;
        else isNeckMoving = false;

        #region Body Movement
        //apply animation
        anim.SetFloat("WalkSpeed", controller.velocity.magnitude);

        //gravity check
        if (!Physics.CheckSphere(groundCheck.transform.position, 0.3f, _GM.groundMask))
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
            neckXrotation -= yAxisRot;
            neckXrotation = Mathf.Clamp(neckXrotation, -105, 35);
            neckYrotation -= xAxisRot;  
            neckYrotation = Mathf.Clamp(neckYrotation, -90, 90);
            //apply rotations
            ibisNeck.transform.localRotation = Quaternion.Euler(neckXrotation, neckYrotation, 0f);

            //print("Neck has moved on X axis by " + (de);
        }
        if(!isNeckMoving)
        {
            OnResetHeadRotations();
        }

        #endregion

        #region Find Target Trash

        if (!isHoldingTrash)
        {

            var trashInRange = Physics.OverlapSphere(ibisHead.transform.position, ibisHeadTrashRange, _GM.pickUpPropsMask);

            //print("trash range = " + trashInRange.Length);

            //get closest trash item
            foreach (var prop in trashInRange)
            {
                if (targetTrash == null) targetTrash = prop.gameObject;
                else if (Vector3.Distance(prop.transform.position, ibisHead.transform.position) < Vector3.Distance(targetTrash.transform.position, ibisHead.transform.position))
                    targetTrash = prop.gameObject;
            }


            // ibisHead.transform.LookAt(targetTrash.transform.position, Vector3.back);


            Vector3 rotationV3 = Vector3.Lerp(new Vector3(defaultHeadRotation.x + 10, defaultHeadRotation.y, defaultHeadRotation.z)
                , new Vector3(defaultHeadRotation.x - 90, defaultHeadRotation.y, defaultHeadRotation.z), 0.5f);

            print(rotationV3);
            ibisHead.transform.localEulerAngles = rotationV3;


        



        }
        else
        {
            ibisHead.transform.eulerAngles = new Vector3(120, ibisHead.transform.eulerAngles.y, ibisHead.transform.eulerAngles.z);
            //if (!isHoldingTrigger) DropHeldItem();
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

    public void PickUpTargetItem(InputAction.CallbackContext context)
    {

        if (targetTrash != null && !isHoldingTrash)
        {
            print("www");
            if (Vector3.Distance(holdTrashPos.transform.position, targetTrash.transform.position) < 0.5f && !isHoldingTrash)
            {
                isHoldingTrash = true;
                print("pick up");
                targetTrash.GetComponent<TrashItem>().PickedUp(holdTrashPos);

            }

        }

        else if (isHoldingTrash)
        {
            DropHeldItem();
        }
        //var value = context.ReadValue<float>();
        //print(value);
        //if (value == 0) isHoldingTrigger = false;
        //else if (value == 1)
        //{
        //    isHoldingTrigger = true;

        //    if (targetTrash != null)
        //    {
        //        if (Vector3.Distance(holdTrashPos.transform.position, targetTrash.transform.position) < ibisHeadTrashRange && !isHoldingTrash)
        //        {
        //            isHoldingTrash = true;
        //            print("pick up");
        //            targetTrash.GetComponent<TrashItem>().PickedUp(holdTrashPos);

        //        }
        //    }
        //}



    }    

    public void DropHeldItem()
    {
        if(targetTrash != null)
        {
            targetTrash.GetComponent<TrashItem>().Dropped();
            targetTrash = null;
           // ExecuteAfterSeconds(1, () => isHoldingTrash = false);
        }
    }

    public void OnResetHeadRotations()
    {
        resetingRotations = true;
        neckXrotation = defaultNeckRotation.x;
        neckYrotation = defaultNeckRotation.y;
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
