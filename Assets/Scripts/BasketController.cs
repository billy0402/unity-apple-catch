using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour {
    public AudioClip appleSE;
    public AudioClip bombSE;
    private AudioSource _audio;
    private GameObject _director;

    // Start is called before the first frame update
    void Start() {
        this._director = GameObject.Find("GameDirector");
        this._audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Apple") {
            Debug.Log("Tag: Apple");
            this._director.GetComponent<GameDirector>().GetApple();
            this._audio.PlayOneShot(this.appleSE);
        }
        else if (other.gameObject.tag == "Bomb") {
            Debug.Log("Tag: Bomb");
            this._director.GetComponent<GameDirector>().GetBomb();
            this._audio.PlayOneShot(this.bombSE);
        }

        Destroy(other.gameObject);
    }
}