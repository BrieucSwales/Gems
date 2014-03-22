using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Grid : MonoBehaviour {

	[SerializeField]
	private Color _gridColor = Color.red;

	[SerializeField]
	private int _tileSize = 64;

	[SerializeField]
	private int _width = 1024;

	[SerializeField]
	private int _height = 768;
	
	void OnDrawGizmos () {

		Gizmos.color = this._gridColor;

		for (int y = 0; y <= this._height / this._tileSize; y++) {

			Gizmos.DrawLine(new Vector3(0f, y * this._tileSize / 100f, 0f), new Vector3(this._width / 100f, y * this._tileSize / 100f, 0f));

			for (int x = 0; x <= this._width / this._tileSize; x++) {
				
				Gizmos.DrawLine(new Vector3(x * this._tileSize / 100f, 0f, 0f), new Vector3(x * this._tileSize / 100f, this._height / 100f, 0f));
				
			}

		}
	}

}
