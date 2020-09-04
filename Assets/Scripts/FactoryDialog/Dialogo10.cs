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
        dialogo.Add(DIALOGO7);
        dialogo.Add(DIALOGO8);
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
    public const string DIALOGO1 = "La noche parece fría, pero mi carne no lo sabe, hace ya muchos siglos no siento el frío... Ni nada... ";
    public const string DIALOGO2 = "Solo su compañía le ha dado sentido a mi inmortal exsistencia.";
    public const string DIALOGO3 = "He vivido así por mucho tiempo, su compañía siempre le a dado sentido a esta existencia de inmortal. Aún recuerdo el día en el que recibí mi abrazo.";
    public const string DIALOGO4 = "Aquel día fue en el que nos conocimos, y desde entonces no nos hemos separado, pero hace ya 3 días que no aparece y me estoy comenzando a impacientar";
    public const string DIALOGO5 = "Supongo que debería ir a ese bar medieval que tanto le gusta, allí suele pasar noches enteras recordando viejos tiempos...";
    public const string DIALOGO6 = "Vas caminando por las calles tomadas por la modernidad de una vieja ciudad feudal, te sentís a la vez ajeno al mundo y dueño del mismo.";
    public const string DIALOGO7 = "Llegas a las puertas de un viejo bar construido en piedra, con ventanas de colores y marcos de madera muy vieja.";
    public const string DIALOGO8 = "Notás como desentona la puerta de un material moderno con todo el ambiente pero intentas, como cada vez que vas, ignorarlo para creer que estás en tu época.";
}
