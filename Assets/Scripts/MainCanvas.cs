using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCanvas : MonoBehaviour {
    [SerializeField] Text resultText;
    [SerializeField] Text sentence;

    void Start() {
        resultText.text = "";
        resultText.enabled = false;
        sentence.enabled = false;
    }

    void Update() {
        if (GameManager.isFinish && Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void ShowResult(string text) {
        resultText.text = text;
        resultText.enabled = true;
        sentence.enabled = true;
    }
}
