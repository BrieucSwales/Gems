using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(MapAnalyser))]
public class MapEditor : Editor {

	private Color[] _mapData;

	MapAnalyser myTarget;

	private List<GameObject> _goToDestroy = new List<GameObject>();

	public override void OnInspectorGUI () {

		myTarget = (MapAnalyser) target;

		DrawDefaultInspector();

		EditorGUILayout.Separator();

		GUI.color = Color.green;

		EditorGUILayout.BeginHorizontal();

		GUILayout.FlexibleSpace();
		
		if (GUILayout.Button("Generate Map", GUILayout.Width(150f), GUILayout.Height(30f))) {
			GenerateMap();
		}
		
		GUILayout.FlexibleSpace();

		EditorGUILayout.EndHorizontal();

		GUI.color = Color.red;

		EditorGUILayout.Separator();
		
		EditorGUILayout.BeginHorizontal();
		
		GUILayout.FlexibleSpace();
		
		if (GUILayout.Button("Clear Map", GUILayout.Width(150f), GUILayout.Height(30f))) {
			ClearMap();
		}
		
		GUILayout.FlexibleSpace();
		
		EditorGUILayout.EndHorizontal();
	}

	void GenerateMap () {
		this._mapData = myTarget.mapTex.GetPixels();
		for (int i = 0; i < this._mapData.Length; i++) {
			if (this._mapData[i] == Color.red) {
				GameObject wallClone = Instantiate(myTarget.wall, new Vector3((i % 16) * 0.64f + 0.32f, Mathf.Floor(i / 16) * 0.64f + 0.32f, 0f), Quaternion.identity) as GameObject;
				wallClone.name = wallClone.name.Replace("(clone)", "");
				wallClone.transform.parent = myTarget.transform;
			} else if (this._mapData[i] == Color.white) {
				GameObject wallClone = Instantiate(myTarget.ground, new Vector3((i % 16) * 0.64f + 0.32f, Mathf.Floor(i / 16) * 0.64f + 0.32f, 0f), Quaternion.identity) as GameObject;
				wallClone.name = wallClone.name.Replace("(Clone)", "");
				wallClone.transform.parent = myTarget.transform;
			}
		}
	}

	void ClearMap () {
		foreach(Transform child in myTarget.transform) {
			this._goToDestroy.Add(child.gameObject);
		}		
		this._goToDestroy.ForEach(elem => DestroyImmediate(elem));
	}
}