using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootingdestroyed : MonoBehaviour
{

    void Start(){

 }
    void Update(){

 }

 void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag=="Ennemy"){
            Destroy(gameObject);
        }
       
    }

}

