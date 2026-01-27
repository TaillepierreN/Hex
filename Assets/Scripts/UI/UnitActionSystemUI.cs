using UnityEngine;
using UnityEngine.UI;
using Hex.Units;
using System;

namespace Hex.UI
{
    public class UnitActionSystemUI : MonoBehaviour
    {

        [SerializeField] private Transform _actionButtonPrefab;
        [SerializeField] private Transform _actionButtonContainerTransform;

        void Start()
        {
            UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanger;
            CreateUnitActionButtons();
        }

        private void CreateUnitActionButtons()
        {
            foreach (Transform buttonTransform in _actionButtonContainerTransform)
            {
                Destroy(buttonTransform.gameObject);
            }

            Unit selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();
            foreach (BaseAction baseAction in selectedUnit.GetBaseActionsArray())
            {
                Transform actionButtonTransform =Instantiate(_actionButtonPrefab, _actionButtonContainerTransform);
                actionButtonTransform.GetComponent<ActionButtonUi>().SetBaseAction(baseAction);
            }
        }

        private void UnitActionSystem_OnSelectedUnitChanger(object sender, EventArgs e)
        {
            CreateUnitActionButtons();
        }
    }
}