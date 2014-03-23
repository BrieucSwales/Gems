using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(MapAnalyser))]
public class MapEditor : Editor {

	private Color[] _mapData;

	MapAnalyser myTarget;

	private List<GameObject> _goToDestroy = new List<GameObject>();

	private Color pink = new Color(1.0f, 0.0f, 1.0f);
	private Color lightBlue = new Color(0f, 1f, 1f);
	private Color darkBlue = new Color(0.0f, 0.0f, 1.0f);
	private Color purple = (Color)(new Color32(150, 0, 255, 0));
	private Color yellow = new Color(1f, 1f, 0f);

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

		ClearMap();

		this._mapData = myTarget.mapTex.GetPixels();
		for (int i = 0; i < this._mapData.Length; i++) {
			if (this._mapData[i] == Color.red) {
				GameObject wallClone = Instantiate(myTarget.wall, myTarget.transform.position + new Vector3((i % 16) * 0.64f + 0.32f, Mathf.Floor(i / 16) * 0.64f + 0.32f, 0f), Quaternion.identity) as GameObject;
				wallClone.name = wallClone.name.Replace("(clone)", "");
				wallClone.transform.parent = myTarget.transform;
			} else if (this._mapData[i] == Color.white) {
				GameObject groundClone = Instantiate(myTarget.ground, myTarget.transform.position + new Vector3((i % 16) * 0.64f + 0.32f, Mathf.Floor(i / 16) * 0.64f + 0.32f, 0f), Quaternion.identity) as GameObject;
				groundClone.name = groundClone.name.Replace("(Clone)", "");
				groundClone.transform.parent = myTarget.transform;
			} else if (this._mapData[i] == Color.green) {
				GameObject entranceClone = Instantiate(myTarget.entrance, myTarget.transform.position + new Vector3((i % 16) * 0.64f + 0.32f, Mathf.Floor(i / 16) * 0.64f + 0.32f, 0f), Quaternion.identity) as GameObject;
				entranceClone.name = entranceClone.name.Replace("(Clone)", "");
				entranceClone.transform.parent = myTarget.transform;
			} else if (this._mapData[i] == lightBlue) {
				GameObject exitClone = Instantiate(myTarget.exit, myTarget.transform.position + new Vector3((i % 16) * 0.64f + 0.32f, Mathf.Floor(i / 16) * 0.64f + 0.32f, 0f), Quaternion.identity) as GameObject;
				exitClone.name = exitClone.name.Replace("(Clone)", "");
				exitClone.transform.parent = myTarget.transform;
			} else if (this._mapData[i] == yellow) {
				GameObject rock_1Clone = Instantiate(myTarget.rocks[0], myTarget.transform.position + new Vector3((i % 16) * 0.64f + 0.32f, Mathf.Floor(i / 16) * 0.64f + 0.32f, 0f), Quaternion.identity) as GameObject;
				rock_1Clone.name = rock_1Clone.name.Replace("(Clone)", "");
				rock_1Clone.transform.parent = myTarget.transform;
			} else if (this._mapData[i] == pink) {
				GameObject rock_2Clone = Instantiate(myTarget.rocks[1], myTarget.transform.position + new Vector3((i % 16) * 0.64f + 0.32f, Mathf.Floor(i / 16) * 0.64f + 0.32f, 0f), Quaternion.identity) as GameObject;
				rock_2Clone.name = rock_2Clone.name.Replace("(Clone)", "");
				rock_2Clone.transform.parent = myTarget.transform;
			} else if (this._mapData[i] == purple) {
				GameObject rock_3Clone = Instantiate(myTarget.rocks[2], myTarget.transform.position + new Vector3((i % 16) * 0.64f + 0.32f, Mathf.Floor(i / 16) * 0.64f + 0.32f, 0f), Quaternion.identity) as GameObject;
				rock_3Clone.name = rock_3Clone.name.Replace("(Clone)", "");
				rock_3Clone.transform.parent = myTarget.transform;
			} else if (this._mapData[i] == new Color(1.0f, 100f / 255f, 0.0f)) {
				GameObject rock_4Clone = Instantiate(myTarget.rocks[3], myTarget.transform.position + new Vector3((i % 16) * 0.64f + 0.32f, Mathf.Floor(i / 16) * 0.64f + 0.32f, 0f), Quaternion.identity) as GameObject;
				rock_4Clone.name = rock_4Clone.name.Replace("(Clone)", "");
				rock_4Clone.transform.parent = myTarget.transform;
			} else if (this._mapData[i] == darkBlue) {
				GameObject rock_5Clone = Instantiate(myTarget.rocks[4], myTarget.transform.position + new Vector3((i % 16) * 0.64f + 0.32f, Mathf.Floor(i / 16) * 0.64f + 0.32f, 0f), Quaternion.identity) as GameObject;
				rock_5Clone.name = rock_5Clone.name.Replace("(Clone)", "");
				rock_5Clone.transform.parent = myTarget.transform;
			} else {
				Debug.Log("OTHER");
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