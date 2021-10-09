using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using UnityEngine.UI;


public class DiccionarioDispositivo : MonoBehaviour
{
    public Dictionary<string, string> infoDisp = new Dictionary<string, string>();
    public int numero;
    //public GameObject Imagen;
    public string nombre;
    public string value;
    public string Key;

    //***Añado variable dispositivo para poder seleccionar el que quieres que lea***
    public string disp;
    public GestionDatos gestionDatos;

    // Start is called before the first frame update
    void Awake()
    {
        gestionDatos = FindObjectOfType<GestionDatos>();
    }

    public string Respuesta(string K)
    {
        string value = "";
        bool hasValue = infoDisp.TryGetValue(K, out value);
        return value;
    }

    public void CargarXML(string disp)
    {
        //***Cargar llama a load para cargar el archivo y luego a cargar diccionario para pasar la informacion del archivo al diccionario infodisp
        gestionDatos.Load(disp);
        gestionDatos.CargarDiccionario();
        infoDisp = gestionDatos.CargarDiccionario();
    }
}
