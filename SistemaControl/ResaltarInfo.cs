using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResaltarInfo : MonoBehaviour
{
    public MeshRenderer meshRen;
//Lista de renderers y materiales
    public MeshRenderer[] elementos;
    public Material[] listaMat;
    public Material normal;
    public Material resaltado;
    public bool condicion = true;
    public bool separado;

    private void Start()
    {
        //Se rellena la lista de renderers
        int cuenta= this.transform.childCount;
   
        elementos = new MeshRenderer[cuenta];
             
        elementos = this.GetComponentsInChildren<MeshRenderer>();
        //Se rellena la lista de materiales
        if (separado)
        {
            for (int i = 0; i < elementos.Length; i++)
            {
                listaMat[i] = elementos[i].material;
            }
        }
    }

    private void FixedUpdate()
    {
        //Si el objeto está mapeado en una única textura, sólo se recoge el material original.
        if (!separado)
        {
            UnicMaterial();
//Si el objeto está mapeado en distintas texturas, los objetos son tratados individualmente.
        }else if (separado)
        {
            MultiMaterial();
        }
    }

    public void UnicMaterial()
    {
        //Si las condiciones se cumplen el material se resalta.
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
        {
            if (condicion == true)
            {
                foreach (MeshRenderer elemento in elementos)
                {
                    elemento.material = resaltado;
                }

                condicion = false;
            }
        }
        //Si el material está resaltado y la condición se deja de cumplir, este vuelve a su estado original.
        else if (condicion == false)
        {
            foreach (MeshRenderer elemento in elementos)
            {
                elemento.material = normal;
            }
            condicion = true;
        }
    }

    public void MultiMaterial()
    {
        //Si las condiciones se cumplen el material se resalta.
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
        {
            if (condicion == true)
            {
                foreach (MeshRenderer elemento in elementos)
                {
                    elemento.material = resaltado;
                }

                condicion = false;
            }
        }
        //Si el material está resaltado y la condición se deja de cumplir, este vuelve a su estado original.
        else if (condicion == false)
        {
            for(int i = 0; i < listaMat.Length; i++)
            {
                elementos[i].material = listaMat[i];
            }
            condicion = true;
        }
    }
}