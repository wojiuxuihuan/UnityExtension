using UnityEditor;
using UnityEngine;

public class GDTMissionWindow : EditorWindow{
	[MenuItem("Game Design Tool/1Mission Index/Basic Settings",false,0)]
	public static void ShowBasicSettings(){
		InitWindow ("Basic Settings");
	}

	[MenuItem("Game Design Tool/1Mission Index/Grammar Settings",false,1)]
	public static void ShowGrammarSettings(){
		InitWindow ("Grammar Settings");
	}

	[MenuItem("Game Design Tool/1Mission Index/Mission Alphabet",false,2)]
	public static void ShowMissionAlphabet(){
		InitWindow ("Mission Alphabet");
	}

	[MenuItem("Game Design Tool/1Mission Index/Grammar Sets",false,3)]
	public static void ShowGrammarSets(){
		InitWindow ("Grammar Sets");
	}

	private static void InitWindow(string title){
		GDTMissionWindow[] windows =  EditorWindow.FindObjectsOfType<GDTMissionWindow> ();
		Debug.Log ("windows :"+windows.Length);
		foreach (GDTMissionWindow window in windows) {
			if (window.titleContent.text==title) {
					DestroyImmediate (window);
			}
			Debug.Log ("Title Text"+window.titleContent.text);
		}

		GDTMissionWindow missionWindow = CreateInstance<GDTMissionWindow> ();
		missionWindow.titleContent = new GUIContent (title);
		missionWindow.name = title;
		missionWindow.Show ();
		Debug.Log ("Title Text"+missionWindow.titleContent.text+"and Name : "+missionWindow.name);
		//Change the content here or in the method that refers to this method. 
	}

} 