using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que dependera de la clase principal Input_Valor
public class InputValor_Bool : Input_Valor
{
    //Variable publica que actuara sobre el bool.
    public bool b;

    //Metodo que comprobará la condición que se le asigne.
    public override void CheckCond(Condicion c)
    {

    }

    //Metodo para cambiar el valor de la variable.
    public void InvertirValor()
    {
        if (b == false)
        {
            b = true;
        }
        else if (b == true)
        {
            b = false;
        }
    }

    //Metodo para asignar el valor de la variable.
    public void AsignarValor(bool nuevoValorBool)
    {
        b = nuevoValorBool;
    }

    public void ActualizarEnDisp(bool newBool)
    {
        dispositivo.GetType().GetField(varEnDisp).SetValue(dispositivo, newBool);
    }
}
