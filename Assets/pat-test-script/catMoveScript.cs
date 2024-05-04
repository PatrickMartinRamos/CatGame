using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.InputSystem.InputAction;

public class catMoveScript : MonoBehaviour
{
    //system var
    private PlayerInputEditor _playerInputs;
    private Camera _camera;
    private NavMeshAgent _agent;

    private bool isRotating = false;
    [SerializeField]
    private float rotationSpeed = 3f;

    private void Awake() => _playerInputs = new PlayerInputEditor();
    private void OnEnable() => _playerInputs.Enable();
    private void OnDisable() => _playerInputs.Disable();

    private void Start()
    {
        _playerInputs.playerMovements.Walk.performed += Walk;
        _camera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        rotatePlayer();
    }

    #region walk / rotation 
    void Walk(CallbackContext context)
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            _agent.SetDestination(hit.point);
            _agent.isStopped = true;
            isRotating = true; 
        }
    }

    void rotatePlayer()
    {
        if (isRotating)
        {
            Vector3 direction = _agent.destination - transform.position;
            direction.y = 0f;
            if (direction != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
            }

            // If the angle between current facing direction and desired direction is small enough, stop rotating
            if (Quaternion.Angle(transform.rotation, Quaternion.LookRotation(direction)) < 5f)
            {
                isRotating = false;
                _agent.isStopped = false;
            }
        }
    }
    #endregion
}
