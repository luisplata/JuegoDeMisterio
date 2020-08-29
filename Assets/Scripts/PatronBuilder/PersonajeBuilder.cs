using UnityEngine;
using System.Collections;

public class PersonajeBuilder : MonoBehaviour
{

    private Genero genero;
    private Piel piel;
    private Ropa ropa;
    private Personaje pj;

    public PersonajeBuilder ConGenero(Genero g)
    {
        genero = g;
        return this;
    }

    public PersonajeBuilder ConPiel(Piel p)
    {
        piel = p;
        return this;
    }

    public PersonajeBuilder ConRopa(Ropa r)
    {
        ropa = r;
        return this;
    }

    public PersonajeBuilder ConElPrefabs(Personaje p)
    {
        pj = p;
        return this;
    }

    public Personaje Build()
    {
        var personaje = GameObject.Instantiate(pj);
        var gen = GameObject.Instantiate(genero,personaje.transform);
        var rop = GameObject.Instantiate(ropa, personaje.transform);
        var pil = GameObject.Instantiate(piel, personaje.transform);
        personaje.SetComponents(gen, pil, rop);
        return personaje;
    }

}
