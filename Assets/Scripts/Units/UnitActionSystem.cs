using Hex.Tools;
using UnityEngine;
using System;
using Hex.Grid;

namespace Hex.Units
{
    public class UnitActionSystem : MonoBehaviour
    {
        public static UnitActionSystem Instance { get; private set; }
        [SerializeField] private Unit _selectedUnit;
        [SerializeField] private LayerMask _unitLayerMask;
        private bool _isBusy;
        public event EventHandler OnSelectedUnitChanged;


        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There is more than one UnitActionSystem in the scene " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        private void Update()
        {
            if (_isBusy)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                if (TryHandleUnitSelection()) return;

                GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MousePosition.GetPosition());
                if (_selectedUnit.GetMoveAction().IsValidActionGridPosition(mouseGridPosition))
                {
                    SetBusy();
                    _selectedUnit.GetMoveAction().Move(mouseGridPosition, ClearBusy);
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                SetBusy();
                _selectedUnit.GetSpinAction().Spin(ClearBusy);
            }
        }

        private void SetBusy()
        {
            _isBusy = true;
        }

        private void ClearBusy()
        {
            _isBusy = false;

        }
        private bool TryHandleUnitSelection()
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, _unitLayerMask))
            {
                if (hit.transform.TryGetComponent<Unit>(out Unit unit))
                {
                    SetSelectedUnit(unit);
                    return true;
                }
            }
            return false;

        }

        private void SetSelectedUnit(Unit unit)
        {
            _selectedUnit = unit;
            OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
        }

        public Unit GetSelectedUnit()
        {
            return _selectedUnit;
        }
    }
}