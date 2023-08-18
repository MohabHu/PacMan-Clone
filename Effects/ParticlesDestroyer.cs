using System.Collections;
using UnityEngine;

public class ParticlesDestroyer : MonoBehaviour {

    GameObject particleDestroyer;

    private void Awake() {
        particleDestroyer = GetComponent<GameObject>();
    }
    void Start() {
        Destroy(gameObject, 5f);
    }
}
