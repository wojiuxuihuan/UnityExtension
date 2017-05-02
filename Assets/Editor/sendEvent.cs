using UnityEngine;
using UnityEditor;

public class sendEvent : EditorWindow {

	[MenuItem ("Examples/AddCursorRect Example")]
	static void addCursorRectExample ()
	{
		sendEvent window =
			EditorWindow.GetWindowWithRect<sendEvent> (new Rect(0,0,180,80));
		window.Show();
	}

	[MenuItem ("Examples/Send Event")]
	static void Init()
	{
		sendEvent window =
			EditorWindow.GetWindow<sendEvent>(true, "Send Event Window");
		window.Show();
	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(10.0f, 10.0f, 100.0f, 30.0f), "Send Event"))
		{
			EditorWindow win = GetWindow<receiveEvent>();
			win.SendEvent(EditorGUIUtility.CommandEvent("Paste"));
		}
		EditorGUI.DrawRect(new Rect(10,10, 160, 60), new Color(0.5f, 0.5f, 0.85f));
		EditorGUI.DrawRect(new Rect(20,20, 140, 40), new Color(0.9f, 0.9f, 0.9f));
		EditorGUIUtility.AddCursorRect (new Rect(20,20,140,40), MouseCursor.Zoom);

		//ObjectPickerを開く
		if (GUILayout.Button ("ShowObjectPicker")) {
			int controlID = EditorGUIUtility.GetControlID (FocusType.Passive);
			//CameraのコンポーネントをタッチしているGameObjectを選択する
			EditorGUIUtility.ShowObjectPicker<Camera> (null, true, "", controlID);
		}

		string commandName = Event.current.commandName;
		if (commandName == "ObjectSelectorUpdated") {
			currentObject = EditorGUIUtility.GetObjectPickerObject ();
			//ObjectPickerを開いている間はEditorWindowの再描画が行われないのでRepaintを呼びだす
			Repaint ();
		} else if (commandName == "ObjectSelectorClosed") {
			selectedObject = EditorGUIUtility.GetObjectPickerObject ();
		}

		EditorGUILayout.ObjectField (currentObject, typeof(Object), true);
		EditorGUILayout.ObjectField (selectedObject, typeof(Object), true);
	}

	[MenuItem("Examples/Example")]
	static void Do ()
	{
		GetWindow<sendEvent> ();
	}

	Object currentObject = null;
	Object selectedObject = null;

}