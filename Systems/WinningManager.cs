using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningManager : MonoBehaviour {

    private void Start() {
        StartCoroutine(FinishVideo());
    }


    IEnumerator FinishVideo(){

        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
}
