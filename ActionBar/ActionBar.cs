using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Widget;
using Android.Views;
using Android.Util;
using Android.OS;
using Android.Content;
using Android;

namespace ActionBar
{
	public class ActionBar : RelativeLayout, View.IOnClickListener
	{
		private LayoutInflater mInflater;
		private RelativeLayout mBarView;
		private ImageView mLogoView;
		private View mBackIndicator;
		//private View mHomeView;
		private TextView mTitleView;
		private LinearLayout mActionsView;
		private ImageButton mHomeBtn;
		private RelativeLayout mHomeLayout;
		private ProgressBar mProgress;


		public ActionBar(Context context, IAttributeSet attrs):base(context,attrs)
		{
			//base.(bundle, attrs);
		   
			mInflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);

			mBarView = (RelativeLayout)mInflater.Inflate(Resource.Layout.ActionBar, null);

			this.AddView(mBarView);

			mLogoView = (ImageView)mBarView.FindViewById(Resource.Id.actionbar_home_logo);

			
			mHomeLayout = (RelativeLayout)mBarView.FindViewById(Resource.Id.actionbar_home_bg);
			mHomeBtn = (ImageButton)mBarView.FindViewById(Resource.Id.actionbar_home_btn);
			mBackIndicator = mBarView.FindViewById(Resource.Id.actionbar_home_is_back);

			mTitleView = (TextView)mBarView.FindViewById(Resource.Id.actionbar_title);
			mActionsView = (LinearLayout)mBarView.FindViewById(Resource.Id.actionbar_actions);

			mProgress = (ProgressBar)mBarView.FindViewById(Resource.Id.actionbar_progress);

			var a = context.ObtainStyledAttributes(attrs,Resource.Styleable.ActionBar);
			string title = a.GetString(Resource.Styleable.ActionBar_title);
			if (title != null)
			{
				this.SetTitle(title);
				//setTitle(title);
			}
			
			a.Recycle();
		}
		//TODO: PICKUP HERE
		public void setHomeAction(Intent action)
		{
			
			mHomeBtn.SetOnClickListener(this);
			mHomeBtn.SetTag(action.Action);
			mHomeBtn.SetImageResource(Resource.Drawable.actionbar_btn);
			mHomeLayout.Visibility = 2;
			mHomeLayout.SetVisibility(View.VISIBLE);
		}

		public void clearHomeAction()
		{
			mHomeLayout.setVisibility(View.GONE);
		}

		public void OnClick(View v)
		{
			throw new NotImplementedException();
		}

		public IntPtr Handle
		{
			get { throw new NotImplementedException(); }
		}




	}
	/**
	 * A {@link LinkedList} that holds a list of {@link Action}s.
	 */
	public static class ActionList:IEnumerable<Action> {
	}

	/**
	 * Definition of an action that could be performed, along with a icon to
	 * show.
	 */
	public interface Action {
		public int GetDrawable();
		public virtual void PerformAction(View view);
	}

	public static abstract class BaseAction : Action {
		private int mDrawable;

		public BaseAction(int drawable) {
			mDrawable = drawable;
		}

		
		public int getDrawable() {
			return mDrawable;
		}
	}

	public static class IntentAction :BaseAction {
		private Context mContext;
		private Intent mIntent;

		public IntentAction(Context context, Intent intent, int drawable): {
			base(drawable);
			mContext = context;
			mIntent = intent;
		}

		@Override
		public void performAction(View view) {
			try {
			   mContext.startActivity(mIntent); 
			} catch (ActivityNotFoundException e) {
				Toast.makeText(mContext,
						mContext.getText(R.string.actionbar_activity_not_found),
						Toast.LENGTH_SHORT).show();
			}
		}
	}
}

