using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanteCube : MonoBehaviour
{

    [SerializeField] private GameObject cubeInstance;
    // Start is called before the first frame update
    void Start()
    {
        //Instante();
        StartCoroutine(CreateCube());
    }

    IEnumerator CreateCube()
    {
        while (cubeInstance!=null)
        {
            Instante();
            yield return new WaitForSeconds(6);
        }
    }

    void Instante()
    {
        Instantiate(cubeInstance,transform.position,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
