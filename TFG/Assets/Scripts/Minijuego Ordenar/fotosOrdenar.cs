using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fotosOrdenar : MonoBehaviour
{
    [Header("Fotos Atributes")]
    public GameObject[] fotos;
    public Sprite[] sprites;

    private List<int> indicesAñadidos = new List<int>();

    // Start is called before the first frame update
    void Awake()
    {
        randomizarFotos();
    }

    public void randomizarFotos()
    {
        indicesAñadidos.Clear();

        for (int i = 0; i < fotos.Length; i++)
        {
            int random = Random.Range(0, fotos.Length);
            while (indicesAñadidos.Contains(random))
            {
                random = Random.Range(0, fotos.Length);
            }

            fotos[i].GetComponent<FotosScript>().setSprite(sprites[random]);
            fotos[i].GetComponent<FotosScript>().orden = random;
            indicesAñadidos.Add(random);
        }
    }
}
