using Hex.Grid;
using Hex.Tools;
using UnityEngine;

/// <summary>
/// Represents a unit in the game, which can move and interact with the grid.
/// </summary>
public class Unit : MonoBehaviour
{

    [SerializeField] private Animator _unitAnimator;


    private Vector3 _targetPosition;
    private GridPosition _gridPosition;

    /// <summary>
    /// The speed at which the unit moves.
    /// </summary>
    private float _moveSpeed = 4f;

    /// <summary>
    /// The speed at which the unit rotates.
    /// </summary>
    private float _rotateSpeed = 10f;

    /// <summary>
    /// The distance at which the unit stops moving towards the target position.
    /// </summary>
    private float _stoppingDistance = .1f;



    private void Awake()
    {
        _targetPosition = transform.position;
    }

    private void Start()
    {
        _gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(_gridPosition, this);
    }

    /// <summary>
    /// Updates the unit's position, rotation, and grid position each frame.
    /// </summary>
    private void Update()
    {
        if (Vector3.Distance(transform.position, _targetPosition) > _stoppingDistance)
        {
            Vector3 moveDirection = (_targetPosition - transform.position).normalized;
            transform.position += moveDirection * _moveSpeed * Time.deltaTime;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * _rotateSpeed);
            _unitAnimator.SetBool("isWalking", true);
        }
        else
        {
            _unitAnimator.SetBool("isWalking", false);
        }
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if (newGridPosition != _gridPosition)
        {
            LevelGrid.Instance.UnitMovedGridPosition(_gridPosition, newGridPosition, this);
            _gridPosition = newGridPosition;
        }
    }

    /// <summary>
    /// Moves the unit to the specified target position.
    /// </summary>
    /// <param name="targetPosition">The target position to move the unit to.</param>
    public void Move(Vector3 targetPosition)
    {
        this._targetPosition = targetPosition;
    }
}
