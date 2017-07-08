using UnityEngine;
using System.Collections;

public class colorButton : MonoBehaviour {
	public GameObject buttons;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	public void clickColor() {
		if (buttons.activeSelf == true)
			buttons.SetActive(false);
		else
			buttons.SetActive(true);
	}
}
