/*Este script tiene el objetivo de generar una ventana emergente en el puntero cuando el usuario clickea en determinados objetos. Esta ventana emergente contendrá un texto con una descripción del objeto
 * y por defecto tendrá el mismo tamaño que el texto. La imagen debe ser configurable, teniendo las opciones de aparecer a la izquierda o derecha del puntero. También debe tener la posibilidad
 * de tener en cuenta los límites de la pantalla y debe poder extenderse algo más de lo que ocupa el texto.*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    //Los elementos que conforman el pop up.
    public Image imagen;
    public Text texto;
    RectTransform rectTransform;
    RectTransform rTtxt;
    //Los elementos que configuran el tamaño y la posición del pop up.
    public Vector2 pos;
    public Vector2 tamañoTxt;
    public Vector3 desplazamiento;
    //BOOL
    public bool Izq = true;
    public bool LimiteAct = true;


    //FLOAT
    private float ancho;
    private float alto;
    public float Extension; //Extensión sirve para extender la imagen más de lo que ocupa el texto.
    public Camera cam;
    //Variables para acceder a la descripción del objeto desde el script DiccionarioDispositivo.
   public string nombre;
    public string value;
    private DiccionarioDispositivo DD;
    
    
    public GameObject Gestor;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
        rTtxt = texto.GetComponent<RectTransform>();
        DD = FindObjectOfType<DiccionarioDispositivo>();
    }

    // Update is called once per frame
    void Update()
    {
        ancho = Screen.width;
        Debug.Log(ancho);  
        alto = Screen.height;
        tamañoTxt = new Vector2(texto.preferredWidth, texto.preferredHeight);
       


      
       
        texto.text = value;
        rectTransform.sizeDelta = tamañoTxt + new Vector2(Extension, Extension);
        rTtxt.position = rectTransform.position;
        rTtxt.sizeDelta = rectTransform.sizeDelta - new Vector2(Extension, 0);
       //rectTransform.sizeDelta = tamañoTxt + new Vector2(Extension, Extension);
     

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButtonDown(0)&& imagen.enabled==false)
        {
            
            RayCast();
            
        }
       else if (imagen.enabled == true && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
        {
            Desaparecer();
        }

    }
    //Lanza un RayCast desde el puntero que detecta dónde ha clickado el usuario. Igualando el nombre al nombre del objeto clickado.
    public void RayCast()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            nombre = hit.transform.gameObject.name;
            value = DD.Respuesta(nombre);
            Aparecer();
        }
        else 
        {
            Desaparecer();
        }
    }
      
    
    //Hace que el PopUp aparezca teniendo en cuenta todas las variables y la posición del ratón.
    void Aparecer()
    {
        pos.y = Input.mousePosition.y - desplazamiento.y;
        pos.x = Input.mousePosition.x + desplazamiento.x;
        desplazamiento.x = rTtxt.rect.width / 2;
        desplazamiento.y = rTtxt.rect.height / 2;
        if (Izq == false & desplazamiento.x > 0)
        {

            desplazamiento.x = desplazamiento.x * -1;

        }
        if (Izq == true & desplazamiento.x < 0)
        {
            desplazamiento.x = desplazamiento.x * -1;
        }
        if (LimiteAct == true)
        {

//Si el borde derecho del popup se sale de la pantalla.
            if (pos.x + desplazamiento.x*1.6f+Extension > ancho)
            {
                pos.x = ancho - (desplazamiento.x*1.6f+Extension) ;
                
            }
            if (pos.x < desplazamiento.x * 1.6f+Extension)
            {
                pos.x = desplazamiento.x*1.6f+Extension;
            }
            if (Izq == false)
            {
                //Si el borde izquierdo se sale.
                if (pos.x < -1.6f * desplazamiento.x-Extension)
                {
                    pos.x = desplazamiento.x * -1.6f+Extension;
                }
                if (pos.x + desplazamiento.x * -1.6+Extension > ancho)
                {
                    pos.x = ancho - desplazamiento.x * -1.6f-Extension;
                }
            }

            if (pos.y + desplazamiento.y > alto)
            {
                pos.y = alto - desplazamiento.y;
            }
            if (pos.y < desplazamiento.y)
            {
                pos.y = desplazamiento.y;
            }

            rectTransform.position = pos;

            imagen.enabled = true;
            texto.enabled = true;
        }
        else if (Izq == false)
        {
            desplazamiento.x = desplazamiento.x * -1;
            pos = Input.mousePosition - desplazamiento;

            rectTransform.position = pos;
            imagen.enabled = true;
            texto.enabled = true;
        }
        else
        {
            desplazamiento = -desplazamiento;
            rectTransform.position = pos;

            imagen.enabled = true;
            texto.enabled = true;
        }
    }
    //El pop up desaparece.
    void Desaparecer()
    {
        imagen.enabled = false;
        texto.enabled = false;
    }
}

