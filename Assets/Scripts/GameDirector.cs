using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 使用 UI 時必要的引用程式

public class GameDirector : MonoBehaviour {
    private GameObject _timerText;
    private GameObject _pointText;
    private float _time = 60.0f;
    private int _point = 0;

    // Start is called before the first frame update
    void Start() {
        this._timerText = GameObject.Find("Time");
        this._pointText = GameObject.Find("Point");
    }

    // Update is called once per frame
    void Update() {
        this._time -= Time.deltaTime;
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