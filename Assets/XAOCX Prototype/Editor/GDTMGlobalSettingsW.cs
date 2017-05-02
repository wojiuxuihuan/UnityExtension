using UnityEditor;
using UnityEngine;

public class GDTMBasicW: EditorWindow {
	[MenuItem("Game Design Tool/Mission/Global Setting",false,11)]
	public static void ShowIndexWindow(){
		EditorWindow.GetWindow<GDTMBasicW>("Global Setting",true,typeof(GDTMIndex));	
	}
}
