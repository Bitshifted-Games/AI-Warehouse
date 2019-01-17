using UnityEngine;

namespace BitshiftedGames.Utility
{
    public class ObjectPlacer : MonoBehaviour
    {
        private LevelGrid grid;

        public GameObject objectToPlace;

        private void Awake ()
        {
            grid = FindObjectOfType<LevelGrid> ();
        }

        private void Update ()
        {
            if ( Input.GetMouseButtonDown ( 0 ) )
            {
                Ray ray = Camera.main.ScreenPointToRay ( Input.mousePosition );

                if ( Physics.Raycast ( ray, out RaycastHit hitInfo ) )
                {
                    PlaceCubeNear ( hitInfo.point );
                }
            }
        }

        private void PlaceCubeNear ( Vector3 clickPoint )
        {
            Debug.Log ( "Placing object" );
            var finalPosition = grid.GetNearestPointOnGrid ( clickPoint );
            GameObject go = Instantiate ( objectToPlace, finalPosition, Quaternion.identity, grid.transform.parent );
            //GameObject.CreatePrimitive ( PrimitiveType.Cube ).transform.position = finalPosition;

            //GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = nearPoint;
        }
    }
}