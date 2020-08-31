using UnityEngine;
using System.Collections.Generic;

public abstract class Dialogo : MonoBehaviour
{
    [SerializeField] string id;
    protected List<string> dialogo;
    public ControladorDeDialogos referencia;

    public string Id { set { id = value; } get { return id; } }
    public List<string> Dialogos { get { return dialogo; } }

    public abstract void Opcion1(ref PersonajeBuilder factoriaDeDialogos);
    public abstract void Opcion2(ref PersonajeBuilder factoriaDeDialogos);
}
