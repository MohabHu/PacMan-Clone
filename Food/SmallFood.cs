using System.Collections;
using UnityEngine;

public class SmallFood : MonoBehaviour {


    static bool munching_1 = true;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.TryGetComponent(out PlayerMovement player)){
            ScoreSystem.AddScore(10);
            Destroy(gameObject);
            if(munching_1){
                SoundManager.PlaySound(SoundNames.MUNCH_1);
                munching_1 = false;
            }
            else{
                SoundManager.PlaySound(SoundNames.MUNCH_2);
                munching_1 = true;
            }

            
        }
    }

    //Munch 1 once then Munch 2 once and repeat

    private void OnDestroy() {
        
        GameManager.Pellets.Remove(this);
    }
}
