using System.Collections;
using UnityEngine;

public class Ghostinteraction : MonoBehaviour {

    

    [SerializeField]
    Transform resetPoint;

    GhostAi[] ghosts;

    [SerializeField]
    GameObject enemyBounds;
    

    CircleCollider2D coll2d;

    private void Awake() {
        ghosts = FindObjectsOfType<GhostAi>();
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.TryGetComponent(out PlayerHealth player)){
            if(GhostAi.IsRetreating){
                transform.position = resetPoint.position;
                SoundManager.PlaySound(SoundNames.EAT_GHOST);
            }
            else{
                player.TakeDamage();
                foreach (var ghost in ghosts)
                {
                    ghost.gameObject.transform.position = resetPoint.position;
                }
            }

            StartCoroutine(StopEnemies());
            
        }
    }

    IEnumerator StopEnemies(){

        enemyBounds.SetActive(true);

        yield return new WaitForSeconds(5);

        enemyBounds.SetActive(false);

    }

    
}
