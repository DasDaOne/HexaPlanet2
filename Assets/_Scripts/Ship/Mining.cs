using UnityEngine;

public class Mining : MonoBehaviour
{
    [SerializeField] private HoldButton miningButton;
    [SerializeField] private float overlapSphereRadius;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private ParticleSystem miningParticles;

    private PlacedResource nearestResource;

    private bool isMining;
    
    private Collider[] nearResources = new Collider[7];

    private float miningTimer;

    private void FixedUpdate()
    {
        nearestResource = null;
        int nearResourcesLength = Physics.OverlapSphereNonAlloc(transform.position, overlapSphereRadius, nearResources, layerMask);
        miningButton.gameObject.SetActive(nearResourcesLength > 0);
        for (int i = 0; i < nearResourcesLength; i++)
        {
            if (!nearestResource ||
                (transform.position - nearResources[i].transform.position).magnitude <
                 (transform.position - nearestResource.transform.position).magnitude)
            {
                nearestResource = nearResources[i].GetComponent<PlacedResource>();
            }
        }
        
        if (isMining)
        {
            miningTimer -= Time.fixedDeltaTime;
            if (miningTimer <= 0)
            {
                nearestResource.Mine();
                miningTimer = nearestResource.timeToMine;
            }
        }
    }

    private void Update()
    {
        if (isMining)
        {
            miningParticles.transform.LookAt(nearestResource.transform.position);
        }
    }

    public void StartMining()
    {
        isMining = true;
        miningParticles.Play();

        miningTimer = nearestResource.timeToMine;
    }
    
    public void StopMining()
    {
        isMining = false;
        miningParticles.Clear();
        miningParticles.Stop();
    }
}
