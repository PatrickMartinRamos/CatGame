using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class catController : MonoBehaviour
{
    /// <summary>
    /// Handle Player Inputs
    /// </summary>

    private PlayerInputEditor _playerInputs;
    private catMoveScript _catMoveScript;
    private catActionScript _catActionScript;

    private void Awake()
    {
        _playerInputs = new PlayerInputEditor();
        _catMoveScript = GetComponent<catMoveScript>();
        _catActionScript = GetComponent<catActionScript>();
    }

    #region enable/disable input action
    private void OnEnable()
    {
        _playerInputs.Enable();

        _playerInputs.playerMovements.Walk.performed += WalkInput;
        _playerInputs.playerMovements.Walk.canceled += WalkInput;

        _playerInputs.playerMovements.Interact.performed += interactInput;
        _playerInputs.playerMovements.Interact.canceled += interactInput;
    }
    private void OnDisable()
    {
        _playerInputs.Disable();

        _playerInputs.playerMovements.Walk.performed -= WalkInput;
        _playerInputs.playerMovements.Walk.canceled -= WalkInput;

        _playerInputs.playerMovements.Interact.performed -= interactInput;
        _playerInputs.playerMovements.Interact.canceled -= interactInput;
    }
    #endregion

    public void WalkInput(InputAction.CallbackContext context)
    {
        _catMoveScript.WalkMotion();
    }

    public void interactInput(InputAction.CallbackContext context)
    {
        //button para sa pag interact sa object
        _catActionScript.puddleInteraction();
    }
}
