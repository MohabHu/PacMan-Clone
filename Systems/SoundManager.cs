using System.Collections;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [SerializeField]
    Sound[] sounds;

    

    static Sound[] staticSounds;

    public static SoundManager i;

    public static Sound[] Sounds => staticSounds;

    private void Awake() {
        staticSounds = sounds;
    }

    public static void PlaySound(SoundNames name){
        AudioSource.PlayClipAtPoint(Sounds.First((x => x.soundName == name)).clip, Vector3.zero, 100);
    }


    //Trash Code
    private void Update() {
        PlayRetreating();
    }
    void PlayRetreating(){
        
        if(PelletePowerUp.Retreating){
            StartCoroutine(Retreating());
        }
        else if(sirenEnded && isRetreating == false){
            StartCoroutine(PlaySiren());
        }
        
    }

    bool isRetreating = false;
    IEnumerator Retreating(){
        PelletePowerUp.Retreating = false;
        isRetreating = true;

        SoundManager.PlaySound(SoundNames.GHOST_RETREATING);

        yield return new WaitForSeconds(2);

        SoundManager.PlaySound(SoundNames.GHOST_RETREATING);

        yield return new WaitForSeconds(2);
        
        isRetreating = false;


    }
    bool sirenEnded = true;
    IEnumerator PlaySiren(){

        sirenEnded = false;
        SoundManager.PlaySound(SoundNames.SIREN);

        yield return new WaitForSeconds(1.57f);

        sirenEnded = true;
    }
    
}

[System.Serializable]
public class Sound {

    public AudioClip clip;
    public SoundNames soundName;

}
