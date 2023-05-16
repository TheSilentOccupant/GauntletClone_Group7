using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Vector2 _movementInput;

    public PlayerInput _playerInputControl;

    public PlayerInputController _playerInputController;

    public InputActionAsset controlAsset;

    private Vector2 _previousInput;
    public int playerIndexNumber;

    private float _distance_To_Wall_Front = 2f;

    [SerializeField]
    private PlayerData _myPlayerData;
    [SerializeField]
    private GameObject _playerBody;
    [SerializeField]
    private GameObject _playerWeapon;
    [SerializeField]
    private GameObject _playerInventory;
    [SerializeField]
    private PlayerInventory _playerInventoryData;

    private void Awake()
    {
        playerIndexNumber = _playerInputControl.playerIndex;

        //_playerInputController = new PlayerInputController();

        _playerInputControl.actions.FindAction("Shoot").performed += context => Shoot(context);
        _playerInputControl.actions.FindAction("Movement").performed += ctx => _movementInput = ctx.ReadValue<Vector2>();
        _playerInputControl.actions.FindAction("Movement").performed += ctx => OnMove(ctx);
        _playerInputControl.actions.FindAction("Inventory").performed += context => DisplayInventory();
        /*
        _playerInputController.Enable();
        _playerInputController.Player.Movement.performed += ctx => _movementInput = ctx.ReadValue<Vector2>();
        _playerInputController.Player.Movement.performed += ctx => OnMove(ctx);
        _playerInputController.Player.Shoot.performed += context => Shoot(context);
        _playerInputController.Player.Inventory.performed += context => DisplayInventory();
        */

    }

    private void Start()
    {
        
        DontDestroyOnLoad(this.gameObject);
        GameOn.GameStartedEvent += OnGameStartSubscriber;

        /*
        _playerInputController.Player.Shoot.Disable();
        _playerInputController.Player.Inventory.Disable();
        */
        _playerInputControl.actions.FindAction("Shoot").Disable();
        _playerInputControl.actions.FindAction("Inventory").Disable();

    }

    private void OnGameStartSubscriber()
    {

        _playerInputControl.actions.FindAction("Shoot").Enable();
        _playerInputControl.actions.FindAction("Inventory").Enable();
        
        /*
        _playerInputController.Player.Shoot.Enable();
        _playerInputController.Player.Inventory.Enable();
        */
    }
    public void OnMenuClose()
    {

        _playerInputControl.actions.FindAction("Shoot").Enable();
        _playerInputControl.actions.FindAction("Movement").Enable();
        
        /*
        _playerInputController.Player.Shoot.Enable();
        _playerInputController.Player.Inventory.Enable();
        */
    }

    public void OnMenuOpen()
    {

        _playerInputControl.actions.FindAction("Shoot").Disable();
        _playerInputControl.actions.FindAction("Movement").Disable();
        
        /*
        _playerInputController.Player.Shoot.Enable();
        _playerInputController.Player.Inventory.Enable();
        */
    }

    public void OnPlayerDeath()
    {
        _playerInputControl.actions.Disable();
        this.gameObject.layer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToWall();
        if (_movementInput != Vector2.zero && GameManager.isGameStarted)
        {
            transform.Translate(new Vector3(_movementInput.x, 0, _movementInput.y) * _myPlayerData.playerDataObject.Speed * Time.deltaTime);
        }
        if ((_distance_To_Wall_Front <= .6 && _movementInput.y < 0) || (_distance_To_Wall_Front <= .6 && _movementInput.y > 0))
            _movementInput.y = 0;
        if ((_distance_To_Wall_Front <= .6 && _movementInput.x > 0) || (_distance_To_Wall_Front <= .6 && _movementInput.x < 0))
            _movementInput.x = 0;
    }

    public void DisplayInventory()
    {
        _playerInventoryData.OnDisplayInventory();
    }

    private void DistanceToWall()
    {
        RaycastHit hit;
        Ray front_Ray = new Ray(transform.position, -_playerBody.transform.forward);

        if (Physics.Raycast(front_Ray, out hit))
        {
            _distance_To_Wall_Front = hit.distance;
            if (hit.distance <= .6f)
            {
                Debug.Log(hit.collider.gameObject);
                _playerInventoryData.OnInteractionBehavior(hit.collider.gameObject);
            }
        }
        else
        {
            _distance_To_Wall_Front = 3;
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        _playerWeapon.GetComponent<PlayerWeapon>().OnFire();
    }

    
    public void OnMove(InputAction.CallbackContext contex)
    {
            /*
            _movementInput.x = contex.ReadValue<Vector2>().x;
            _movementInput.y = contex.ReadValue<Vector2>().y;
            */
            if (_movementInput == new Vector2(-1, 0))
            {
                _playerBody.transform.eulerAngles = new Vector3(0, 90, 0);
            }
            //Player face left
            else if (_movementInput == new Vector2(1, 0))
            {
                _playerBody.transform.eulerAngles = new Vector3(0, 270, 0);
            }
            //Player face up
            else if (_movementInput == new Vector2(0, 1))
            {
                _playerBody.transform.eulerAngles = new Vector3(0, 180, 0);
            }
            //Player face down
            else if (_movementInput == new Vector2(0, -1))
            {
                _playerBody.transform.eulerAngles = new Vector3(0, 0, 0);
            }

            else if (_movementInput == new Vector2(-0.707107f, -0.707107f))
            {
                //Debug.Log("1");
                _playerBody.transform.eulerAngles = new Vector3(0, 45, 0);
            }
            else if (_movementInput == new Vector2(-0.707107f, 0.707107f))
            {
                //Debug.Log("2");
                _playerBody.transform.eulerAngles = new Vector3(0, 135, 0);
            }
            else if (_movementInput == new Vector2(0.707107f, 0.707107f))
            {
                //Debug.Log("3");
                _playerBody.transform.eulerAngles = new Vector3(0, 225, 0);
            }
            else if (_movementInput == new Vector2(0.707107f, -0.707107f))
            {
                //Debug.Log("4");
                _playerBody.transform.eulerAngles = new Vector3(0, 315, 0);
            }
        //transform.Translate(new Vector3(_movementInput.x, 0, _movementInput.y) * this.GetComponent<PlayerData>().PlayerDataObject.Speed * Time.deltaTime);
    }
    
} 
