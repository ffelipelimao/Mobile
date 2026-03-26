using UnityEngine;

public class PowerUpInvincible : PowerUpBase
{
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetPowerUpText("Invencible");
        PlayerController.Instance.SetInvincible(true);
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetInvincible(false);
        PlayerController.Instance.SetPowerUpText("");
    }
}
