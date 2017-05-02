using UnityEditor;
using UnityEngine;

public class GDTMIndex : EditorWindow {
	[MenuItem("Game Design Tool/Mission/Mission Index",false,10)]
	public static void ShowWindow(){
		EditorWindow.GetWindow(typeof(GDTMIndex),false,"Mission Index");
	}

}
