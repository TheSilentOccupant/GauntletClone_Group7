using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 _movementInput;

    private PlayerInput _playerInputControl;

    public int playerIndexNumber;

    [SerializeField]
    private GameObject _playerBody;

    private void Awake()
    {
        _playerInputControl = GetComponent<PlayerInput>();
        playerIndexNumber = _playerInputControl.playerIndex;
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(_movementInput.x, 0, _movementInput.y) * this.GetComponent<PlayerData>().me.Speed * Time.deltaTime);
        Debug.Log(_movementInput);
    }

    public void OnMove(InputAction.CallbackContext contex)
    {
        _movementInput = contex.ReadValue<Vector2>();
        //Player face right
        if (_movementInput == new Vector2(-1, 0))
        {
            Debug.Log("11");
            _playerBody.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        //Player face left
        if (_movementInput == new Vector2(1, 0))
        {
            Debug.Log("12");
            _playerBody.transform.eulerAngles = new Vector3(0, 270, 0);
        }
        //Player face up
        if (_movementInput == new Vector2(0, 1))
        {
            Debug.Log("13");
            _playerBody.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        //Player face down
        if (_movementInput == new Vector2(0, -1))
        {
            Debug.Log("14");
            _playerBody.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (_movementInput == new Vector2(0.7f, 0.7f))
        {
            Debug.Log("1");
            _playerBody.transform.eulerAngles = new Vector3(0, 45, 0);
        }
        if (_movementInput == new Vector2(0.7f, -0.7f))
        {
            Debug.Log("2");
            _playerBody.transform.eulerAngles = new Vector3(0, 135, 0);
        }
        if (_movementInput == new Vector2(-0.7f, 0.7f))
        {
            Debug.Log("3");
            _playerBody.transform.eulerAngles = new Vector3(0, 225, 0);
        }
        if (_movementInput == new Vector2(-0.7f, -0.7f))
        {
            Debug.Log("4");
            _playerBody.transform.eulerAngles = new Vector3(0, 315, 0);
        }
    }
} 
