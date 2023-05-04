using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    private Vector2 _movementInput;

    private PlayerInput _playerInputControl;

    private PlayerInputController _playerInputController;
    
    public int playerIndexNumber;

    [SerializeField]
    private PlayerData _myPlayerData;
    [SerializeField]
    private GameObject _playerBody;
    [SerializeField]
    private GameObject _playerWeapon;

    private void Awake()
    {
        _playerInputControl = GetComponent<PlayerInput>();
        playerIndexNumber = _playerInputControl.playerIndex;
        _playerInputController = new PlayerInputController();
        _playerInputController.Player.Movement.performed += ctx => _movementInput = ctx.ReadValue<Vector2>();
        _playerInputController.Player.Movement.canceled += ctx => _movementInput = Vector2.zero;
        _playerInputController.Enable();
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        _playerInputController.Player.Shoot.performed += context => Shoot(context);
    }

    // Update is called once per frame
    void Update()
    {
        if(_movementInput != Vector2.zero && GameManager.isGameStarted)
            transform.Translate(new Vector3(_movementInput.x, 0, _movementInput.y) * _myPlayerData.playerDataObject.Speed * Time.deltaTime);
        /*
        if (_movementInput != Vector2.zero)
        {
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
                _playerBody.transform.eulerAngles = new Vector3(0, 45, 0);
            }
            else if (_movementInput == new Vector2(-0.707107f, 0.707107f))
            {
                _playerBody.transform.eulerAngles = new Vector3(0, 135, 0);
            }
            else if (_movementInput == new Vector2(0.707107f, 0.707107f))
            {
                _playerBody.transform.eulerAngles = new Vector3(0, 225, 0);
            }
            else if (_movementInput == new Vector2(0.707107f, -0.707107f))
            {
                _playerBody.transform.eulerAngles = new Vector3(0, 315, 0);
            }
        }
        */
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        _playerWeapon.GetComponent<PlayerWeapon>().OnFire();
    }

    
    public void OnMove(InputAction.CallbackContext contex)
    {
        _movementInput.x = contex.ReadValue<Vector2>().x;
        _movementInput.y = contex.ReadValue<Vector2>().y;
        //float test = contex.ReadValue<Vector2>().x;
        //Debug.Log(test);
        //Player face right
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
            Debug.Log("1");
            _playerBody.transform.eulerAngles = new Vector3(0, 45, 0);
        }
        else if (_movementInput == new Vector2(+0.707107f, 0.707107f))
        {
            Debug.Log("2");
            _playerBody.transform.eulerAngles = new Vector3(0, 135, 0);
        }
        else if (_movementInput == new Vector2(0.707107f, 0.707107f))
        {
            Debug.Log("3");
            _playerBody.transform.eulerAngles = new Vector3(0, 225, 0);
        }
        else if (_movementInput == new Vector2(0.707107f, +0.707107f))
        {
            //Debug.Log("4");
            _playerBody.transform.eulerAngles = new Vector3(0, 315, 0);
        }
        //transform.Translate(new Vector3(_movementInput.x, 0, _movementInput.y) * this.GetComponent<PlayerData>().PlayerDataObject.Speed * Time.deltaTime);
    }
    
} 
