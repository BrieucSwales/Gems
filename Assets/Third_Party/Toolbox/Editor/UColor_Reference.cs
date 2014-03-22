using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System;

public class UColor_Reference : EditorWindow {
	
	enum SCRIPT_LNG {UnityScript,CSharp,Boo};
	SCRIPT_LNG _scriptLNG;

	Color referenceColor;
	Vector3 rgbValues;
	string formatedColor;
	GUIStyle _style = new GUIStyle();

	[MenuItem("Tools/Color Reference")]
	
	static void Init(){

		UColor_Reference window = EditorWindow.GetWindow<UColor_Reference>();
		window.Show();

	}
	
	void OnGUI () {

		_style.fontSize = 24;
		_style.richText = true;
		if(EditorGUIUtility.isProSkin) _style.normal.textColor = Color.white;
		else _style.normal.textColor = Color.black; 
		
		EditorGUILayout.Space();
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.Space();
		GUILayout.Label("Unity Colors Reference",_style);
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.Space();
		EditorGUILayout.Space();
		
		referenceColor = EditorGUILayout.ColorField("Pick a color", referenceColor,GUILayout.MaxWidth(500));	
		
		EditorGUILayout.Space();
		
		rgbValues = new Vector3(referenceColor.r,referenceColor.g,referenceColor.b);
		rgbValues = EditorGUILayout.Vector3Field("RGB Values:", rgbValues,GUILayout.MaxWidth(500));

		if (_scriptLNG==SCRIPT_LNG.UnityScript) {
			formatedColor = "Color(" + rgbValues.x + "," + rgbValues.y + "," + rgbValues.z + ");";
		}
		else if (_scriptLNG==SCRIPT_LNG.CSharp) {
			formatedColor = "new Color(" + rgbValues.x + "f," + rgbValues.y + "f," + rgbValues.z + "f);";
		}
		else if (_scriptLNG==SCRIPT_LNG.Boo) {
			formatedColor = "Color(" + rgbValues.x + "F," + rgbValues.y + "F," + rgbValues.z + "F);";
		}
		
		EditorGUILayout.Space();

		_scriptLNG = (SCRIPT_LNG)EditorGUILayout.EnumPopup("Scripting Language : ",_scriptLNG);

		EditorGUILayout.Space();
		
		EditorGUILayout.TextField("Ready to use: ", formatedColor);
				
		this.Repaint();
	}
	
}
