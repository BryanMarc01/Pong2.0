using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bola : MonoBehaviour {
public Text resultado;
//Velocidad de la pelota
public float velocidad = 30.0f;
//Audio Source
AudioSource fuenteDeAudio;
//Clips de audio
public AudioClip Gol, Raqueta, Rebote, end, start;
//Contadores de goles
public int golesIzquierda = 0;
public int golesDerecha = 0;
//Cajas de texto de los contadores
public Text contadorIzquierda;
public Text contadorDerecha;
// Use this for initialization
void Start () {
    //Desactivo la caja de resultado
resultado.enabled = false;
//Quito la pausa
Time.timeScale = 1;

//Velocidad inicial hacia la derecha
GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
//Recupero el componente audio source;
fuenteDeAudio = GetComponent<AudioSource>();
//Pongo los contadores a 0
fuenteDeAudio.clip = start;
fuenteDeAudio.Play();
contadorIzquierda.text = golesIzquierda.ToString();
contadorDerecha.text = golesDerecha.ToString();

}



//Se ejecuta si choco con la raqueta
void OnCollisionEnter2D(Collision2D micolision){

//Si me choco con la raqueta izquierda

if (micolision.gameObject.name == "Raqueta Izquierda"){
//Valor de x
int x = 1;
//Valor de y
int y = direccionY(transform.position,
micolision.transform.position);
//Vector de dirección
Vector2 direccion = new Vector2(x, y);
//Aplico la velocidad a la bola
GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
//Reproduzco el sonido de la raqueta
fuenteDeAudio.clip = Raqueta;
fuenteDeAudio.Play();
}
//Si me choco con la raqueta derecha
else if (micolision.gameObject.name == "Raqueta Derecha"){
//Valor de x
int x = -1;
//Valor de y
int y = direccionY(transform.position,
micolision.transform.position);
//Vector de dirección
Vector2 direccion = new Vector2(x, y);
//Aplico la velocidad a la bola
GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
//Reproduzco el sonido de la raqueta
fuenteDeAudio.clip = Raqueta;
fuenteDeAudio.Play();
}

//Para el sonido del rebote
if (micolision.gameObject.name == "Arriba" ||
micolision.gameObject.name == "Abajo"){
//Reproduzco el sonido del rebote
fuenteDeAudio.clip = Rebote;
fuenteDeAudio.Play();
}




}
//Calculo la dirección de Y
int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta){
if (posicionBola.y > posicionRaqueta.y){
return 1;
}
else if (posicionBola.y < posicionRaqueta.y){
return -1;
}
else{
return 0;
}
}
//Reinicio la posición de la bola
public void reiniciarBola(string direccion){
//Posición 0 de la bola
transform.position = Vector2.zero;
//Vector2.zero es lo mismo que new Vector2(0,0);
//Velocidad inicial de la bola
float gol=1.1f;
velocidad = gol * velocidad;
//Velocidad y dirección
if (direccion == "Derecha"){
//Incremento goles al de la derecha
golesDerecha++;
//Lo escribo en el marcador
contadorDerecha.text = golesDerecha.ToString();
//Reinicio la bola
GetComponent<Rigidbody2D>().velocity = Vector2.right *
velocidad;
//Vector2.right es lo mismo que new Vector2(1,0)
}
else if (direccion == "Izquierda"){
//Incremento goles al de la izquierda
golesIzquierda++;
//Lo escribo en el marcador
contadorIzquierda.text = golesIzquierda.ToString();
//Reinicio la bola
GetComponent<Rigidbody2D>().velocity = Vector2.left *
velocidad;
//Vector2.right es lo mismo que new Vector2(-1,0)
}
//Reproduzco el sonido del gol
fuenteDeAudio.clip = Gol;
fuenteDeAudio.Play();
bool comprobarFinal(){

  //Si el de la izquierda ha llegado a 5
  if (golesIzquierda == 5){
    fuenteDeAudio.clip = end;
fuenteDeAudio.Play();
    //Escribo y muestro el resultado
    resultado.text = "¡Jugador Izquierda GANA!\nPulsa I para volver a Inicio\nPulsa P para volver a jugar";
    //Muestro el resultado, pauso el juego y devuelvo true
    resultado.enabled = true;
    Time.timeScale = 0; //Pausa
    return true;
    
  }
  //Si el de le aderecha a llegado a 5
  else if (golesDerecha == 5){
    //Escribo y muestro el resultado
    fuenteDeAudio.clip = end;
fuenteDeAudio.Play();
    resultado.text = "¡Jugador Derecha GANA!\nPulsa I para volver a Inicio\nPulsa P para volver a jugar";
    //Muestro el resultado, pauso el juego y devuelvo true
    resultado.enabled = true;
    Time.timeScale = 0; //Pausa

    return true;
        
  }
  //Si ninguno ha llegado a 5, continúa el juego
  else{
    return false;
  }
}


/* Modifica y sustituye el método reiniciarBola en la comprobación de la dirección Derecha */

//Reinicio la bola (si no ha llegado a 5)
if (!comprobarFinal()){
  GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
  //Vector2.right es lo mismo que new Vector2(1,0)
}	


/* Modifica y sustituye el método reiniciarBola en la comprobación de la dirección Izquierda */

//Reinicio la bola (si no ha llegado a 5)
if (!comprobarFinal()){
  GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidad;
  //Vector2.left es lo mismo que new Vector2(-1,0)
}	
}

}

