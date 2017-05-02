using UnityEngine;
using UnityEditor;

public class receiveEvent : EditorWindow {

	[MenuItem ("Examples/Receive Event")]
	static void Init()
	{
		receiveEvent window =
			EditorWindow.GetWindow<receiveEvent>(true, "Receive Event Window");
		window.Show();
	}

	void OnGUI()
	{
		Event e = Event.current;

		if (e.commandName == "Paste")
			Debug.Log("Paste received");
	}
}