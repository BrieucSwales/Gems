using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System;

public class Scenes_Manager : EditorWindow {
	
	Color buttonColor = new Color(0.9179105f,0.3425039f,0.3425039f);
	
	string currentScenePath;
	string scenesFolder;
	string scenesFolderPath;
	string scenesPrefix;
	string[] scenes;
	string sceneName;
	GUIStyle _style = new GUIStyle();

	[MenuItem("Tools/Scenes Manager")]
	 
	static void Init () {

		Scenes_Manager window = EditorWindow.GetWindow<Scenes_Manager>();
		window.Show();
	}
	
	void OnGUI () {

		_style.fontSize = 24;

		if (EditorGUIUtility.isProSkin) {
			_style.normal.textColor = Color.white;
		}
		else {
			_style.normal.textColor = Color.black;
		}

		scenesFolderPath = Application.dataPath + "/" + scenesFolder;
		currentScenePath = EditorApplication.currentScene;
		
		if(Directory.Exists(scenesFolderPath)){			
			scenes = Directory.GetFiles(@scenesFolderPath, "*.unity");
		}	
		
		EditorGUILayout.Space();
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.Space();
		GUILayout.Label("Scenes Manager",_style);
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.Space();
		
		EditorGUILayout.LabelField("Scenes Folder Path:", scenesFolderPath);
		EditorGUILayout.LabelField("Current Scene Path:", currentScenePath);
		
		EditorGUILayout.Space();
		
		scenesFolder = EditorGUILayout.TextField("Scenes Folder:",scenesFolder);
		scenesPrefix = EditorGUILayout.TextField("Scenes Prefix:",scenesPrefix);
		
		EditorGUILayout.Space();
		EditorGUILayout.Space();
		EditorGUILayout.Space();
		EditorGUILayout.Space();
		
		EditorGUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		
		foreach (string scene in scenes) {	

			if (!String.IsNullOrEmpty(scenesPrefix)) {
				sceneName = Path.GetFileNameWithoutExtension(scene).Replace(scenesPrefix,"");
			} else {
				sceneName = Path.GetFileNameWithoutExtension(scene);
			}
			
			if (currentScenePath == "Assets/"+scenesFolder+"/" + scenesPrefix + sceneName + ".unity") {				
				GUI.backgroundColor = Color.green;
			} else {				
				GUI.backgroundColor = buttonColor;
			}
			
			if (GUILayout.Button(sceneName,GUILayout.MaxWidth(300),GUILayout.MinHeight(30))) {
				EditorApplication.isPaused = false;
            	EditorApplication.isPlaying = false;            
				EditorApplication.SaveCurrentSceneIfUserWantsTo();
				EditorApplication.OpenScene(scenesFolderPath + "/" + scenesPrefix + sceneName + ".unity");
			}
		}
		
		GUILayout.FlexibleSpace();
		EditorGUILayout.EndHorizontal();
		
		GUI.backgroundColor = Color.white;
		this.Repaint();
	}
	
}
