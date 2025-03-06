using Hex.Grid;
using Hex.Tools;
using UnityEngine;

public class Debugger : MonoBehaviour
{

	[SerializeField] private Unit unit;
    void Start()
    {

    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			unit.GetMoveAction().GetValidGridPositionList();
		}
	}
}
