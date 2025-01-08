using UnityEngine;
using System;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    public event EventHandler OnFlap;
    public event EventHandler OnInteract;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        Instance = this;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();

        playerInputActions.Player.Flap.performed += GameInput_flapPerformed;
        playerInputActions.Player.Interact.performed += GameInput_interactPerformed;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the Interact action
        playerInputActions.Player.Interact.performed -= GameInput_flapPerformed;
        playerInputActions.Player.Interact.performed -= GameInput_interactPerformed;

        // Disable the Player action map
        playerInputActions.Dispose();
    }

    private void GameInput_flapPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnFlap?.Invoke(this, EventArgs.Empty);
    }

    private void GameInput_interactPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteract?.Invoke(this, EventArgs.Empty);
    }
}
