using Hex.Grid;
using Hex.Tools;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    private GridSystem gridSystem;
    void Start()
    {
        gridSystem = new GridSystem(10, 10, 2f);
		Debug.Log(new GridPosition(5,7));

    }

	private void Update()
	{
		Debug.Log(gridSystem.GetGridPosition(MousePosition.GetPosition()));
	}
}
