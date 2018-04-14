package md5785a0dfa0b1ee42e7c2c0c53489b4200;


public class CheckChavesActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("CheckListMobile.Active.CheckChavesActivity, CheckListMobile, Version=1.0.0.7946, Culture=neutral, PublicKeyToken=null", CheckChavesActivity.class, __md_methods);
	}


	public CheckChavesActivity ()
	{
		super ();
		if (getClass () == CheckChavesActivity.class)
			mono.android.TypeManager.Activate ("CheckListMobile.Active.CheckChavesActivity, CheckListMobile, Version=1.0.0.7946, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
