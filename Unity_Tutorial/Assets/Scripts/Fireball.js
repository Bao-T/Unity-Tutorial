var hasClicked = false;
function Update () {
	var fireballsound : AudioSource = GetComponent.<AudioSource>();
	var anim: Animation;
	var chargeTime = 10;
	var counter = 0;
	anim = GetComponent.<Animation>();
	//animates staff
		// play staff animation with left mouse button
	if(Input.GetMouseButtonDown(0) && !anim.IsPlaying("ECast")) {
		anim.Play("BCast");
		hasClicked = true;	
	}
	//stops staff animation
	else if(Input.GetMouseButtonUp(0) && !anim.IsPlaying("BCast"))
	{
	 hasClicked=false;
	 anim.Play("ECast");
	}

	// play staff animation with right mouse button
	if(Input.GetMouseButtonDown(1) && !anim.IsPlaying("ECast")) {
		anim.Play("BCast");
		hasClicked = true;	
	}
	//stops staff animation
	else if(Input.GetMouseButtonUp(1) && !anim.IsPlaying("BCast"))
	{
	 hasClicked=false;
	 anim.Play("ECast");
	}

	

	
}