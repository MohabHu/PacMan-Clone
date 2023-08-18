using System.Collections;
using UnityEngine;

public class PelletePowerUp : MonoBehaviour {

    GhostAi[] ghosts;

    public static bool Retreating {get; set;}
    private void Start() {
        Retreating = false;
        ghosts = FindObjectsOfType<GhostAi>();
    }

    
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.TryGetComponent(out PlayerMovement player)){
            ScoreSystem.AddScore(50);
            SoundManager.PlaySound(SoundNames.EAT_POWER_PELLETE);
            Retreating = true;
            foreach (var ghost in ghosts)
            {
                ghost.StartRetreating();
            }
            Destroy(gameObject);
        }
    }

    

    
    
}
