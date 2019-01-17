using UnityEngine;

namespace BitshiftedGames.Utility
{
    public class LevelGrid : MonoBehaviour
    {
        [SerializeField] Vector2 gridSize = new Vector2 ( 100, 60 );
        [SerializeField] private float size = 1f;

        public Vector3 GetNearestPointOnGrid ( Vector3 position )
        {
            position -= transform.position;

            int xCount = Mathf.RoundToInt ( position.x / size );
            int yCount = Mathf.RoundToInt ( position.y / size );
            int zCount = Mathf.RoundToInt ( position.z / size );

            Vector3 result = new Vector3 (
                xCount * size,
                yCount * size,
                zCount * size );

            result += transform.position;

            return result;
        }

        private void OnDrawGizmos ()
        {
            Gizmos.color = Color.yellow;
            for ( float x = 0; x < gridSize.x; x += size )
            {
                for ( float z = 0; z < gridSize.y; z += size )
                {
                    var point = GetNearestPointOnGrid ( new Vector3 ( x, 0f, z ) );
                    Gizmos.DrawSphere ( point, 0.1f );
                }

            }
        }
    }
}