package md54d54a08df3559270e1bbbd457e2b9a41;


public class CheckListActivity
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
		mono.android.Runtime.register ("CheckListMobile.Active.CheckListActivity, CheckListMobile, Version=1.0.0.8539, Culture=neutral, PublicKeyToken=null", CheckListActivity.class, __md_methods);
	}


	public CheckListActivity ()
	{
		super ();
		if (getClass () == CheckListActivity.class)
			mono.android.TypeManager.Activate ("CheckListMobile.Active.CheckListActivity, CheckListMobile, Version=1.0.0.8539, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
