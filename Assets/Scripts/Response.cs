using System;
using UnityEngine;

[Serializable]
public class Response : MonoBehaviour
{
    [SerializeField]
    public string text;
    [SerializeField]
    public string[] pageTitles;
    [SerializeField]
    public string[] urls;

    public string GetText()
    {
        return text;
    }

    public int GetNumberOfLinks()
    {
        return urls.Length;
    }
}
