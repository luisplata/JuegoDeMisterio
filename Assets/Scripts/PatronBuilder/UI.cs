using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UI : MonoBehaviour
{

    public Genero masculino, femenino;
    public Piel blanca, negra;
    public Ropa azul, roja;
    public Personaje pj;
    private Personaje pjIntancia;
    private PersonajeBuilder pjb;
    public Button generoF;
    public Button generoM;
    public Button pielN;
    public Button pielB;
    public Button ropaA;
    public Button ropaR;
    public Button contruir;

    private void Awake()
    {
        pjb = new PersonajeBuilder();
        pjb.ConElPrefabs(pj);
        generoF.onClick.AddListener(GeneroFemenino);
        generoM.onClick.AddListener(GeneroMasculino);
        pielB.onClick.AddListener(PielBlanca);
        pielN.onClick.AddListener(PielNegra);
        ropaA.onClick.AddListener(RopaDeColorAzul);
        ropaR.onClick.AddListener(RopaDeColorRoja);
        contruir.onClick.AddListener(ContruirPj);
    }

    private void ContruirPj()
    {
        if(pjIntancia != null)
        {
            Destroy(pjIntancia.gameObject);
        }
        pjIntancia = pjb.Build();
    }

    private void RopaDeColorRoja()
    {
        Debug.Log("rojo");
        pjb.ConRopa(roja);
    }

    private void RopaDeColorAzul()
    {
        Debug.Log("azul");
        pjb.ConRopa(azul);
    }

    private void PielNegra()
    {
        Debug.Log("negro");
        pjb.ConPiel(negra);
    }

    private void PielBlanca()
    {
        Debug.Log("blanco");
        pjb.ConPiel(blanca);
    }

    private void GeneroMasculino()
    {
        Debug.Log("Masculino");
        pjb.ConGenero(masculino);
    }

    private void GeneroFemenino()
    {
        Debug.Log("femenino");
        pjb.ConGenero(femenino);
    }


}
