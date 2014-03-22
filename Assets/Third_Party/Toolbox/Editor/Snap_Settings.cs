using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;
using System.IO;
using System;
using System.Reflection;
using System.Security.Policy;

public class Snap_Settings : EditorWindow {
	
	GUIStyle _style = new GUIStyle();

	[MenuItem("Tools/Snap Settings")]
	
	static void Init () {
		Snap_Settings window = EditorWindow.GetWindow<Snap_Settings>();
		window.Show();
	}
	
	void OnGUI () {

		_style.fontSize = 24;
		_style.richText = true;

		if (EditorGUIUtility.isProSkin) {
			_style.normal.textColor = Color.white;
		} else {
			_style.normal.textColor = Color.black; 
		}
		
		EditorGUILayout.Space();
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.Space();
		GUILayout.Label("Snap Settings",_style);
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.Space();
		EditorGUILayout.Space();
		
		EditorGUILayout.FloatField("Move X",EditorPrefs.GetFloat("MoveSnapX",1f));
		EditorGUILayout.FloatField("Move Y",EditorPrefs.GetFloat("MoveSnapY",1f));
		EditorGUILayout.FloatField("Move Z",EditorPrefs.GetFloat("MoveSnapZ",1f));
		EditorGUILayout.FloatField("Scale",EditorPrefs.GetFloat("ScaleSnap",0.1f));
		EditorGUILayout.FloatField("Rotation",EditorPrefs.GetFloat("RotationSnap",15f));
		
		EditorGUILayout.Space();
		
		GUI.backgroundColor = Color.yellow;
		
		if (GUILayout.Button("Reset",GUILayout.MaxWidth(100),GUILayout.MinHeight(25))) {			
			
		}
		
		GUI.backgroundColor = Color.white;
				
		this.Repaint();
	}
	
}
