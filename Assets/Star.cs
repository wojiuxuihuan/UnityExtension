using UnityEngine;

[ExecuteInEditMode,RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class Star : MonoBehaviour{

	//public Vector3 point = Vector3.up;
	//public int numberOfPoints = 10;
	//public Vector3[] points;
	public int frequency = 1;
	public ColorPoint center;
	public ColorPoint[] colPoints;

	private Color[] colors;
	private Mesh mesh;
	private Vector3[] vertices;
	private int[] triangles;

	void Start(){
		UpdateMesh ();
	}

	public void UpdateMesh(){
		if (mesh == null) {
			GetComponent<MeshFilter> ().mesh = mesh = new Mesh ();
			mesh.name = "Star Mesh";
			mesh.hideFlags = HideFlags.HideAndDontSave;
		}
			
		if (frequency < 1)
			frequency = 1;
		if(colPoints==null)
			//points = new Vector3[0];
			colPoints = new ColorPoint[0];
		int numberOfPoints = frequency * colPoints.Length;

		if (vertices == null || vertices.Length != numberOfPoints + 1) {
			vertices = new  Vector3[numberOfPoints+1];
			triangles = new int[numberOfPoints * 3];
			colors = new Color[numberOfPoints + 1];
			mesh.Clear ();
		}

		if (numberOfPoints >= 3) {
			vertices [0] = center.position;
			colors [0] = center.color;

			float angle = -360f / numberOfPoints;

			for(int rep = 0, v=1,t=1;rep<frequency;rep++){
				for(int p = 0; p < colPoints.Length; p+=1, v+=1, t+=3){ 
					vertices[v] = Quaternion.Euler(0f,0f,angle*(v-1))*colPoints[p].position;
					colors [v] = colPoints[p].color;
					triangles [t] = v;
					triangles [t + 1] = v + 1;
				}
			}	

			triangles [triangles.Length - 1] = 1;
		}

		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.colors = colors;
	}

	void Reset(){
		UpdateMesh ();
	}

	void OnEnable(){
		UpdateMesh ();
	}
}