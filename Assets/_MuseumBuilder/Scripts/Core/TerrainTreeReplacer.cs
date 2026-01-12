using UnityEngine;

public class TerrainTreeReplacer : MonoBehaviour
{
    [SerializeField] Transform treeParent;
    public Terrain terrain;
    public GameObject treePrefab;

    void Start()
    {
        if (terrain == null)
            terrain = Terrain.activeTerrain;

        // Runtime kopya üret
        terrain.terrainData = Instantiate(terrain.terrainData);

        ReplaceTerrainTrees();
    }

    void ReplaceTerrainTrees()
    {

        TerrainData data = terrain.terrainData;
        var trees = data.treeInstances;

        for (int i = 0; i < trees.Length; i++)
        {
            TreeInstance t = trees[i];

            // Terrain local -> world position
            Vector3 worldPos = Vector3.Scale(t.position, data.size) + terrain.transform.position;

            // Biraz yukarý al (yer içine gömülmesin)
            worldPos.y = terrain.SampleHeight(worldPos) + terrain.transform.position.y;

            // Instantiate et
            GameObject obj = Instantiate(treePrefab, worldPos, Quaternion.identity, treeParent);

            // Ýstersen rotasyon da verebilirsin
            //obj.transform.rotation = Quaternion.Euler(0, t.rotation * Mathf.Rad2Deg, 0);

            // Ýstersen scale
            obj.transform.localScale *= t.widthScale;
        }

        // Terrain'deki aðaçlarý sil
        data.treeInstances = new TreeInstance[0];
    }
}
