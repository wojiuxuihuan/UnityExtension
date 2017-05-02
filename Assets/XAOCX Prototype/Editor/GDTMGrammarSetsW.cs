using UnityEditor;
using UnityEngine;

public class GDTMGrammarSetsW : EditorWindow {
	[MenuItem("Game Design Tool/Mission/Grammar Sets",false,14)]
	public static void ShowWindow(){
		//EditorWindow.GetWindow(typeof(GDTMGrammarSetsW),false,"Grammar Sets");
		EditorWindow.GetWindow<GDTMGrammarSetsW>("Grammar Sets",true,typeof(GDTMIndex));	
	}
}
