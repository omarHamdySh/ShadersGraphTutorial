using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum highlightState {
    NotHighlighted,
    Highlighted
}

[RequireComponent(typeof(MeshRenderer))]
public class MeshHighlighter : MonoBehaviour
{
    private MeshRenderer renderer;
    public List<Material> originalMats;
    public List<Material> highlightMats;
    private highlightState state;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        state = highlightState.NotHighlighted;
    }

    public void toggleHighlighting()
    {
        if (highlightMats.Count != 0)
        {
            if (state == highlightState.NotHighlighted)
            {
                for (int i=0; i< renderer.materials.Length;i++)
                {
                    renderer.materials = highlightMats.ToArray();
                }
                state = highlightState.Highlighted;
            }
            else
            {
                for (int i = 0; i < renderer.materials.Length; i++)
                {
                    renderer.materials = originalMats.ToArray();
                }
                state = highlightState.NotHighlighted;
            }

        }
    }

    private void OnMouseEnter()
    {
        toggleHighlighting();
    }

    private void OnMouseExit()
    {
        toggleHighlighting();
    }
}