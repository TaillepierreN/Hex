using System;
using UnityEngine;

namespace Hex.Units
{
    public class UnitSelectedVisual : MonoBehaviour
    {
        [SerializeField] private Unit _unit;
        [SerializeField] private MeshRenderer _meshRenderer;

        private void Start()
        {
            UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
            UpdateVisual();
        }

        private void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs empty)
        {
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            _meshRenderer.enabled = UnitActionSystem.Instance.GetSelectedUnit() == _unit;
        }
    }
}
