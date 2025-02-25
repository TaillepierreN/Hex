using UnityEngine;
using TMPro;


namespace Hex.Grid
{
    public class GridDebugObject : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private GridObject _gridObject;
        public void SetGridObject(GridObject gridObject)
        {
            _gridObject = gridObject;
        }

        void Update()
        {
            _text.text = _gridObject.ToString();

        }
    }
}
