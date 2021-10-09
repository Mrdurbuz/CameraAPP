using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BotonGrabadora : MonoBehaviour
{
    private Dropdown Drop;
    public GameObject boton;
    public GameObject boton2;
    public GameObject esponjo;
    public GameObject abierto;
    public GameObject cerrado;
    private MeshRenderer mesherino;
    private MeshRenderer mesherino2;
    public bool tripode;
    public CargaDispositivo CD;

    // Start is called before the first frame update
    void Start()
    {
       
        CD = FindObjectOfType<CargaDispositivo>();
        mesherino = esponjo.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
  
    public void Esponja()
    {
        if (mesherino.enabled ==true)
        {
            mesherino.enabled = false;
        }
        else
        {
            mesherino.enabled = true;
        }
    }
 
}
