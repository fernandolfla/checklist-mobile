package md5dd54c8733f998c802a985165695f2383;


public class FinalizaCheckActivity
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
		mono.android.Runtime.register ("CheckListMobile.Active.FinalizaCheckActivity, CheckListMobile, Version=1.0.0.35218, Culture=neutral, PublicKeyToken=null", FinalizaCheckActivity.class, __md_methods);
	}


	public FinalizaCheckActivity ()
	{
		super ();
		if (getClass () == FinalizaCheckActivity.class)
			mono.android.TypeManager.Activate ("CheckListMobile.Active.FinalizaCheckActivity, CheckListMobile, Version=1.0.0.35218, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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