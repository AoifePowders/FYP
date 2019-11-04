using UnityEngine;

//creates a capsule to follow the bat
public class BatCapsule : MonoBehaviour
{
    [SerializeField]
    private BatCapsuleFollower batCapsuleFollowerPrefab;

    private void SpawnBatCapsuleFollower()
    {
        var follower = Instantiate(batCapsuleFollowerPrefab);
        follower.transform.position = transform.position;
        follower.SetFollowTarget(this);
    }

    private void Start()
    {
        SpawnBatCapsuleFollower();
    }
}