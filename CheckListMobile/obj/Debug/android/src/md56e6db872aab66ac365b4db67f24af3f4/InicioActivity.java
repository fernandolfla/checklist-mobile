package md56e6db872aab66ac365b4db67f24af3f4;


public class InicioActivity
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
		mono.android.Runtime.register ("CheckListMobile.Active.InicioActivity, CheckListMobile, Version=1.0.0.3339, Culture=neutral, PublicKeyToken=null", InicioActivity.class, __md_methods);
	}


	public InicioActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == InicioActivity.class)
			mono.android.TypeManager.Activate ("CheckListMobile.Active.InicioActivity, CheckListMobile, Version=1.0.0.3339, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
