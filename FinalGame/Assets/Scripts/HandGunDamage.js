var DamageAmount : int = 5;
var TargetDistance : float;
var AllowedRange : float =15;

function Update()
{
    // enters once the  fire button is pressed on player
    if(Input.GetButtonDown("Fire1"))
    {
        // before inflicting damage on opponent we check for ammo first
        if(GlobalAmmo.LoadedAmmo > 0 )
        {
            var Shot : RaycastHit;
            if(Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward),Shot))
            {
                TargetDistance = Shot.distance;
                if(TargetDistance < AllowedRange)
                {
                    Shot.transform.SendMessage("DeductPoints", DamageAmount );
                }
            }
        }
        
    }
}