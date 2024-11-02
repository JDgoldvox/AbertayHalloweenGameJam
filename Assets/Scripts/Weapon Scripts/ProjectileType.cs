using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileType", menuName = "ProjectileType")]
public class ProjectileType : ScriptableObject
{
    public float speed;
    public float damage;
    public float despawnTime;
    public Vector3 rotation;
    public Mesh projectileMesh;
    public Material projectileMaterial;
}
