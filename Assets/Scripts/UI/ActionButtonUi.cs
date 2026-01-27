using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Hex.UI
{

    public class ActionButtonUi : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _textMeshPro;
        [SerializeField] private Button _button;

        public void SetBaseAction(BaseAction baseAction)
        {
            _textMeshPro.text = baseAction.GetActionName().ToUpper();
        }
    }
}