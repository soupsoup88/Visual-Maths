using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;
using System.Collections.Generic;


public class GLdraw : MonoBehaviour {

	// When added to an object, draws colored rays from the
	// transform position.
	public GameObject pointsHolder;
	public GameObject centerObject;


	static Material lineMaterial;
	static void CreateLineMaterial()
	{
		if (!lineMaterial)
		{
			// Unity has a built-in shader that is useful for drawing
			// simple colored things.
			Shader shader = Shader.Find("Hidden/Internal-Colored");
			lineMaterial = new Material(shader);
			lineMaterial.hideFlags = HideFlags.HideAndDontSave;
			// Turn on alpha blending
			lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
			lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
			// Turn backface culling off
			lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
			// Turn off depth writes
			lineMaterial.SetInt("_ZWrite", 0);
		}
	}

	// Will be called after all regular rendering is done
	public void OnRenderObject()
	{
		Color pointsColor = pointsHolder.GetComponent<pointsMovement> ().pointsColor;
		int GRID_POINTS = pointsHolder.GetComponent<pointsMovement> ().GRID_POINTS;
		float aVal = pointsHolder.GetComponent<pointsMovement> ().aVal;
		float bVal = pointsHolder.GetComponent<pointsMovement> ().bVal;
		float cVal = pointsHolder.GetComponent<pointsMovement> ().cVal;

		float Ymax = float.MinValue;
		float Ymin = float.MaxValue;
	
		CreateLineMaterial();
		// Apply the line material
		lineMaterial.SetPass(0);

		GL.PushMatrix();
		// Set transformation matrix for drawing to
		// match our transform
		GL.MultMatrix(transform.localToWorldMatrix);
		float [,] dataY = new float[GRID_POINTS,GRID_POINTS];
		for (int x = 0; x < GRID_POINTS; x++) {
			for (int z = 0; z < GRID_POINTS; z++) {
				// dataY [x, z] = (Mathf.Sin (x/10f) + 1) * (Mathf.Sin(z/10f) + 1);
				dataY [x, z] = -((x - GRID_POINTS / aVal) * (x - GRID_POINTS / aVal) + (z - GRID_POINTS / aVal) * (z - GRID_POINTS / aVal)) / bVal + cVal;
				Ymax = Math.Max (Ymax, dataY [x, z]);
				Ymin = Math.Min (Ymin, dataY [x, z]);
			}
		}
		Vector3 center = new Vector3((float)(GRID_POINTS/2/20),(float)(Ymax + Ymin)/2/20, (float)(GRID_POINTS/2/20));
		centerObject.transform.position = center;

		// Draw lines
		GL.Begin(GL.LINES);
		for (int x = 0; x < GRID_POINTS; x++) {
			for (int z = 0; z < GRID_POINTS - 1; z++) {
			//GL.Color(new Color(a, 1 - a, 0, 0.8F));
			GL.Color(pointsColor);
			// One vertex at transform position
			GL.Vertex3((float)x/20, dataY[x,z]/20, (float)z/20);
			// Another vertex at edge of circle
			GL.Vertex3((float)x/20, dataY[x,z + 1]/20, (float)(z+1)/20);
			}
		}
		
		for (int z = 0; z < GRID_POINTS; z++) {
			for (int x = 0; x < GRID_POINTS - 1; x++) {
				//GL.Color(new Color(a, 1 - a, 0, 0.8F));
				GL.Color(pointsColor);
				// One vertex at transform position
				GL.Vertex3((float)x/20, dataY[x,z]/20, (float)z/20);
				// Another vertex at edge of circle
				GL.Vertex3((float)(x + 1)/20, dataY[x + 1,z]/20, (float)z/20);
			}
		}

		GL.End();
		GL.PopMatrix();
	}
}
