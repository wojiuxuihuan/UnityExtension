using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;

public class MyWindow : EditorWindow {
	string myString ="Test";
	bool groupEnabled;
	bool myBool=true;
	float myFloat = 1.23f;
	public int selGridInt = 0;
	public string[] selStrings = new string[] {"radio1", "radio2", "radio3"};
	float size = 15, temp=15;
	public GUISkin CustomSkin;
	Vector2 scrollPos; 

	//add menu item to window menu
	[MenuItem("Window/GUILayout.Label")]
	public static void ShowWindow(){
		//show existing window instance if exists one, create new if doesn't exists.
		EditorWindow.GetWindow(typeof(MyWindow));
	}

	[MenuItem("Window/Screenshot")]
	public static void Capture(){
		Application.CaptureScreenshot("Screenshot1.png");
		Debug.Log ("ScreenShot!");
	}

	[MenuItem("Window/EditorGUILayout.Label")]
	public static void ShowEditorWindow(){
		//show existing window instance if exists one, create new if doesn't exists.
		MyWindow editorwindow = (MyWindow)EditorWindow.GetWindowWithRect(typeof(MyWindow), new Rect(50,50,400,900),false,"GUILayout.Label");
	}
		
	void OnGUI(){
		CustomSkin = Resources.Load<GUISkin> ("CustomSkin") as GUISkin;
		if (CustomSkin != null) {
			Debug.Log ("Not null" + CustomSkin.ToString ());
		}
		GUI.skin = CustomSkin;
		GUILayout.Button ("Testing Button Custom Skin");
		GUI.skin = null;
		GUILayout.Button ("Default Button");
		GUIStyle a = (new GUIStyle ("Label")); 
		a.CalcMinMaxWidth (new GUIContent ("Player "), out size, out temp);
		//a.fixedHeight = 250;
		a.alignment = TextAnchor.MiddleCenter;
		GUILayout.Label ("Test");
		GUILayout.Box ("BOX",a);
		OnGUILayoutLabel ();
		//OnEditorGUILayoutLabel ();
		GUILayout.BeginVertical("Box");
		selGridInt = GUILayout.SelectionGrid(selGridInt, selStrings, 2);
		if (GUILayout.Button("Start"))
			Debug.Log("You chose " + selStrings[selGridInt]);

		GUILayout.EndVertical();
	}

