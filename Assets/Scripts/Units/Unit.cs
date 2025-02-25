using Hex.Grid;
using Hex.Tools;
using UnityEngine;

namespace Hex.Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Animator _unitAnimator;

        private Vector3 _targetPosition;
        private GridPosition _gridPosition;
        private float _moveSpeed = 4f;
        private float _rotateSpeed = 10f;
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
            if(newGridPosition != _gridPosition)
            {
                LevelGrid.Instance.UnitMovedGridPosition(_gridPosition, newGridPosition, this);
                _gridPosition = newGridPosition;
            }

        }
        public void Move(Vector3 targetPosition)
        {
            this._targetPosition = targetPosition;
        }

    }
}