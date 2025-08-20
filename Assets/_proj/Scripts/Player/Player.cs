using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Other player elements")]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerVisual playerVisual;

    [Header("Player movement settings")]
    [SerializeField] private float defaultSpeed = 5f;
   
    private float _actualSpeed;

    private InputAction _moveAction;

    private void Awake()
    {
        _moveAction = playerInput.actions["Move"];
        _actualSpeed = defaultSpeed;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 direction = _moveAction.ReadValue<Vector2>();
        if (direction == Vector2.zero)
        {
            playerVisual.StopMovement();
            return;
        }

        float speed = _actualSpeed * Time.deltaTime;

        Vector3 newpos = new(transform.position.x + direction.x * speed, 
            transform.position.y + direction.y * speed, transform.position.z);
        transform.position = newpos;

        playerVisual.AnimateMovement(direction.x);
    }
}
