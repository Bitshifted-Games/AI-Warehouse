using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BitshiftedGames.FactoryManager
{
    [System.Serializable]
    public class CargoContainer : MonoBehaviour
    {
        [SerializeField] private float containerWeight;
        [SerializeField] private float containerCapacity;
        [SerializeField] private Vector3 containerDimensions;

        public float Weight
        {
            get { return containerWeight; }
            set { containerWeight = value; }
        }
        public float Capacity
        {
            get { return containerCapacity; }
            set { containerCapacity = value; }
        }
        public Vector3 Dimensions
        {
            get { return containerDimensions; }
            set { containerDimensions = value; }
        }

        // Start is called before the first frame update
        void Start ()
        {

        }

        // Update is called once per frame
        void Update ()
        {

        }
    }
}