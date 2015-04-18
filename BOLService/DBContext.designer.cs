﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOLService
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DemoDVD")]
	public partial class DBContextDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertImgLink(ImgLink instance);
    partial void UpdateImgLink(ImgLink instance);
    partial void DeleteImgLink(ImgLink instance);
    #endregion
		
		public DBContextDataContext() : 
				base(global::BOLService.Properties.Settings.Default.DemoDVDConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DBContextDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBContextDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBContextDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBContextDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ImgLink> ImgLinks
		{
			get
			{
				return this.GetTable<ImgLink>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetRandomImage")]
		public ISingleResult<GetRandomImageResult> GetRandomImage([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> randomOn, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> amountReturn)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), randomOn, amountReturn);
			return ((ISingleResult<GetRandomImageResult>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ImgLink")]
	public partial class ImgLink : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _linkimg;
		
		private System.DateTime _CreateDate;
		
		private System.Nullable<bool> _IsDownLoaded;
		
		private string _Domain;
		
		private string _Counter;
		
		private string _GroupName;
		
		private string _Category;
		
		private System.Nullable<bool> _IsBadURL;
		
		private System.Nullable<bool> _IsCheckLive;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnlinkimgChanging(string value);
    partial void OnlinkimgChanged();
    partial void OnCreateDateChanging(System.DateTime value);
    partial void OnCreateDateChanged();
    partial void OnIsDownLoadedChanging(System.Nullable<bool> value);
    partial void OnIsDownLoadedChanged();
    partial void OnDomainChanging(string value);
    partial void OnDomainChanged();
    partial void OnCounterChanging(string value);
    partial void OnCounterChanged();
    partial void OnGroupNameChanging(string value);
    partial void OnGroupNameChanged();
    partial void OnCategoryChanging(string value);
    partial void OnCategoryChanged();
    partial void OnIsBadURLChanging(System.Nullable<bool> value);
    partial void OnIsBadURLChanged();
    partial void OnIsCheckLiveChanging(System.Nullable<bool> value);
    partial void OnIsCheckLiveChanged();
    #endregion
		
		public ImgLink()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_linkimg", DbType="NVarChar(2500) NOT NULL", CanBeNull=false)]
		public string linkimg
		{
			get
			{
				return this._linkimg;
			}
			set
			{
				if ((this._linkimg != value))
				{
					this.OnlinkimgChanging(value);
					this.SendPropertyChanging();
					this._linkimg = value;
					this.SendPropertyChanged("linkimg");
					this.OnlinkimgChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsDownLoaded", DbType="Bit")]
		public System.Nullable<bool> IsDownLoaded
		{
			get
			{
				return this._IsDownLoaded;
			}
			set
			{
				if ((this._IsDownLoaded != value))
				{
					this.OnIsDownLoadedChanging(value);
					this.SendPropertyChanging();
					this._IsDownLoaded = value;
					this.SendPropertyChanged("IsDownLoaded");
					this.OnIsDownLoadedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Domain", DbType="NVarChar(1000)")]
		public string Domain
		{
			get
			{
				return this._Domain;
			}
			set
			{
				if ((this._Domain != value))
				{
					this.OnDomainChanging(value);
					this.SendPropertyChanging();
					this._Domain = value;
					this.SendPropertyChanged("Domain");
					this.OnDomainChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Counter", DbType="NVarChar(500)")]
		public string Counter
		{
			get
			{
				return this._Counter;
			}
			set
			{
				if ((this._Counter != value))
				{
					this.OnCounterChanging(value);
					this.SendPropertyChanging();
					this._Counter = value;
					this.SendPropertyChanged("Counter");
					this.OnCounterChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GroupName", DbType="NVarChar(1000)")]
		public string GroupName
		{
			get
			{
				return this._GroupName;
			}
			set
			{
				if ((this._GroupName != value))
				{
					this.OnGroupNameChanging(value);
					this.SendPropertyChanging();
					this._GroupName = value;
					this.SendPropertyChanged("GroupName");
					this.OnGroupNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Category", DbType="NVarChar(1000)")]
		public string Category
		{
			get
			{
				return this._Category;
			}
			set
			{
				if ((this._Category != value))
				{
					this.OnCategoryChanging(value);
					this.SendPropertyChanging();
					this._Category = value;
					this.SendPropertyChanged("Category");
					this.OnCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsBadURL", DbType="Bit")]
		public System.Nullable<bool> IsBadURL
		{
			get
			{
				return this._IsBadURL;
			}
			set
			{
				if ((this._IsBadURL != value))
				{
					this.OnIsBadURLChanging(value);
					this.SendPropertyChanging();
					this._IsBadURL = value;
					this.SendPropertyChanged("IsBadURL");
					this.OnIsBadURLChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsCheckLive", DbType="Bit")]
		public System.Nullable<bool> IsCheckLive
		{
			get
			{
				return this._IsCheckLive;
			}
			set
			{
				if ((this._IsCheckLive != value))
				{
					this.OnIsCheckLiveChanging(value);
					this.SendPropertyChanging();
					this._IsCheckLive = value;
					this.SendPropertyChanged("IsCheckLive");
					this.OnIsCheckLiveChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	public partial class GetRandomImageResult
	{
		
		private int _ID;
		
		private string _linkimg;
		
		private System.DateTime _CreateDate;
		
		public GetRandomImageResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL")]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_linkimg", DbType="NVarChar(2500) NOT NULL", CanBeNull=false)]
		public string linkimg
		{
			get
			{
				return this._linkimg;
			}
			set
			{
				if ((this._linkimg != value))
				{
					this._linkimg = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this._CreateDate = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
