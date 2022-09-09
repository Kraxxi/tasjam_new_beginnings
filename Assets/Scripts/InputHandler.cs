using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Vector2 _currentInput;
    [SerializeField] private Player player;
    
    
    
    public void HandleMove(InputAction.CallbackContext ctx)
    {
        _currentInput = ctx.ReadValue<Vector2>();
        player.mover.Move(_currentInput);
    }
}
