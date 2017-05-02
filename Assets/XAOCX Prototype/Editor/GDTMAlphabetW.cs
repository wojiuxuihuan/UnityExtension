using UnityEditor;
using UnityEngine;

public class GDTMAlphabetW : EditorWindow {
	[MenuItem("Game Design Tool/Mission/Alphabet",false,13)]
	public static void ShowWindow(){
		EditorWindow.GetWindow<GDTMAlphabetW>("Alphabet",true,typeof(GDTMIndex));	
	}
}
