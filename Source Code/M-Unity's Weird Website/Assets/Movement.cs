using Game.Input;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _playerModel;
    [SerializeField] private float _angularSpeed;
    [SerializeField] private float _speed;
    private CharacterController _character;
    private Vector2 _inputDirection;
    private Vector3 _direction;
    private Quaternion _currentRotation;
    
    private void Awake() => _character = GetComponent<CharacterController>();

    private void Update()
    {
        ReadMovement();
        MakeRotation();
        _character.Move(_direction * Time.deltaTime);
    }

    private void MakeRotation()
    {
        _currentRotation = GetRotationFrom(_direction);
        var rotation = Quaternion.Lerp(_playerModel.rotation, _currentRotation, _angularSpeed * Time.deltaTime);
        _playerModel.transform.localRotation = rotation;
    }

    private void ReadMovement()
    {
        _inputDirection = InputHandler.Movement.ReadValue<Vector2>();
        _direction.x = _inputDirection.x * _speed;
        _direction.z = _inputDirection.y * _speed;
    }

    private Quaternion GetRotationFrom(Vector3 velocity)
    {
        Vector3 XZVelocity = new Vector3(velocity.x, 0, velocity.z);
        if (XZVelocity.sqrMagnitude > 0)
            return Quaternion.LookRotation(XZVelocity);
        else
            return _playerModel.rotation;
    }
}