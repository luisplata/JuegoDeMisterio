using UnityEngine;
using System.Collections;

public class PersonajeBuilder : MonoBehaviour
{

    private Genero genero;
    private Piel piel;
    private Ropa ropa;
    [SerializeField]private Personaje pj;
    public GameObject panelFoto;

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
        var personaje = GameObject.Instantiate(pj, panelFoto.transform);
        var pil = GameObject.Instantiate(piel, personaje.transform);
        var rop = GameObject.Instantiate(ropa, personaje.transform);
        var gen = GameObject.Instantiate(genero, personaje.transform);
        personaje.SetComponents(gen, pil, rop);
        personaje.transform.localScale = new Vector3(45, 45, 0);
        rop.ColocarPosicion();
        gen.ColocarPosicion();
        personaje.SetComponents(gen, pil, rop);

        //ahora creamos el playerpref de su PJ
        PlayerPrefs.SetInt("primeraVez", 1);
        PlayerPrefs.SetString("genero", gen.name);
        PlayerPrefs.SetString("ropa", rop.name);
        PlayerPrefs.SetString("piel", pil.name);


        return personaje;
    }

}
