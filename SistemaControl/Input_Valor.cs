using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que guardará los valores de cada elemento interactuable. Intetaremos usar el polimorfismo
/// </summary>
public class Input_Valor : MonoBehaviour
{
    public string Name;
    Condicion[] condList;
    public Condicion condicion;
    public string varEnDisp = "zoom"; // Saves the var in the Dispositivo class
    public Dispositivo dispositivo;

    [System.Serializable]
    public struct Condicion
    {
        public Input iv;
        public string s;
        public int i;
        public bool b;
    }

    public virtual void CheckCond(Condicion c)
    {

    }
}

/// <summary>
/// Clases designadas para guardar valores concretos de cada uno de los valores
/// </summary>
/*public class InputValor_Int : Input_Valor
{
    public int i;

    //public float nuevoValorInt;
    public override void CheckCond(Condicion c) 
    { 
    
    }
    public void SubirValor()
    {
        i++;
    }

    public void BajarValor()
    {
        i--;
    }

    public void AsignarValor(int nuevoValorInt)
    {
        i = nuevoValorInt;
    }
}

public class InputValor_Bool : Input_Valor
{
    public bool b;

    //public bool nuevoValorBool;
    public override void CheckCond(Condicion c) 
    { 
    
    }

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

    public void AsignarValor(bool nuevoValorBool)
    {
        b = nuevoValorBool;
    }
}

public class InputValor_Float : Input_Valor
{
    public float f;

    //public float nuevoValorFloat;
    public override void CheckCond(Condicion c)
    {

    }

    public void SubirValor()
    {
        f++;
    }

    public void BajarValor()
    {
        f--;
    }

    public void AsignarValor(float nuevoValorFloat)
    {
        f = nuevoValorFloat;
    }

}*/