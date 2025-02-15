using UnityEngine;

public class DesertScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateGround();
        CreateForest();
        CreatePyramid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateGround()
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        Renderer renderer = plane.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        renderer.material.color = Color.red;
    }

    void CreateForest()
    {
        GameObject forestParent = new GameObject("ForestParent");

        for (int i = 0; i < 12; i++)
        {
            GameObject tree = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            tree.transform.parent = forestParent.transform;

            Renderer treeRenderer = tree.GetComponent<Renderer>();
            treeRenderer.material = new Material(Shader.Find("Universal Render Pipeline/Lit"));

            float scaleX = UnityEngine.Random.Range(0.2f, 1.5f);
            float scaleY = UnityEngine.Random.Range(0.2f, 1.5f);
            float scaleZ = UnityEngine.Random.Range(0.2f, 1.5f);
            tree.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);

            float positionX = UnityEngine.Random.Range(-3.5f, -0.5f);
            float positionZ = UnityEngine.Random.Range(-1.35f, 2f);
            tree.transform.position = new Vector3(positionX, 0, positionZ);

            int treeColor = UnityEngine.Random.Range(1, 4);
            if(treeColor == 1)
            {
                treeRenderer.material.color = Color.green;
            }

            else if(treeColor == 2)
            {
                treeRenderer.material.color = new Color(0f, 0.5f, 0f);
            }

            else if (treeColor == 3)
            {
                treeRenderer.material.color = new Color(0.05f, 0.25f, 0.05f);
            }
        }
    }

    void CreatePyramid()
    {
        Vector3 pyrPosition = new Vector3(2.5f, 0.5f, 0.5f);

        GameObject pyramidParent = new GameObject("PyramidParent");

        for (int i = 0; i < 5; i++)
        {
            int currentSize = 5 - i;

            Color colorOfLevel = new Color(Random.value, Random.value, Random.value);

            for (int x = 0; x < currentSize; x++)
            {
                for (int z = 0; z < currentSize; z++)
                {
                    Vector3 blockPosition = new Vector3(pyrPosition.x + x - (5 - 1) / 2f + i * 0.5f, pyrPosition.y + i, pyrPosition.z + z - (5 - 1) / 2f + i * 0.5f); //this somehow works... i'm not gonna question it it took me forever

                    GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    block.transform.position = blockPosition;
                    block.transform.localScale = new Vector3(0.9f,0.9f,0.9f);
                    block.transform.parent = pyramidParent.transform;

                    Renderer blockRenderer = block.GetComponent<Renderer>();
                    blockRenderer.material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
                    blockRenderer.material.color = colorOfLevel;
                }

            }
        }
    }
}
