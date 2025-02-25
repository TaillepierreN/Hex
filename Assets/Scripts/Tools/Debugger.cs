using Hex.Grid;
using Hex.Tools;
using UnityEngine;

public class Debugger : MonoBehaviour
{
	public int gridX = 10;
	public int gridY = 10;
	[SerializeField]private Transform gridDebugObjectPrefab;
    private GridSystem gridSystem;
    void Start()
    {
        gridSystem = new GridSystem(gridX, gridY, 2f);
		gridSystem.CreateDebugObjects(gridDebugObjectPrefab);

		Debug.Log(new GridPosition(5,7));
    }

	private void Update()
	{
		Debug.Log(gridSystem.GetGridPosition(MousePosition.GetPosition()));
	}
}
