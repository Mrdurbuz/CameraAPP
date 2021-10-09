using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAnimation : MonoBehaviour
{
    public GameObject[] references;

    bool canMove;
    bool eduNoSabe;
    public bool muevete = true;
    int rango;
    int rambo;
    public float speed;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Walk", false);
    
        rango = Random.Range(0, 3);  // de 0 a 2
        StartCoroutine("MoveChicken");
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (canMove)
        {
            anim.SetBool("Iddle", true);
           
            print(rango);
            transform.position = Vector3.MoveTowards(transform.position, references[rango].transform.position, speed * Time.deltaTime);
            if (eduNoSabe) 
            {
              
                StartCoroutine("MoveChicken"); // Forma convencional de empezar la corrutina
            }
        }*/
    }

    IEnumerator MoveChicken()
    {
        while (muevete == true)
        {
           
            

            float cont = 0;
            while (cont < 2)
            {
                yield return new WaitForFixedUpdate();
                cont += Time.fixedDeltaTime;
                anim.SetBool("Iddle", false);
                anim.SetBool("Walk", true);
                //mover
                transform.position = Vector3.MoveTowards(transform.position, references[rango].transform.position, speed * Time.fixedDeltaTime);
            }
            // yield return new WaitForSeconds(2.0f);
            canMove = false;

            anim.SetBool("Walk", false);
            anim.SetBool("Iddle", true);
            yield return new WaitForSeconds(2);
            rambo = rango;

            while (rambo == rango)
            {
                rango = Random.Range(0, 3); // de 0 a 2
                transform.LookAt(references[rango].transform); 
            }
        }  
    }
}
