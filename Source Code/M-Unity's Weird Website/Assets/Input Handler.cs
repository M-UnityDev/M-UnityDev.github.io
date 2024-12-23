using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Input
{
    public class InputHandler : MonoBehaviour
    {
        public event Action<InputActionMap> OnMapChanged;
        private static PlayerControl _input;

        public static InputAction Movement => _input.Player.Move;
        public static InputAction Submit => _input.UI.Submit;   
        private void Awake()
        {
            _input = new PlayerControl();
            ToggleActionMap(_input.Player);
        }

        public void ToggleActionMap(InputActionMap map)
        {
            if (map.enabled)
                return;
            
            _input.Disable();
            map.Enable();
            OnMapChanged?.Invoke(map);
        }
    }
}