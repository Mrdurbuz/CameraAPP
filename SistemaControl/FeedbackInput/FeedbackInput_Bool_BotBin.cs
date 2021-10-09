using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackInput_Bool_BotBin : FeedbackInput
{
    //Variable de referencia del objeto que queremos mover.
    public GameObject objRefresFeedback;

    //Posiciones para movimiento del objeto, desplazamiento y punto final.
    public Vector3 posInicial;
    public Vector3 desplazamiento;
    public Vector3 posFinal;

    private void Start()
    {
        //Inicializamos la posicion inicial del objeto.
        posInicial = objRefresFeedback.transform.localPosition;
        posFinal = posInicial + desplazamiento;
    }

    //Metodo que sobreescribe al metodo RefrescarFeedback en "FeedbackInput"
    public override void RefrescarFeedback()
    {
        //Condicion, en funcion del resultado de la booleana de InputValor_Bool el objeto adoptara una u otra posicion.
        if (GetComponent<InputValor_Bool>().b == true)
        {
            objRefresFeedback.transform.localPosition += desplazamiento;

        }
        else if (GetComponent<InputValor_Bool>().b == false)
        {
            objRefresFeedback.transform.localPosition -= desplazamiento;
        }
    }
}