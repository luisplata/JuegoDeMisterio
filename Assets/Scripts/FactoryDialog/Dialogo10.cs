using System.Collections.Generic;

public class Dialogo10 : Dialogo
{

    private void Awake()
    {
        dialogo = new List<string>();
        dialogo.Add(DIALOGO1);
        dialogo.Add(DIALOGO2);
        dialogo.Add(DIALOGO3);
        dialogo.Add(DIALOGO4);
        dialogo.Add(DIALOGO5);
        dialogo.Add(DIALOGO6);
    }

    public override void Opcion1(ref PersonajeBuilder factoriaDeDialogos)
    {
        throw new System.NotImplementedException();
    }

    public override void Opcion2(ref PersonajeBuilder factoriaDeDialogos)
    {
        throw new System.NotImplementedException();
    }


    //Constantes de los dialogos
    public const string DIALOGO1 = "La noche parece fría, pero mi carne no lo sabe. No siento nada desde hace ya mucho tiempo.";
    public const string DIALOGO2 = "He vivido asi por mucho tiempo, su compañia siempre le a dado sentido a esta existencia de inmortal.";
    public const string DIALOGO3 = "Algo andaba mal, no me a llamado desde hace días, solo se que fue a un bar... ese bar que se encuentra en la esquina de su casa. Siempre a sido su vicio, no lo acepto, pero me gusta esa parte.";
    public const string DIALOGO4 = "No me queda alternativa mas que buscar... y saber en que lío se encuentra.";
    public const string DIALOGO5 = "Salgo esta noche como siempre lo tengo que hacer, porque la luz del día me mataría...";
    public const string DIALOGO6 = "Buscare en ese bar y hasta que no le abraze no descansare.";
}
