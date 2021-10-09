using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbaackInput_Bool : FeedbackInput
{
    //variable para guardar componente en caso de que lo encuentre.
    InputValor_Bool inputValorScript;

    private void Start()
    {
        //Buscará el componente InputValor_Bool, en caso de encontrarlo, lo guardará.
        inputValorScript = GetComponent<InputValor_Bool>();     
    }
}