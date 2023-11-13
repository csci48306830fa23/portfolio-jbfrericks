//using ReadyPlayerMe.AvatarLoader;
using ReadyPlayerMe.Core;
using UnityEngine;

public class TestAvatarLoader : MonoBehaviour
{
    [SerializeField, Tooltip("Set this to the URL or shortcode of the Ready Player Me Avatar you want to load.")]
    private string avatarUrl = "https://models.readyplayer.me/65427fcb07229b85ca8291dd.glb";

    private GameObject avatar;
    
    [SerializeField] private RuntimeAnimatorController masculineController;
    [SerializeField] private RuntimeAnimatorController feminineController;

    private void Start()
    {
        ApplicationData.Log();
        var avatarLoader = new AvatarObjectLoader();
        
        avatarLoader.OnCompleted += (_, args) =>
        {
            avatar = args.Avatar;
            avatar.transform.position = transform.position;
            MeshCollider meshCollider = avatar.AddComponent<MeshCollider>();
           
            
            meshCollider.convex = true;
            BoxCollider boxCollider = avatar.AddComponent<BoxCollider>();
            boxCollider.size = new Vector3(0.8f, 4, 0.8f);
            boxCollider.isTrigger = true;
            avatar.tag = "Enemy";
            SetAnimatorController(args.Metadata.OutfitGender); //  <--------------- ADDED
        };
        avatarLoader.LoadAvatar(avatarUrl);
    }


    private void SetAnimatorController(OutfitGender outfitGender)
    {
        var animator = avatar.GetComponent<Animator>();
        if (animator != null && outfitGender == OutfitGender.Masculine)
        {
            animator.runtimeAnimatorController = masculineController;
        }
        else
        {
            animator.runtimeAnimatorController = feminineController;
        }
    }

    private void OnDestroy()
    {
        if (avatar != null) Destroy(avatar);
    }
}