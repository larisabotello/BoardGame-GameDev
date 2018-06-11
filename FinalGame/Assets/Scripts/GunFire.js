
function Update()
{
    if( Input.GetButtonDown("Fire1"))
    {
       
        //Decrease the ammo count from the gamehub
        if(GlobalAmmo.LoadedAmmo > 0)
        {
            GlobalAmmo.LoadedAmmo -= 1;

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
