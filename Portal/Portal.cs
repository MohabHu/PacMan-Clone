using System.Collections;
using UnityEngine;

public class Portal : MonoBehaviour {

    [SerializeField]
    Transform PortalOutTrans;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.TryGetComponent(out PlayerMovement player)){
            other.transform.position = PortalOutTrans.position;
        }
    }
}
