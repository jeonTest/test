using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Reflection;

public class ExtraReward : MonoBehaviour
{
    public bool playerNear = false;
    public float interactDist = 5;
    public PlayerInput Input;
    public ParticleSystem glitter;

    [DropDown(nameof(IDs))] [SerializeField] public int SelectedIDOnCompletion;
    [HideInInspector] public List<string> IDs;

    public GameObject rewardScreen;
    public GameObject itemIcon;

    public void Update()
    {
        distanceToPlayer();        
    }

    public void distanceToPlayer()
    {
        Transform playerObj = GameObject.FindWithTag("Player").transform;
        float dist = Vector3.Distance(playerObj.position, transform.position);

        if (dist <= interactDist)
        {
            playerNear = true;
        }
        else
        {
            playerNear = false;
        }
    }

    private void OnInteract()
    {
        if(playerNear == true)
        {
            ModuleManager.GetModule<SaveGameManager>().SetCompletionInfo(IDs[SelectedIDOnCompletion], true);
            Destroy(glitter);
            rewardScreen.SetActive(true);
            itemIcon.SetActive(true);
        }
    }

    private void OnValidate()
    {
        if (IDs == null)
        {
            IDs = new List<string>();
        }
        else IDs.Clear();
        foreach (FieldInfo field in typeof(CompletionIDs).GetFields())
        {
            string value = (string)field.GetValue(null);
            IDs.Add(value);
        }
    }


}
