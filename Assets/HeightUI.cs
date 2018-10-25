using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightUI : MonoBehaviour {

    [SerializeField] Text heightText;
    [SerializeField] Transform pogostickTransform;
	void Update () {
        heightText.text = "Height : " + Mathf.Round(pogostickTransform.position.y) + "M";
	}
}
