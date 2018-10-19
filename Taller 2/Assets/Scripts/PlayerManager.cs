using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            return instance;
        }
    }

    public SkinnedMeshRenderer[] SkinnedMeshRenderer
    {
        get
        {
            return skinnedMeshRenderer;
        }

        set
        {
            skinnedMeshRenderer = value;
        }
    }

    public GameObject player;

    SkinnedMeshRenderer[] skinnedMeshRenderer;

    void Awake () {
        instance = this;
        skinnedMeshRenderer = player.GetComponentsInChildren<SkinnedMeshRenderer>();
	}
}