	void OnGUILayoutLabel(){

		GUIStyle g = new GUIStyle (EditorStyles.textArea);
		//GUISkin gg = new GUISkin ();
		//GUI.skin.settings.selectionColor = Color.red;
		//
		GUI.skin.textArea.active.background = Texture2D.blackTexture;
		GUILayout.TextArea ("TESTING", g);
		GUILayout.Box ("BOX");

		//GUILayout.TextField(
		//EditorGUI.TextField(
		GUILayout.BeginHorizontal();
		GUIStyle gg = new GUIStyle(EditorStyles.whiteLabel);
		GUILayout.Label ("Label FUCK",gg,GUILayout.Width(Screen.width/4));
		string firstname = GUILayout.TextField ("Haha");
		GUILayout.EndHorizontal ();

		EditorGUILayout.TextField("TEXTFIELD", "Text in field", GUILayout.Height(25));
		GUILayout.BeginVertical ("Helpbox");
		GUILayout.BeginVertical ("Box");
		GUILayout.Label ("BoldLabel", EditorStyles.boldLabel);
		GUILayout.Label ("CenteredGreyMiniLabel", EditorStyles.centeredGreyMiniLabel);
		GUILayout.Label ("ColorField", EditorStyles.colorField);
		GUILayout.Label ("Foldout", EditorStyles.foldout);
		GUILayout.Label ("Foldoutpredrop", EditorStyles.foldoutPreDrop);
		GUILayout.Label ("Label", EditorStyles.label);
		GUILayout.Label ("Helpbox", EditorStyles.helpBox);
		GUILayout.Label ("inspectordefaultmargins", EditorStyles.inspectorDefaultMargins);
		GUILayout.Label ("Fullwidthmargins", EditorStyles.inspectorFullWidthMargins);
		GUILayout.Label ("Largelabel", EditorStyles.largeLabel);
		GUILayout.Label ("Layermaskfield", EditorStyles.layerMaskField);
		GUILayout.Label ("minibuttonleft", EditorStyles.miniButtonLeft);
		GUILayout.Label ("miniboldlabel", EditorStyles.miniBoldLabel);
		GUILayout.Label ("minibutton", EditorStyles.miniButton);
		GUILayout.Label ("minibuttonmid", EditorStyles.miniButtonMid);
		GUILayout.Label ("minibuttonright", EditorStyles.miniButtonRight);
		GUILayout.Label ("minilabel", EditorStyles.miniLabel);
		GUILayout.Label ("minitextfield", EditorStyles.miniTextField);
		GUILayout.Label ("numberfield", EditorStyles.numberField);
		GUILayout.Label ("ObjectField", EditorStyles.objectField);
		GUILayout.Label ("ObjectMiniThumb", EditorStyles.objectFieldMiniThumb);
		GUILayout.Label ("ObjectFieldThumb", EditorStyles.objectFieldThumb);
		GUILayout.Label ("Radio", EditorStyles.radioButton);
		GUILayout.Label ("TextArea", EditorStyles.textArea);
		GUILayout.Label ("TextField", EditorStyles.textField);
		GUILayout.Label ("Toggle", EditorStyles.toggle);
		GUILayout.Label ("ToggleGroup", EditorStyles.toggleGroup);
		GUILayout.Label ("PopUP", EditorStyles.popup);
		GUILayout.Label ("Toolbar", EditorStyles.toolbar);
		GUILayout.Label ("ToolbarButton", EditorStyles.toolbarButton);
		GUILayout.Label ("ToolbarDrop Down", EditorStyles.toolbarDropDown);
		GUILayout.Label ("ToolbarPopUp", EditorStyles.toolbarPopup);
		GUILayout.Label ("ToolbarTextField", EditorStyles.toolbarTextField);
		GUILayout.Label ("WhiteBoldLabel", EditorStyles.whiteBoldLabel);
		GUILayout.Label ("WhiteLabel", EditorStyles.whiteLabel);
		GUILayout.Label ("WhiteLargeLabel", EditorStyles.whiteLargeLabel);
		GUILayout.Label ("WhiteMiniLabel", EditorStyles.whiteMiniLabel);
		GUILayout.Label ("WordWrappedLabel", EditorStyles.wordWrappedLabel);
		//GUILayout.Button ("Test", EditorStyles.miniButtonLeft, true);
		if (GUILayout.Button("Button Text",EditorStyles.miniButtonLeft)){
			Debug.Log ("Yay");
		}
		GUILayout.EndVertical ();
		GUILayout.EndVertical ();
		Drawing.DrawCircle (new Vector2 (200f, 200f), 100, Color.black, 5,true, 36, 1.0f);
		Drawing.DrawLine(Vector2.zero, new Vector2(400,400), Color.red, 5, true, 1.0f);
		Drawing.DrawBezierLine (Vector2.zero, new Vector2 (400, 150), new Vector2 (600, 800), new Vector2 (200, 500), Color.blue, 10, true, 24, 2.0f);
	}

	void OnEditorGUILayoutLabel(){
		//We store for further purpose
		myString = EditorGUILayout.TextField ("Text Field", myString);
		EditorGUILayout.LabelField ("Editor Label", myString);
		groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional", groupEnabled);
		myBool = EditorGUILayout.Toggle ("Toggle", myBool);
		myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
		EditorGUILayout.EndToggleGroup ();
		EditorGUI.Toggle (new Rect(), true);
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField ("Editor Label", myString);
		EditorGUILayout.LabelField ("Editor Label", myString);
		EditorGUILayout.LabelField ("Editor Label", myString);
		EditorGUILayout.EndHorizontal ();
	}

}
