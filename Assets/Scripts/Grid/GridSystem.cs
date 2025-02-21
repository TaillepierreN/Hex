using UnityEngine;
using System;
using System.Numerics;

namespace Hex.Grid
{
	public class GridSystem
	{
		private int _width;
		private int _height;
		private float _cellSize;
		public GridSystem(int width, int height, float cellSize)
		{
			this._width = width;
			this._height = height;
			this._cellSize = cellSize;

			for (int x = 0; x < _width; x++)
			{
				for (int z = 0; z < _height; z++)
				{
					Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z) + UnityEngine.Vector3.right * .2f, Color.white, 1000);
				}
			}
		}

		public UnityEngine.Vector3 GetWorldPosition(int x, int z)
		{
			return new UnityEngine.Vector3(x, 0, z) * _cellSize;
		}

		public GridPosition GetGridPosition(UnityEngine.Vector3 worldPosition)
		{
			return new GridPosition(
				Mathf.RoundToInt(worldPosition.x / _cellSize),
				Mathf.RoundToInt(worldPosition.z / _cellSize)
			);
		}
		
	}
}