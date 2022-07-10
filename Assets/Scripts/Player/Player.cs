using UnityEngine;

abstract class Player
{
    public static GameObject getInstance()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }

}