using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que dependera de la clase principal Input_Valor
public class InputValor_Int : Input_Valor
{
    //Variable publica que actuara sobre el int.
    public int i;

    //public int nuevoValorInt;

    //Metodo que comprobará la condición que se le asigne.
    public override void CheckCond(Condicion c)
    {

    }

    //Metodo para subir el valor de la variable.
    public void SubirValor()
    {
        i++;
    }

    //Metodo para bajar el valor de la variable.
    public void BajarValor()
    {
        i--;
    }

    //Metodo para asignar el valor de la variable.
    public void AsignarValor(int nuevoValorInt)
    {
        i = nuevoValorInt;
    }

    public void ActualizarEnDisp(int newInt)
    {
        if (newInt == null)
        {
            newInt = 0;
        }
        else
        {
            dispositivo.GetType().GetField(varEnDisp).SetValue(dispositivo, newInt);
            //dispositivo.nombre = newName;
        }
    }
}
