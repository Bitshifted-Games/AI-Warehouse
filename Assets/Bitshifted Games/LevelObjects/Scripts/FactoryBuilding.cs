using BitshiftedGames.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FactoryBuilding : MonoBehaviour
{
    public Vector2 factorySize;
    public LevelGrid grid;

    public GameObject tileToPlace;

    [SerializeField]
    private Dictionary<Vector3, GameObject> tileDictionary;

    private void Awake ()
    {
        if ( FindObjectOfType<LevelGrid> () != null )
            grid = FindObjectOfType<LevelGrid> ();
        else
            grid = gameObject.AddComponent<LevelGrid> ();

        if ( tileDictionary == null )
            InitializeTileDictionary ();
    }

    private void OnEnable ()
    {

    }

    // Start is called before the first frame update
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        HandleInput ();
    }

    private void HandleInput ()
    {
        if ( Input.GetMouseButtonDown ( 0 ) )
        {
            Ray ray = Camera.main.ScreenPointToRay ( Input.mousePosition );

            if ( Physics.Raycast ( ray, out RaycastHit hitInfo ) )
            {
                if ( !PlaceTileAt ( grid.GetNearestPointOnGrid ( hitInfo.point ), tileToPlace ) )
                {
                    Debug.LogError ( "TileDictionary does not contain an entry for " + hitInfo.point );
                }
            }
        }

        if ( Input.GetKeyUp ( KeyCode.L ) ) SerializeToFile ();
    }

    private void InitializeTileDictionary ()
    {
        tileDictionary = new Dictionary<Vector3, GameObject> ();
        int y = 0;
        for ( int x = 0; x < factorySize.x; x++ )
        {
            for ( int z = 0; z < factorySize.y; z++ )
            {
                tileDictionary.Add (
                    grid.GetNearestPointOnGrid ( new Vector3 ( x, y, z ) ), null );
            }
        }
    }

    public bool PlaceTileAt ( Vector3 position, GameObject tileToPlace )
    {
        Vector3 finalPosition = grid.GetNearestPointOnGrid ( position );
        GameObject go = Instantiate ( tileToPlace, finalPosition, Quaternion.identity, transform);

        if ( !tileDictionary.ContainsKey ( position ) ) return false;
        else
        {
            Destroy ( tileDictionary[position] );
            tileDictionary[position] = go;
            return true;
        }
    }

    private void SerializeToFile ()
    {
        string ser = JsonUtility.ToJson ( tileDictionary, true );
        Debug.Log ( ser );
    }
}
