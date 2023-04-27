using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 _movementInput;

    private PlayerInput _playerInputControl;

    public int playerIndexNumber;

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
    }

    public void OnMove(InputAction.CallbackContext contex) => _movementInput = contex.ReadValue<Vector2>();
}
