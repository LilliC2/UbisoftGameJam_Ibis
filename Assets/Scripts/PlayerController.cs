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
    CharacterController controllerBody;
    CharacterController controllerHead;
    GameObject groundCheck;
    Vector3 movementBody;
    Vector3 directionBody;
    Vector3 movementHead;
    Vector3 directionHead;

    [SerializeField] float headRadius;

    public GameObject ibisHead;
    public GameObject ibisNeck;

    // Start is called before the first frame update
    void Start()
    {
        ibisHead = transform.Find("Head").gameObject;
        ibisNeck = transform.Find("Neck").gameObject;

        controllerBody = GetComponent<CharacterController>();
        controllerHead = ibisHead.GetComponent<CharacterController>();

        controls = new PlayerControls();

        groundCheck = transform.Find("GroundCheck").gameObject;
    }

    // Update is called once per frame
    void Update()
    {


        //move ibis head

        //controllerHead.Move(movementHead * movementSpeed * Time.deltaTime);
        //if (Vector3.Distance(ibisNeck.transform.position, ibisHead.transform.position) > headRadius)
        //{
        //    Vector3 r = ibisHead.transform.localPosition.normalized * headRadius;
        //    ibisHead.transform.localPosition = new Vector3(0, r.y, r.z);

        //}

        //gravity check
        if (!Physics.CheckSphere(groundCheck.transform.position, 1, _GM.groundMask))
        {
            movementBody += Physics.gravity;

        }

        //move body
        controllerBody.Move(movementBody * movementSpeed * Time.deltaTime);
        if (transform.localEulerAngles != Vector3.zero) directionBody = transform.localEulerAngles;
        if (controllerBody.velocity.magnitude < 1) transform.localEulerAngles = directionBody;


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
        movementBody = new Vector3(move.x, 0, move.y);
        transform.rotation = Quaternion.LookRotation(movementBody);

    }

    public void OnMoveHead(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();

        movementHead = move;

        

        //if(ibisHead.transform.forward.z > 0f) movementHead = new Vector3(0, move.y, move.x);
        //if(ibisHead.transform.forward.x > 0f) movementHead = new Vector3(move.x, move.y, 0);

        print(ibisHead.transform.forward);

        //ibisHead.transform.rotation = Quaternion.LookRotation(movementHead);
    }
}
