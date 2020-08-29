using UnityEngine;
using System.Collections;

public abstract class Genero : MonoBehaviour
{
    private void Awake()
    {
        //3.27
        //0.55
        transform.position = new Vector2(3.27f, 0.55f);
    }
}
