using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #pragma warning disable 649
    [SerializeField] private GameObject ballPrefab;
    #pragma warning restore 649
    [SerializeField] private Vector3 ballPosition = Vector3.zero;

    private EntityManager entityManager;
    private BlobAssetStore blobAssetStore;
    
    private Entity ballEntity;

    private void Awake()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        blobAssetStore = new BlobAssetStore();

        var entityConversionSettings = GameObjectConversionSettings.FromWorld(
            World.DefaultGameObjectInjectionWorld, 
            blobAssetStore);
        ballEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(ballPrefab, entityConversionSettings);
    }

    private void OnDisable()
    {
        blobAssetStore.Dispose();
    }

    private void Start()
    {
        SpawnBall();
    }

    public void SpawnBall()
    {
        var ball = entityManager.Instantiate(ballEntity);
        
        var translation = new Translation()
        {
            Value = new float3(
                ballPosition.x,
                ballPosition.y,
                ballPosition.z)
        };

        entityManager.AddComponentData(ball, translation);
    }
}