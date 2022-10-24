using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{

    [SerializeField] private GameObject branch;
    [SerializeField] int nodes;
    int currentNode = 0;

    Queue<GameObject> Log = new Queue<GameObject>();
    Queue<GameObject> createdBranches = new Queue<GameObject>();


    private void Start()
    {
        GameObject root = Instantiate(branch, transform);
        root.name = "Root Branch";
        Log.Enqueue(root);
        ProcedureTree();
    }


    private void ProcedureTree()
    {
        if (currentNode >= nodes) return;
        currentNode++;

        while (Log.Count > 0)
        {

            var branch = Log.Dequeue();

            var branchToLeft = CreateBranch(branch, Random.Range(15f, 40f));
            var branchToRight = CreateBranch(branch, -Random.Range(15f, 40f));

            createdBranches.Enqueue(branchToLeft);
            createdBranches.Enqueue(branchToRight);

        }

        int branches = createdBranches.Count;

        for (int i = 0; i < branches; i++)
        {
            Log.Enqueue(createdBranches.Dequeue());
        }

        ProcedureTree();
    }


    private GameObject CreateBranch(GameObject lastBranch, float offset)
    {

        GameObject newBranch = Instantiate(branch, transform);
        newBranch.transform.position = lastBranch.transform.position + lastBranch.transform.up;
        Quaternion branchRotation = lastBranch.transform.rotation;
        newBranch.transform.rotation = branchRotation * Quaternion.Euler(0f, 0f, offset);

        return newBranch;
    }
}
