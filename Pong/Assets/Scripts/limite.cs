using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limite : MonoBehaviour
{
public float velocidad = 30.0f;
public float desplazamiento;
    void Update()
    {
     
if (transform.position.x < 0){
  transform.position= new Vector3(0, transform.position.y, transform.position.z );
}
if (transform.position.x > 50){
  transform.position = new Vector3(50,transform.position.y , transform.position.z );
} 

desplazamiento= Input.GetAxis("Horizontal");
  transform.Translate(Vector3.right*desplazamiento* velocidad * Time.deltaTime);
    }
}
