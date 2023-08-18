using System.Collections;
using UnityEngine;

public class Clyde : MonoBehaviour {

    [SerializeField]
    GhostAi ghostAi;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Clyde"){
            ghostAi.ClydeChase();
        }
    }
}
