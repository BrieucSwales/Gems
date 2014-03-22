using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using System.IO;

public class Model_Importer : EditorWindow {

	enum SOFTWARE {None,Maya,C4D,Blender,Other};
	SOFTWARE _software;

	Vector2 _scrollPos;
	string [] subDirectoryEntries;
	bool includeSubDir;
	int dirID;
	string _modelPath;
	string fileName;
	string destFolder;	
	string _assetPath;
	ModelImporter importedModel;
	UnityEngine.Object modelObj;
	Texture2D modelPreview;	

	GUIStyle _style = new GUIStyle();

	[MenuItem("Tools/Model Importer")]
	static void Init () {
		Model_Importer window = EditorWindow.GetWindow<Model_Importer>();
		window.Show();
	}
	
	void OnGUI () {
		_style.fontSize = 24;		
		if(EditorGUIUtility.isProSkin) _style.normal.textColor = Color.white;
		else _style.normal.textColor = Color.black; 
		
		EditorGUILayout.Space();
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.Space();
		GUILayout.Label("Model Importer",_style);
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.Space();
		
		_scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);

		if (_software==SOFTWARE.None) {
			EditorGUILayout.HelpBox("Choose a software in order to import the model !",MessageType.Info);
		}

		EditorGUILayout.Space();
		
		_software = (SOFTWARE)EditorGUILayout.EnumPopup("Software : ",_software);
		
		EditorGUILayout.Space();

		EditorGUI.BeginDisabledGroup (_software==SOFTWARE.None);

		EditorGUILayout.BeginHorizontal();

		GUILayout.FlexibleSpace();
		GUI.depth = -1;

		if (_software != SOFTWARE.None) {
			GUILayout.Label(GetLogo());
		}

		GUI.depth = 0;
		GUILayout.FlexibleSpace();

		EditorGUILayout.EndHorizontal();

		EditorGUILayout.Space();
		
		EditorGUILayout.BeginHorizontal();

		EditorGUILayout.LabelField("Model path : ", _modelPath);
		
		EditorGUILayout.Space();
		
		if (GUILayout.Button("Choose a file",GUILayout.MaxWidth(200), GUILayout.MinHeight(30))) {
			_modelPath = EditorUtility.OpenFilePanel("Model to import : ","",GetExtension());
		}
		
		fileName = Path.GetFileName(_modelPath);
		
		//TODO : Improve the condition. Without it, errors are thrown...
		// ...filename throws NullReferenceException and subDirectoryEntries is out of range.
		if (fileName != null && dirID <= subDirectoryEntries.Length) {
			_assetPath = subDirectoryEntries[dirID] + "/" + fileName;
		}			

		EditorGUILayout.EndHorizontal();

		EditorGUILayout.Space();
		EditorGUILayout.Space();

		if (includeSubDir) {
			subDirectoryEntries = Directory.GetDirectories("Assets","*",SearchOption.AllDirectories);
		} else {
			subDirectoryEntries = Directory.GetDirectories("Assets");
		}

		for (int i=0; i<subDirectoryEntries.Length;i++) {
			subDirectoryEntries[i] = subDirectoryEntries[i].Replace("\\","/");
		}

		dirID = EditorGUILayout.Popup("Destination Folder : ", dirID, subDirectoryEntries);

		EditorGUILayout.Space();

		EditorGUILayout.BeginHorizontal();

		GUILayout.FlexibleSpace();

		includeSubDir = EditorGUILayout.Toggle("Include all sub-folders ?", includeSubDir);

		EditorGUILayout.EndHorizontal();

		EditorGUILayout.Space();
		EditorGUILayout.Space();

		GUI.backgroundColor = Color.green;

		if (GUILayout.Button("Import Model !",GUILayout.MinHeight(30))) {
			if (!String.IsNullOrEmpty(_modelPath)) {
				Debug.Log("Model name is " + fileName +" !");
				if (!File.Exists(_assetPath)) {
					FileUtil.CopyFileOrDirectory(_modelPath, _assetPath);					
					AssetDatabase.ImportAsset(_assetPath);
					ModifyModel();
					this.ShowNotification(new GUIContent("Model Successfully Imported !"));
				} else {
					this.ShowNotification(new GUIContent("The model already exists ! Choose another filename."));
				}
				
			} else {
				this.ShowNotification(new GUIContent("Choose a model in order to import one !"));
			}
		}

		GUI.backgroundColor = Color.white;

		EditorGUILayout.Space();
		EditorGUILayout.Space();

		if (Resources.LoadAssetAtPath(_assetPath,typeof(UnityEngine.Object))) {
			modelObj = Resources.LoadAssetAtPath(_assetPath,typeof(UnityEngine.Object)) as UnityEngine.Object;
			modelPreview = AssetPreview.GetAssetPreview(modelObj);
		} else {
			modelPreview = null;
		}
		

		EditorGUILayout.BeginHorizontal();

		GUILayout.FlexibleSpace();

		GUILayout.Label(modelPreview);

		GUILayout.FlexibleSpace();

		EditorGUILayout.EndHorizontal();
		
		EditorGUI.EndDisabledGroup();

		EditorGUILayout.Space();
		EditorGUILayout.Space();

		EditorGUILayout.EndScrollView();

		this.Repaint();
	}
	
	string GetExtension(){
		string _softEXT;
		switch(_software){
			case SOFTWARE.Maya:
			_softEXT = "*.mb";
			break;
			case SOFTWARE.C4D:
			_softEXT = "*.c4d";
			break;
			case SOFTWARE.Blender:
			_softEXT = "*.blend";
			break;
			default:
			_softEXT = "";
			break;
		}

		return _softEXT;
	}

	Texture2D GetLogo () {
		Texture2D _softIMG;

		switch(_software){
			case SOFTWARE.Maya:
			_softIMG = Resources.Load("mayaLogo") as Texture2D;
			break;
			case SOFTWARE.C4D:
			_softIMG = Resources.Load("c4dLogo") as Texture2D;
			break;
			case SOFTWARE.Blender:
			_softIMG = Resources.Load("blenderLogo") as Texture2D;
			break;
			default:
			_softIMG = Resources.Load("otherLogo") as Texture2D;
			break;
		}

		return _softIMG;
	}

	void ModifyModel () {
			importedModel = ModelImporter.GetAtPath(_assetPath) as ModelImporter;
			importedModel.globalScale = 1f;	
			importedModel.importMaterials = false;	
			AssetDatabase.ImportAsset(_assetPath);
				
	}
	
}