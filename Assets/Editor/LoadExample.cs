using UnityEngine;
using UnityEditor;
using System.Collections;

public class LoadExample {

	[MenuItem("PlanetEditor/Create Planet")]
	static void loadExample() {

		GameObject sphere = new GameObject ("Planet");
		//sphere.name = "Sphere";

		sphere.AddComponent<MeshFilter>();
		sphere.AddComponent<MeshRenderer> ();
		sphere.GetComponent<MeshFilter>().mesh = new Mesh ();
		sphere.AddComponent<Planet> ();

		/*Texture tex  = (Texture)EditorGUIUtility.Load("aboutwindow.mainheader");
		Debug.Log("Got: " + tex.name + " !");

		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube); // as GameObject;

		Renderer r = GameObject.Find("Cube").GetComponent<Renderer>();
		r.sharedMaterial.mainTexture = tex;

		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = new Vector3(0, 1.5F, 0);

		GameObject sphere2 = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
		sphere2.name = "Cylinder O";
		sphere2.AddComponent<Rigidbody> ();
		sphere2.transform.parent = GameObject.Find ("Sphere").transform;
		//sphere2.transform.SetParent (sphere.transform); same as above
		//sphere2.transform.SetParent (sphere.transform,false); // delete the local transform going origin(0,0,0)
		//GameObject sphere2 = GameObject.Instantiate (GameObject.CreatePrimitive(PrimitiveType.Capsule), new Vector3 (0, 0, 0), new Quaternion (1, 1, 1, 1)); // as GameObject;

		//GameObject instance = Instantiate(thePrefab, transform.position, transform.rotation) as GameObject; //error
			//GameObject newGO = GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;
			//Transform Row = Transform.Instantiate(gm.LabelRow, new Vector3(0, yPos, 0), Quaternion.identity) as Transform;
        */

	}
}

//references : 