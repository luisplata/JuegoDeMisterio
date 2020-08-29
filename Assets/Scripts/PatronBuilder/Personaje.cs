using UnityEngine;
using System.Collections;

public class Personaje : MonoBehaviour
{
    private Genero genero;
    private Piel piel;
    private Ropa ropa;

    public void SetComponents(Genero g, Piel p, Ropa r)
    {
        genero = g;
        piel = p;
        ropa = r;
    }
}
