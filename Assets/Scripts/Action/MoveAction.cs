using System.Collections.Generic;
using Hex.Grid;
using UnityEngine;
using System;

public class MoveAction : BaseAction
{
    [SerializeField] private Animator _unitAnimator;
    [SerializeField] private int maxMoveDistance = 5;
    private Vector3 _targetPosition;

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


    protected override void Awake()
    {
        base.Awake();
        _targetPosition = transform.position;
    }
    void Update()
    {
        if (!_isActive)
            return;

        Vector3 moveDirection = (_targetPosition - transform.position).normalized;
        if (Vector3.Distance(transform.position, _targetPosition) > _stoppingDistance)
        {
            transform.position += moveDirection * _moveSpeed * Time.deltaTime;
            _unitAnimator.SetBool("isWalking", true);
        }
        else
        {
            _unitAnimator.SetBool("isWalking", false);
            _isActive = false;
            onActionComplete();
        }
        transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * _rotateSpeed);
    }

    /// <summary>
    /// Moves the unit to the specified target position.
    /// </summary>
    /// <param name="targetPosition">The target position to move the unit to.</param>
    public void Move(GridPosition gridPosition, Action onActionComplete)
    {
        this.onActionComplete = onActionComplete;
        this._targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
        _isActive = true;
    }

    public bool IsValidActionGridPosition(GridPosition gridPosition)
    {
        List<GridPosition> valideGridPositionList = GetValidGridPositionList();
        return valideGridPositionList.Contains(gridPosition);
    }
    public List<GridPosition> GetValidGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();
        GridPosition unitGridPosition = _unit.GetGridPosition();

        for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
        {
            for (int z = -maxMoveDistance; z <= maxMoveDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x, z);
                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;
                if (!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                    continue;
                if (unitGridPosition == testGridPosition)
                    continue;
                if (LevelGrid.Instance.HasAnyUnitOnGridPosition(testGridPosition))
                    continue;
                validGridPositionList.Add(testGridPosition);
            }
        }
        return validGridPositionList;
    }

	public override string GetActionName()
	{
		return "Move";
	}
}
