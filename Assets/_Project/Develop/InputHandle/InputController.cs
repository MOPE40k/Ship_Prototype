using System;
using _Project.Develop.Gameplay.Seals;
using _Project.Develop.Gameplay.Ship;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Develop.InputHandle
{
    public class InputController : MonoBehaviour
    {
        // [Header("Ship Control Keys:")]
        // [SerializeField] private KeyCode _shipLeft = KeyCode.Q;
        // [SerializeField] private KeyCode _shipRight = KeyCode.W;
        //
        // [Space]
        // [Header("Seals Control Keys:")]
        // [SerializeField] private KeyCode _sealsLeft = KeyCode.A;
        // [SerializeField] private KeyCode _sealsRight = KeyCode.S;

        [Space]
        [Header("References:")]
        [SerializeField] private InputActionReference _shipRotateInputActionReference = default;
        [SerializeField] private InputActionReference _sailsRotateInputActionReference = default;
        [SerializeField] private ShipController _shipController = default;
        [SerializeField] private SailController _sailController = default;

        private void OnEnable()
        {
            _shipRotateInputActionReference.action.Enable();
            _sailsRotateInputActionReference.action.Enable();
        }

        private void OnDisable()
        {
            _shipRotateInputActionReference.action.Disable();
            _sailsRotateInputActionReference.action.Disable();
        }

        private void OnDestroy()
        {
            _shipRotateInputActionReference.action.Dispose();
            _sailsRotateInputActionReference.action.Dispose();
        }
        // // References
        // private InputHandler _inputHandler = null;
        //
        // //Runtime
        // private float _shipControlAxis => _inputHandler.GetAxis(_shipLeft, _shipRight);
        // private float _sealsControlAxis => _inputHandler.GetAxis(_sealsLeft, _sealsRight);

        // private void Awake()
            // => _inputHandler = new InputHandler();

        private void Update()
        {
            _shipController.Rotate(_shipRotateInputActionReference.action.ReadValue<float>());
            _sailController.SealsRotate(_sailsRotateInputActionReference.action.ReadValue<float>());
            // _shipController.Rotate(_shipControlAxis);
            // _sailController.SealsRotate(_sealsControlAxis);
        }
    }
}