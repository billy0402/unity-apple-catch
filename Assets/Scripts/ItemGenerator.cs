using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    public GameObject applePrefab;
    public GameObject bombPrefab;
    private float _span = 1.0f;
    private float _delta = 0;
    private float _speed = -0.03f;
    private int _ratio = 2;

    public void SetParameter(float span, float speed, int ratio) {
        this._span = span;
        this._speed = speed;
        this._ratio = ratio;
    }

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        this._delta += Time.deltaTime;
        if (this._delta > this._span) {
            this._delta = 0;

            GameObject item;
            int dice = Random.Range(1, 11);
            if (dice <= this._ratio) {
                item = Instantiate(bombPrefab) as GameObject;
            }
            else {
                item = Instantiate(applePrefab) as GameObject;
            }

            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);

            item.GetComponent<ItemController>().dropSpeed = this._speed;
        }
    }
}