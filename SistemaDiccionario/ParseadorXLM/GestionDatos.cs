using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionDatos : MonoBehaviour
{

    public Camaras miGuard;

    public Dropdown dropOptions;
    public Text textDebug;

    public string rutaArchivo;
    public string rutaArchivoBuild;

    string ruta;

    //Dictionary<string, string> infoDisp;

    void Awake()
    {
        if (!Debug.isDebugBuild /*Si el archivo es una build*/)
        {
        ruta = rutaArchivoBuild;
        }else if (Debug.isDebugBuild /*si el archivo no es una build*/)
        {
        ruta = rutaArchivo;
        }

        DirectoryInfo dirInfo = new DirectoryInfo(Application.dataPath + ruta /*Application.persistenData*/);
    }

    //metodo creado para guardar un nuevo XML en la carpeta seleccionada
    public void Save()
    {
        string dataPath = /*Application.persistentDataPath*/ Application.dataPath + ruta;

        var serializer = new XmlSerializer(typeof(Camaras));
        var stream = new FileStream(dataPath + "/" + miGuard.saveCamera + ".save", FileMode.Create);
        serializer.Serialize(stream, miGuard);
        stream.Close();

        Debug.Log("guardado");
        //Dependiendo de la escena en la que estes se carga.
        SceneManager.LoadScene("Escena_Principal_Multi");
    }

    //Metodo que carga el XML en funcion del dispositivo que se carga
    public void Load(string dispositivo)
    {
        //ruta de la carpeta que contiene los archivos
        string dataPath = Application.dataPath + ruta;

        //Ruta y carga de archivos con extension del programa.
        if (System.IO.File.Exists(dataPath + "/" + dispositivo  + ".save"))
        {
            var serializer = new XmlSerializer(typeof(Camaras));
            var stream = new FileStream(dataPath + "/" +  dispositivo + ".save", FileMode.Open);

            miGuard = serializer.Deserialize(stream) as Camaras;

            stream.Close();

            DebugDatos();
        }
    }

    //Borra un XML
    public void Delete()
    {
        string dataPath = Application.dataPath + ruta;
        File.Delete(dataPath + "/" + miGuard.saveCamera + ".save");
    }

    //Recarga de datos en el Gestor
    public void DebugDatos()
    {
        textDebug.text = miGuard.saveCamera;
        foreach(Elemento a in miGuard.lista)
        {
            textDebug.text += "\n" + " " + a.item + " " + a.descripcion; 
        }
    }

    public Dictionary<string, string> CargarDiccionario()
    {
        //En vez de usar la variable alojada en este script ahora usamos la que el otro nos pasa
        FindObjectOfType<DiccionarioDispositivo>().infoDisp = new Dictionary<string, string>();

         Dictionary<string, string> infoDisp = new Dictionary<string, string>();
        //La vaciamos
        infoDisp.Clear();
        //Cargamos la informacion nueva en la variable del otro script
        foreach (Elemento e in miGuard.lista)
        {
            infoDisp.Add(e.item, e.descripcion);
        }



        return infoDisp;
    }
}

//Clases para formato de XML
//Clase camara para xml
[System.Serializable]
public class Camaras
{
    public string saveCamera;
    public Elemento[ ] lista;
}

//Clase Elemento contenida en camara
[System.Serializable]
public class Elemento
{
    public string item;
    public string descripcion;
}



