using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace CustomServerControlsLibrary
{
	[ParseChildren(true)]
	public class SimpleStyledRepeater : WebControl, INamingContainer
	{
		public SimpleStyledRepeater() : base()
		{
			RepeatCount = 1;

			// Note that in order to reduce page size, this
			// control doesn't store style information in view state.
			// That means if you change styles programmatically,
			// the changes will be lost after each postback.
		}

		public int RepeatCount
		{
			get {return (int)ViewState["RepeatCount"];}
			set {ViewState["RepeatCount"] = value;}
		}

		private ITemplate itemTemplate;

		[PersistenceMode(PersistenceMode.InnerProperty)]
		[TemplateContainer(typeof(SimpleRepeaterItem))]
		public ITemplate ItemTemplate
		{
			get {return itemTemplate;}
			set {itemTemplate=value;}
		}

		private ITemplate alternatingItemTemplate;

		[PersistenceMode(PersistenceMode.InnerProperty)]
		[TemplateContainer(typeof(SimpleRepeaterItem))]
		public ITemplate AlternatingItemTemplate
		{
			get {return alternatingItemTemplate;}
			set {alternatingItemTemplate=value;}
		}

		private ITemplate headerTemplate;

		[PersistenceMode(PersistenceMode.InnerProperty)]
		[TemplateContainer(typeof(SimpleRepeaterItem))]
		public ITemplate HeaderTemplate
		{
			get {return headerTemplate;}
			set {headerTemplate=value;}
		}

		private ITemplate footerTemplate;

		[PersistenceMode(PersistenceMode.InnerProperty)]
		[TemplateContainer(typeof(SimpleRepeaterItem))]
		public ITemplate FooterTemplate
		{
			get {return footerTemplate;}
			set {footerTemplate=value;}
		}

		private Style itemStyle;
		private Style alternatingItemStyle;
		private Style headerStyle;
		private Style footerStyle;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[NotifyParentProperty(true)]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public Style ItemStyle
		{
			get{
				if (itemStyle == null)
				{
					itemStyle = new Style();
					if (IsTrackingViewState)
						((IStateManager)itemStyle).TrackViewState();
				}
				return itemStyle;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[NotifyParentProperty(true)]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public Style AlternatingItemStyle
		{
			get{
				if (alternatingItemStyle == null)
				{
					alternatingItemStyle = new Style();
					if (IsTrackingViewState)
						((IStateManager)alternatingItemStyle).TrackViewState();
				}
				return alternatingItemStyle;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[NotifyParentProperty(true)]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public Style HeaderStyle
		{
			get
			{
				if (headerStyle == null)
				{
					headerStyle = new Style();
					if (IsTrackingViewState)
						((IStateManager)headerStyle).TrackViewState();
				}
				return headerStyle;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[NotifyParentProperty(true)]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public Style FooterStyle
		{
			get
			{
				if (footerStyle == null)
				{
					footerStyle = new Style();
					if (IsTrackingViewState)
						((IStateManager)footerStyle).TrackViewState();
				}
				return footerStyle;
			}
		}

		protected override void CreateChildControls() 
		{
			Controls.Clear();
				
			if ((RepeatCount > 0) && (itemTemplate!=null))
			{
				// Start by outputing the header template (if supplied).
				if(headerTemplate != null)
				{
					SimpleRepeaterItem headerContainer = new SimpleRepeaterItem(0, RepeatCount);
					headerTemplate.InstantiateIn(headerContainer);		
					Controls.Add(headerContainer);

					if (headerStyle!=null)
						headerContainer.ApplyStyle(headerStyle);
				}

				// Output the content the specified number of times.
				for (int i = 0; i<RepeatCount; i++)
				{
					SimpleRepeaterItem container = new SimpleRepeaterItem(i+1, RepeatCount);
					
					// Create a style for alternate items.
					Style altStyle = new Style();
					altStyle.MergeWith(itemStyle);
					altStyle.CopyFrom(alternatingItemStyle);

					if ((i%2 == 0) && (alternatingItemTemplate != null))
					{
						// This is an alternating item and there is an alternating template.
						alternatingItemTemplate.InstantiateIn(container);
						container.ApplyStyle(altStyle);
					}
					else
					{
						itemTemplate.InstantiateIn(container);
						if (itemStyle != null)
							container.ApplyStyle(itemStyle);
					}
					
					Controls.Add(container);
				}

				// Once all of the items have been rendered,
				// add the footer template if specified.
				if (footerTemplate != null)
				{
					SimpleRepeaterItem footerContainer = new SimpleRepeaterItem(RepeatCount, RepeatCount);
					footerTemplate.InstantiateIn(footerContainer);
					Controls.Add(footerContainer);
					if (footerStyle != null)
						footerContainer.ApplyStyle(footerStyle);
				}
			}
			else
			{
				// Show an error message.
				Controls.Add(new LiteralControl("Specify the record count and an item template"));
			}
		}

		public override void DataBind()
		{
			EnsureChildControls();
			base.DataBind();
		}
	
	
	}
	
}
