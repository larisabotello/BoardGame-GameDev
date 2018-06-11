
function Update()
{
    if( Input.GetButtonDown("Fire2"))
    {
       
        //Decrease the ammo count from the gamehub
        if(Global2Ammo.LoadedAmmo > 0)
        {
            Global2Ammo.LoadedAmmo -= 1;

            // sound for the gun
            var gunsound : AudioSource = GetComponent.<AudioSource>();
            gunsound.Play();

            //Gun animation
            GetComponent.<Animation>().Play("GunShot");
        }
        else 
        {
            //do nothing

        }

    }
}
