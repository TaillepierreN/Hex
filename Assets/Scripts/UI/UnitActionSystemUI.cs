using UnityEngine;
using UnityEngine.UI;
using Hex.Units;

namespace Hex.UI
{
    public class UnitActionSystemUI : MonoBehaviour
    {

        [SerializeField] private Transform _actionButtonPrefab;
        [SerializeField] private Transform _actionButtonContainerTransform;

        void Start()
        {
            CreateUnitActionButtons();
        }

        private void CreateUnitActionButtons()
        {
            Unit selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();
            foreach (BaseAction baseAction in selectedUnit.GetBaseActionsArray())
            {
                Instantiate(_actionButtonPrefab, _actionButtonContainerTransform);
            }
        }
    }
}