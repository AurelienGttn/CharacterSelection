using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Character
{
    public string name;
    public int age;
    public float strength;
    public float speed;
    public List<Combo> combo = new List<Combo>();

    public override string ToString()
    {
        return "name: " + name + "\tage: " + age;
    }
}

[System.Serializable]
public class Combo
{
    public string name;
    public List<string> movements = new List<string>();
}