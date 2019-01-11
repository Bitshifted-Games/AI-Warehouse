using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BitshiftedGames.AiWarehouse.CargoSystem
{
    [System.Serializable]
    public struct CargoDimensions
    {
        [SerializeField] private ushort width;
        [SerializeField] private ushort length;
        [SerializeField] private ushort height;

        public ushort Width
        {
            get { return width; }
            set { width = value; }
        }
        public ushort Length
        {
            get { return length; }
            set { length = value; }
        }
        public ushort Height
        {
            get { return height; }
            set { height = value; }
        }

        #region Constructors
        public CargoDimensions ( int width, int length, int height ) : this ()
        {
            Width = width.AsUshort();
            Length = length.AsUshort ();
            Height = height.AsUshort ();
        }

        public CargoDimensions ( float width, float length, float height ) : this ()
        {
            Width = width.AsUshort ( );
            Length = length.AsUshort( );
            Height = height.AsUshort (  );
        }

        public CargoDimensions ( ushort width, ushort length, ushort height ) : this ()
        {
            Width = width;
            Length = length;
            Height = height;
        }
        #endregion
    }

    public static class CargoDimensions_Extensions
    {
        /// <summary>
        /// Allows converting a Vector3 into CargoDimensions
        /// </summary>
        /// <param name="v3">Vector3 to convert into CargoDimensions</param>
        /// <returns></returns>
        public static CargoDimensions ToCargoDimensions(this Vector3 v3)
        {
            return new CargoDimensions ( v3.x.AsUshort (), v3.y.AsUshort (), v3.z.AsUshort () );
        }
    }
}

