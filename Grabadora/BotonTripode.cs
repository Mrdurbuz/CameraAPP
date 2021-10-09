using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonTripode : MonoBehaviour
{
    public GameObject abierto;
    public GameObject cerrado;

    public CargaDispositivo CD;
    // Start is called before the first frame update
    void Start()
    {
        CD = FindObjectOfType<CargaDispositivo>();

        abierto.SetActive(false);
        cerrado.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
      
           
        }
    
    public void Abrir()
    {
        if (abierto.activeInHierarchy == false)
        {
            abierto.SetActive(true);
            cerrado.SetActive(false);
        }
        else if (abierto.activeInHierarchy == true)
        {
            abierto.SetActive(false);
            cerrado.SetActive(true);
        }

    }
}
