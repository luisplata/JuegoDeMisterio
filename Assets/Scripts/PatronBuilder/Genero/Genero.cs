using UnityEngine;
using System.Collections;

public abstract class Genero : MonoBehaviour
{
    public void ColocarPosicion()
    {
        //3.27
        //0.55
        transform.localPosition = new Vector2(0, 0.55f);
    }
}
