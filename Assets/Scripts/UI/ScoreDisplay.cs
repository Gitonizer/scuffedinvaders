using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text Name;
    public Text Points;

    public void Set(string name, string points)
    {
        Name.text = name;
        Points.text = points;
    }
}
