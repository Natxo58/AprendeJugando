using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ordenarNivelScript : MonoBehaviour
{
    public List<GameObject> objetos = new List<GameObject>();
    public List<Transform> objetosSpawn = new List<Transform>();

    public List<int> indicesUtilizados = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        ordenarRandom();
    }

    public void ordenarRandom()
    {
        for (int i = 0; i < objetos.Count; i++)
        {
            int random = Random.Range(0, objetos.Count);
            while (!indicesUtilizados.Contains(random))
            {
                random = Random.Range(0, objetos.Count);
            }

            indicesUtilizados.Remove(random);

            objetos[i].transform.position = objetosSpawn[random].transform.position;
        }
    }
}
