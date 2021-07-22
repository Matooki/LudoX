using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Steamworks;
using Mirror;

public class PlayerInfoDisplay : NetworkBehaviour
{
    [SyncVar(hook = nameof(HandleSteamIdUpdated))]
    private ulong steamId;
    [SerializeField] private RawImage profileImage = null;
    [SerializeField] private TMP_Text displayNameText = null;

    protected Callback<AvatarImageLoaded_t> avatarImageLoaded;

    public void SetSteamId(ulong steamId)
    {
        this.steamId = steamId;
    }
    private void HandleSteamIdUpdated(ulong oldSteamId, ulong newSteamId)
    {
        var cSteamId = new CSteamID(newSteamId);

        displayNameText.text = SteamFriends.GetFriendPersonaName(cSteamId);

        int imageId = SteamFriends.GetLargeFriendAvatar(cSteamId);

        if (imageId == -1)
        {
            return;
        }

        profileImage.texture = GetSteamImageAsTexture(imageId);


    }

    public override void OnStartClient()
    {
        avatarImageLoaded = Callback<AvatarImageLoaded_t>.Create(OnAvatarImageLoaded);
    }

    private Texture2D GetSteamImageAsTexture(int iImage)
    {
        Texture2D texture = null;

        bool isValid = SteamUtils.GetImageSize(iImage, out uint width, out uint height);

        if (isValid)
        {
            byte[] image = new byte [width * height * 4];

            isValid = SteamUtils.GetImageRGBA(iImage, image, (int)(width * height * 4));

            if (isValid)
            {
                texture = new Texture2D((int)width, (int)height, TextureFormat.RGBA32, false, true);
                texture.LoadRawTextureData(image);
                texture.Apply();
            }
        }

        return texture;
    }

    private void OnAvatarImageLoaded(AvatarImageLoaded_t callback)
    {
        if(callback.m_steamID.m_SteamID == steamId)
        {
            return;
        }
        profileImage.texture = GetSteamImageAsTexture(callback.m_iImage);
    }

}
