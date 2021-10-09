using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_V2 : MonoBehaviour
{
    //Imagen y texto y sus recttransform.
    public Image imagen;
    public Text texto;

    RectTransform rectImagen;
    RectTransform rectText;
    RectTransform canvRect;
    //Referencia ancho y alto pantalla
    public float ancho;
    public float alto;
    public float extension;

    public Vector2 pos;

    public string nombre;
    public string value;

    public Vector2 desplazamiento;
    public GameObject gestor;
    public DiccionarioDispositivo DD;
    public float sobra;
    public bool izQ;
    public bool limite=true;
    public float distanciaLateralIzq;
    public float distanciaLateralDer;

    public Canvas canvas;

    public LayerMask ignoreLayer;

    // Start is called before the first frame update
    void Start()
    {
        Desaparecer();
        rectImagen = this.GetComponent<RectTransform>();
        canvRect = canvas.GetComponent<RectTransform>();
        rectText = texto.GetComponent<RectTransform>();
        DD = gestor.GetComponent<DiccionarioDispositivo>();
        canvas = FindObjectOfType<Canvas>();
        izQ = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Screen.width + " " + Screen.height);

        ancho = canvas.pixelRect.width;
        alto = canvas.pixelRect.height;

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButtonDown(0) && imagen.enabled == false)
        {

            Posicion();

        }
        else if (imagen.enabled == true && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
        {
            Desaparecer();
        }

        //Debug.Log(rectImagen.localPosition);

    }
    public void Posicion()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 30, ignoreLayer))
        {
            print(hit.collider.name);
            pos = Input.mousePosition;
            Descripcion(hit);
        }
    }
    public void Descripcion(RaycastHit target)
    {
        nombre = target.transform.gameObject.name;
        value = DD.Respuesta(nombre);
        texto.text = value;
        rectText.sizeDelta = new Vector2(texto.preferredWidth+extension, texto.preferredHeight+extension);
        ColocarTxt();
        Aparecer();
    }
    public void ColocarTxt()
    {
        rectText.sizeDelta = new Vector2(texto.preferredWidth+extension, texto.preferredHeight+extension);
        //rectText.localPosition = Input.mousePosition - new Vector3(Screen.width,Screen.height,0);
        rectText.localPosition = (Input.mousePosition - new Vector3(Screen.width, Screen.height, 0)/2) / canvRect.localScale.x;
        rectImagen.localPosition = rectText.localPosition;

        //Debug.Log(Input.mousePosition);

        rectImagen.sizeDelta = rectText.sizeDelta;
        Desplazar();
        PosicionLateral();
    }
    public void Desplazar()
    {
        desplazamiento.x = rectImagen.sizeDelta.x / 2;
        desplazamiento.y = rectImagen.sizeDelta.y / 2;

       

        if (izQ == true)
        {
            //rectImagen.position += new Vector3(-desplazamiento.x*1.5f, -desplazamiento.y*1.3f, 0);
            rectImagen.position += new Vector3(-desplazamiento.x , -desplazamiento.y , 0) * canvRect.localScale.x;
            //rectText.position += new Vector3(desplazamiento.x, -desplazamiento.y, 0);
        }
        else if (izQ == false)
        {
            //rectImagen.position += new Vector3(desplazamiento.x*1.5f, -desplazamiento.y*1.3f, 0);
            rectImagen.position += new Vector3(desplazamiento.x , -desplazamiento.y , 0)*canvRect.localScale.x;
            //rectText.position += new Vector3(-desplazamiento.x, -desplazamiento.y, 0);
        }
        rectText.position = rectImagen.position;


    }

    public void PosicionLateral()
    {
          if (limite == true)
          {
            
              if (izQ == false)
              {
               
                  

                  if ((rectImagen.sizeDelta.x*canvRect.localScale.x+ Input.mousePosition.x)  > ancho)
                  {
                      
                      sobra = (ancho-(rectImagen.sizeDelta.x*canvRect.localScale.x+Input.mousePosition.x ));
                      rectImagen.position += new Vector3(sobra, 0, 0);
                  }

              }
              else if (izQ == true)
              {
                
                

                  if (rectImagen.sizeDelta.x*canvRect.localScale.x -pos.x  >0)
                  {
               
                      sobra = (Input.mousePosition.x - rectImagen.sizeDelta.x*canvRect.localScale.x);
                      rectImagen.position += new Vector3(-sobra, 0, 0);
                  }
              }
            rectText.position = rectImagen.position;
        }
          else
          {
        return;
          }
    }

    public void Aparecer()
    {
        texto.enabled = true;
        imagen.enabled = true;
    }
    public void Desaparecer()
    {
        texto.enabled = false;
        imagen.enabled = false;
    }
}
