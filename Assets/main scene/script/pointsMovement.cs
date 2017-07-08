using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Globalization;

//create a class to define the points propertise
public class points: MonoBehaviour {
	//private GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
	private GameObject sphere = (GameObject)Instantiate(Resources.Load("Sphere"));

	public points () {
		Renderer rend = sphere.GetComponent<Renderer>();
		rend.material.color = Color.blue;
		sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
	}
	public Vector3 getPosition() {
		return sphere.transform.position;
	}

	public void setSize(float radias) {
		sphere.transform.localScale = new Vector3(radias, radias, radias);
	}
	public void setColor (Color color) {
		Renderer rend = sphere.GetComponent<Renderer>();
		rend.material.color = color;
	}
	public void setParent(GameObject parent) {
		sphere.transform.SetParent (parent.transform);
	}
	public void setPosition(Vector3 newPos) {
		sphere.transform.position = newPos;
	}
	public void destroy() {
		Destroy (sphere);
	}
}

public class pointsMovement : MonoBehaviour {

	public int GRID_POINTS = 100;
	public InputField N;
	public InputField a;
	public InputField b;
	public InputField c;
	public float aVal, bVal, cVal;
	public Color pointsColor = Color.blue;
	public GameObject centerObject;
	private GameObject parent;
	public GameObject camera;
	public bool GL;
	List <points> pointsGroup = new List<points> ();
	List <Vector3> pointsPos = new List<Vector3>();


	// Use this for initialization
	void Start () {
		aVal = 2f; bVal = 500f; cVal = 10f;
		calculate ();
		parent =  GameObject.FindGameObjectWithTag("pointsfolder");
		if (!GL)
			draw ();
		//addListner ();  //update the inputfield when it finishes input
	}

	// Update is called once per frame
	void Update () {

	}
		

	public void changeFormula () {
		aVal = float.Parse(a.text, CultureInfo.InvariantCulture.NumberFormat);
		if (aVal == 0)
			aVal = 0.1f; 
		bVal = float.Parse(b.text, CultureInfo.InvariantCulture.NumberFormat);
		GRID_POINTS = Convert.ToInt32(N.text);
		cVal = float.Parse(c.text, CultureInfo.InvariantCulture.NumberFormat);
		calculate ();
		if (!GL) {
			draw ();
		}
	}
		
	private void addListner() {
		var seN= new InputField.SubmitEvent();
		seN.AddListener(SubmitNameN);
		N.onEndEdit = seN;

		var sea= new InputField.SubmitEvent();
		sea.AddListener(SubmitNameA);
		a.onEndEdit = sea;

		var seb= new InputField.SubmitEvent();
		seb.AddListener(SubmitNameB);
		b.onEndEdit = seb;

		var sec= new InputField.SubmitEvent();
		sec.AddListener(SubmitNameC);
		N.onEndEdit = sec;
	
	}
		
	private void SubmitNameN(string num){
		GRID_POINTS = Convert.ToInt32(num);
	}

	private void SubmitNameA(string num){
		aVal = float.Parse(num, CultureInfo.InvariantCulture.NumberFormat);
	}

	private void SubmitNameB(string num){
		bVal = float.Parse(num, CultureInfo.InvariantCulture.NumberFormat);
	}

	private void SubmitNameC(string num){
		cVal = float.Parse(num, CultureInfo.InvariantCulture.NumberFormat);
	}

	public void changeColorBlue() {
		pointsColor = Color.blue;
		if (!GL)
			draw();
	}

	public void changeColorRed() {
		pointsColor = Color.red;
		if (!GL)
			draw ();
	}

	public void changeColorGreen() {
		pointsColor = Color.green;
		if (!GL)
			draw ();
	}

	void draw (){
		foreach (points a in pointsGroup) {
			a.destroy();
		}

		foreach (Vector3 pos in pointsPos) {
			points a = new points();
			pointsGroup.Add (a);
			setPointInfo (a, parent, 0.1f, pointsColor, pos);
		} 
	}

	public void calculate () {
		float[,] dataY = new float[GRID_POINTS, GRID_POINTS];
		float Ymax = float.MinValue;
		float Ymin = float.MaxValue;
		pointsPos.Clear();
		for (int x = 0; x < GRID_POINTS; x++) {
			for (int z = 0; z < GRID_POINTS; z++) {
				// dataY [x, z] = (Mathf.Sin (x/10f) + 1) * (Mathf.Sin(z/10f) + 1);
				dataY [x, z] = -((x - GRID_POINTS / aVal) * (x - GRID_POINTS / aVal) + (z - GRID_POINTS / aVal) * (z - GRID_POINTS / aVal)) / bVal + cVal;
				Vector3 pos = new Vector3 ((float)x / 20, dataY [x, z] / 20, (float)z / 20);
				Ymax = Math.Max (Ymax, dataY [x, z]);
				Ymin = Math.Min (Ymin, dataY [x, z]);
				pointsPos.Add (pos);
			}
		}  
		Vector3 center = new Vector3((float)(GRID_POINTS/2/20),(float)(Ymax + Ymin)/2/20, (float)(GRID_POINTS/2/20));
		centerObject.transform.position = center;
	}

	void setPointInfo (points a, GameObject parent, float r, Color color, Vector3 pos) { 
		a.setParent (parent);
		a.setSize(r);
		a.setColor (color);
		a.setPosition (pos);
	}

	public void setGLTrue() {
		GL = true;
		foreach (points a in pointsGroup) {
			a.destroy();
			Debug.Log ("destory!");
		}
	}

	public void setGLFalse() {
		GL = false;
		draw ();
	}
}
