using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemydestroyed : MonoBehaviour

{
    public AudioClip killSound;
    void Start(){

 }
    void Update(){

 }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.CompareTag("bullet"))
        {
            AudioManager.instance.PlayClipAt(killSound, transform.position);
            gameObject.GetComponent<EnnemyMove>().TakeDamage(1f);
        }
       
    }

}
