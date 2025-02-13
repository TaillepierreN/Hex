using Hex.Tools;
using UnityEngine;
using System;

namespace Hex.Units
{
    public class UnitActionSystem : MonoBehaviour
    {
        public static UnitActionSystem Instance { get; private set;}
        [SerializeField] private Unit _selectedUnit;
        [SerializeField] private LayerMask _unitLayerMask;

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
            if (Input.GetMouseButtonDown(0))
            {
                if (TryHandleUnitSelection()) return;
                _selectedUnit.Move(MousePosition.GetPosition());
            }
        }


        private bool TryHandleUnitSelection()
        {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, _unitLayerMask))
                {
                    if(hit.transform.TryGetComponent<Unit>(out Unit unit))
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