using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ListTester)), CanEditMultipleObjects] 
public class ListTesterInspector : Editor{
	public override void OnInspectorGUI ()
	{
		serializedObject.Update ();
		/*EditorGUILayout.PropertyField (serializedObject.FindProperty ("integers"),true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("vectors"),true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("colorPoints"),true);
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("objects"),true);*/
		EditorList.Show(serializedObject.FindProperty("integers"),EditorListOption.ListSize);
		EditorList.Show(serializedObject.FindProperty("vectors"));
		EditorList.Show(serializedObject.FindProperty("colorPoints"),EditorListOption.Buttons);
		//EditorList.Show(serializedObject.FindProperty("objects"),EditorListOption.ListLabel);
		EditorList.Show(
			serializedObject.FindProperty("objects"),
			EditorListOption.ListLabel | EditorListOption.Buttons);
		EditorList.Show(serializedObject.FindProperty("notList"));
		serializedObject.ApplyModifiedProperties ();
	}
}