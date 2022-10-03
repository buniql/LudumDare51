using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Objects/Skill")]
public class Skills : ScriptableObject
{
    [SerializeField] int costs;
    [SerializeField] Stats stat;

    public int Costs { get { return costs; } }
    public Stats Stat { get { return stat; } }

    public override string ToString()
    {
        string cache = $"Costs: {Costs} HP\n\n";

        foreach (var value in Stat.GetType().GetProperties())
        {
            if (value.Name == "Health")
                continue;

            var statValue = value.GetValue(Stat);

            if (statValue is int)
            {
                if ((int)statValue != 0)
                {
                    var str = (int)statValue < 0 ? ((int)statValue).ToString() : "+" + (int)statValue;
                    cache += $"{value.Name}: {str}\n";
                }
            }
            else if (statValue is float)
            {
                if ((float)statValue != 0)
                {
                    var str = (float)statValue < 0 ? ((float)statValue).ToString() : "+" + (float)statValue;
                    cache += $"{value.Name}: {str}\n";
                }
            }
            else if (statValue is GameObject)
            {
                if ((GameObject)statValue != null)
                    cache += $"{value.Name}: {((GameObject)statValue).name}\n";
            }
            else
                Debug.Log("Type: " + statValue.GetType() + " not registered");
        }

        return cache.Substring(0, cache.Length - 1);
    }
}
