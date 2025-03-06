using Hex.Grid;
using Hex.Tools;
using UnityEngine;

/// <summary>
/// Represents a unit in the game, which can move and interact with the grid.
/// </summary>
public class Unit : MonoBehaviour
{
    private GridPosition _gridPosition;
    private MoveAction _moveAction;

    void Awake()
    {
        _moveAction = GetComponent<MoveAction>();
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

        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if (newGridPosition != _gridPosition)
        {
            LevelGrid.Instance.UnitMovedGridPosition(_gridPosition, newGridPosition, this);
            _gridPosition = newGridPosition;
        }
    }

    public MoveAction GetMoveAction()
    {
        return _moveAction;
    }

    public GridPosition GetGridPosition()
    {
        return _gridPosition;
    }
}
