using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 使用 UI 時必要的引用程式

public class GameDirector : MonoBehaviour {
    private GameObject _generator;
    private GameObject _timerText;
    private GameObject _pointText;
    private float _time = 30.0f;
    private int _point = 0;

    // Start is called before the first frame update
    void Start() {
        this._generator = GameObject.Find("ItemGenerator");
        this._timerText = GameObject.Find("Time");
        this._pointText = GameObject.Find("Point");
    }

    // Update is called once per frame
    void Update() {
        this._time -= Time.deltaTime;

        if (this._time < 0) {
            this._time = 0;
            this._generator.GetComponent<ItemGenerator>().SetParameter(10000.0f, 0, 0);
        }
        else if (0 <= this._time && this._time < 5) {
            this._generator.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.04f, 3);
        }
        else if (5 <= this._time && this._time < 12) {
            this._generator.GetComponent<ItemGenerator>().SetParameter(0.5f, -0.05f, 6);
        }
        else if (12 <= this._time && this._time < 23) {
            this._generator.GetComponent<ItemGenerator>().SetParameter(0.8f, -0.04f, 4);
        }
        else if (23 <= this._time && this._time < 30) {
            this._generator.GetComponent<ItemGenerator>().SetParameter(1.0f, -0.03f, 2);
        }

        this._timerText.GetComponent<Text>().text = this._time.ToString("F1");
        this._pointText.GetComponent<Text>().text = this._point.ToString() + " point";
    }

    public void GetApple() {
        this._point += 100;
    }

    public void GetBomb() {
        this._point /= 2;
    }
}