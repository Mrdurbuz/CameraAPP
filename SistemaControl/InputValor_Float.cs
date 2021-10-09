using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que dependera de la clase principal Input_Valor
public class InputValor_Float : Input_Valor
{
    //Variable publica que actuara sobre el float.
    public float f;

    //public float nuevoValorFloat;

    //Metodo que comprobará la condición que se le asigne.
    public override void CheckCond(Condicion c)
    {

    }

    //Metodo para subir el valor de la variable.
    public void SubirValor()
    {
        f++;
    }

    //Metodo para bajar el valor de la variable.
    public void BajarValor()
    {
        f--;
    }

    //Metodo para asignar el valor de la variable.
    public void AsignarValor(float nuevoValorFloat)
    {
        f = nuevoValorFloat;
    }

    public void ActualizarEnDisp(float newFloat)
    {
        if (newFloat == null)
        {
            newFloat = 0;
        }
        else
        {
            dispositivo.GetType().GetField(varEnDisp).SetValue(dispositivo, newFloat);
            //dispositivo.nombre = newName;
        }
    }
}
