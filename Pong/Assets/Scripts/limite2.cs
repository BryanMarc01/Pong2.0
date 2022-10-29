using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limite2 : MonoBehaviour
{
  public float velocidad = 30.0f;
public float desplazamiento2;
    void Update()
    {
     
if (transform.position.x < -50){
  transform.position= new Vector3(-50, transform.position.y, transform.position.z );
}
if (transform.position.x > 0){
  transform.position = new Vector3(0,transform.position.y , transform.position.z );
} 

desplazamiento2= Input.GetAxis("Horizontal 2");
  transform.Translate(Vector3.right*desplazamiento2* velocidad * Time.deltaTime);
    }
}