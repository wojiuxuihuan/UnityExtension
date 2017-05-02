using UnityEditor;
using UnityEngine;

public class GDTMGrammarSettingsW : EditorWindow {
	[MenuItem("Game Design Tool/Mission/Grammar Settings",false,12)]
	public static void ShowIndexWindow(){
		EditorWindow.GetWindow<GDTMGrammarSettingsW>("Grammar Setting",true,typeof(GDTMIndex));	
	}
}
