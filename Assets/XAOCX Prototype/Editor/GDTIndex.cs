using UnityEditor;
using UnityEngine;

public class GDTIndex : EditorWindow {
	[MenuItem("Game Design Tool/Index",false,0)]
	public static void ShowWindow(){
		/*GDTWindow indexWindow = CreateInstance<GDTWindow>();
		indexWindow.titleContent = new GUIContent ("Index");
		indexWindow.Show ();*/
		EditorWindow.GetWindow(typeof(GDTIndex),false,"Index");
	}
}
