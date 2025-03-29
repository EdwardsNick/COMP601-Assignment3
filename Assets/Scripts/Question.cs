using System;
using UnityEngine;

[Serializable]
public class Question : MonoBehaviour
{
    public enum ResponseType
    {
        YES, NO, IDK, NA
    };

    [SerializeField]
    public string questionText;
    [SerializeField]
    public ResponseType responseType;
    [SerializeField]
    public Response[] positiveResponses;
    [SerializeField]
    public Response[] negativeResponses;
    [SerializeField]
    public Response[] idkResponses;
    [SerializeField]
    public int positiveResponseIndex;
    [SerializeField]
    public int negativeResponseIndex;
    [SerializeField]
    public int idkResponseIndex;

    public bool hasMoreResponses()
    {
        switch (responseType)
        {
            case ResponseType.YES:
                if (positiveResponseIndex < positiveResponses.Length - 1) return true;
                else return false;
            case ResponseType.NO:
                if (negativeResponseIndex < negativeResponses.Length - 1) return true;
                else return false;
            case ResponseType.IDK:
                if (idkResponseIndex < idkResponses.Length - 1) return true;
                else return false;
            default: return false;
        }
    }
}
