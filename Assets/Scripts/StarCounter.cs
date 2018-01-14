using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCounter : MonoBehaviour {
    Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
        Initialize();
	}

    void Initialize() {
        text.text ="";
    }

    public void UpdateText(int starCount) {
        var str = "";
        for (int n = 0; n < starCount; n++) str += "●";

        text.text = str;
    }
}
