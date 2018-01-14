using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleCanvas : MonoBehaviour {
    [SerializeField] Text titleText;
    [SerializeField] Text copyrightText;
    [SerializeField] Text countdownText;

    bool startGame;

	// Use this for initialization
	void Start () {
		startGame = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!startGame && Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(Countdown());
            startGame = true;
        }
	}

    IEnumerator Countdown() {
        var count = 3;

        titleText.enabled = false;
        copyrightText.enabled = false;
        while(count > 0) {
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1f);
            count--;
        }

        GameManager.StartGame();
        countdownText.text = "スタート!";
        yield return new WaitForSeconds(1f);
        countdownText.text = "";

        gameObject.SetActive(false);
    }
}
