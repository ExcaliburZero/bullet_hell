using System.IO;
using UnityEngine;

public abstract class TestUtil
{
    public static string DataFile(string filename)
    {
        return Path.Combine(
            Application.dataPath, "Tests", "Data", filename
        );
    }
}