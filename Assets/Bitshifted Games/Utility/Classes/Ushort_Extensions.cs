using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Ushort_Extensions
{
    public static ushort AsUshort (this float toConvert)
    {
        return 
            (ushort)Mathf.Lerp ( float.MinValue, float.MaxValue, toConvert );
    }
    public static ushort AsUshort (this int toConvert )
    {
        return
            (ushort)Mathf.Lerp ( int.MinValue, int.MaxValue, toConvert );
    }
}
