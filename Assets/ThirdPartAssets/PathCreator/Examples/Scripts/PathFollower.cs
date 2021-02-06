using System.Collections.Generic;
using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public List<PathCreator> pathCreatorList;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = .25f;
        [HideInInspector]
        public PathCreator pathCreator;
        float distanceTravelled;

        void Start()
        {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathCreator != null && LevelManager.Instance.IsLevelStarted)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = new Quaternion (0f, pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction).y , 0f , pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction).w);
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}