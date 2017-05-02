﻿using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Star)),CanEditMultipleObjects]
public class StarInspector : Editor{

	private static Vector3 pointSnap = Vector3.one*0.1f;

	public override void OnInspectorGUI (){
		SerializedProperty 
		points = serializedObject.FindProperty ("colPoints"),
		frequency = serializedObject.FindProperty ("frequency");

		serializedObject.Update ();
		EditorGUILayout.PropertyField (serializedObject.FindProperty ("center"));
		EditorList.Show(points, EditorListOption.Buttons|EditorListOption.ListLabel);
		EditorGUILayout.IntSlider (frequency, 1, 20);

		if (!serializedObject.isEditingMultipleObjects) {
			int totalPoints = frequency.intValue * points.arraySize;
			if (totalPoints < 3)
				EditorGUILayout.HelpBox ("At least need 3 points!", MessageType.Error);
			else
				EditorGUILayout.HelpBox (totalPoints + " points totally.", MessageType.Info);
		}

		if (serializedObject.ApplyModifiedProperties () || 
			(Event.current.type == EventType.ValidateCommand && Event.current.commandName == "UndoRedoPerformed")) {
				foreach (Star s in targets) {
					if(PrefabUtility.GetPrefabType(s)!=PrefabType.Prefab)	
						s.UpdateMesh (); //don't update if the inspector target is a prefab
				}
		}
	}

	void OnSceneGUI(){
		Star star = target as Star;
		Transform starTransform = star.transform;

		float angle = -360f / (star.frequency * star.colPoints.Length);
		for (int i = 0; i < star.colPoints.Length; i++) {
			Quaternion rotation = Quaternion.Euler (0f, 0f, angle * i);
			Vector3 oldPoint = starTransform.TransformPoint(rotation*star.colPoints[i].position), 
			newPoint = Handles.FreeMoveHandle(oldPoint,Quaternion.identity,0.02f,pointSnap,Handles.DotCap);

			if (oldPoint != newPoint) {
				Undo.RecordObject (star, "Move");
				star.colPoints [i].position = Quaternion.Inverse (rotation) * starTransform.InverseTransformPoint (newPoint);
				star.UpdateMesh ();
			}
		}
	}
}