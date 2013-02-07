﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModelLib
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="WebService")]
	public partial class WebserviceDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertErrorLog(ErrorLog instance);
    partial void UpdateErrorLog(ErrorLog instance);
    partial void DeleteErrorLog(ErrorLog instance);
    partial void InsertService(Service instance);
    partial void UpdateService(Service instance);
    partial void DeleteService(Service instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertUserService(UserService instance);
    partial void UpdateUserService(UserService instance);
    partial void DeleteUserService(UserService instance);
    partial void InsertConsumeLog(ConsumeLog instance);
    partial void UpdateConsumeLog(ConsumeLog instance);
    partial void DeleteConsumeLog(ConsumeLog instance);
    #endregion
		
		public WebserviceDataContext() : 
				base(global::DataModelLib.Properties.Settings.Default.WebServiceConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public WebserviceDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WebserviceDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WebserviceDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WebserviceDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ErrorLog> ErrorLogs
		{
			get
			{
				return this.GetTable<ErrorLog>();
			}
		}
		
		public System.Data.Linq.Table<Service> Services
		{
			get
			{
				return this.GetTable<Service>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<UserService> UserServices
		{
			get
			{
				return this.GetTable<UserService>();
			}
		}
		
		public System.Data.Linq.Table<ConsumeLog> ConsumeLogs
		{
			get
			{
				return this.GetTable<ConsumeLog>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ErrorLog")]
	public partial class ErrorLog : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.DateTime _ErrorDate;
		
		private string _Message;
		
		private string _Detail;
		
		private string _ClientIp;
		
		private string _Url;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnErrorDateChanging(System.DateTime value);
    partial void OnErrorDateChanged();
    partial void OnMessageChanging(string value);
    partial void OnMessageChanged();
    partial void OnDetailChanging(string value);
    partial void OnDetailChanged();
    partial void OnClientIpChanging(string value);
    partial void OnClientIpChanged();
    partial void OnUrlChanging(string value);
    partial void OnUrlChanged();
    #endregion
		
		public ErrorLog()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ErrorDate", DbType="DateTime NOT NULL")]
		public System.DateTime ErrorDate
		{
			get
			{
				return this._ErrorDate;
			}
			set
			{
				if ((this._ErrorDate != value))
				{
					this.OnErrorDateChanging(value);
					this.SendPropertyChanging();
					this._ErrorDate = value;
					this.SendPropertyChanged("ErrorDate");
					this.OnErrorDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Message", DbType="NVarChar(MAX)")]
		public string Message
		{
			get
			{
				return this._Message;
			}
			set
			{
				if ((this._Message != value))
				{
					this.OnMessageChanging(value);
					this.SendPropertyChanging();
					this._Message = value;
					this.SendPropertyChanged("Message");
					this.OnMessageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Detail", DbType="NVarChar(MAX)")]
		public string Detail
		{
			get
			{
				return this._Detail;
			}
			set
			{
				if ((this._Detail != value))
				{
					this.OnDetailChanging(value);
					this.SendPropertyChanging();
					this._Detail = value;
					this.SendPropertyChanged("Detail");
					this.OnDetailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClientIp", DbType="NVarChar(100)")]
		public string ClientIp
		{
			get
			{
				return this._ClientIp;
			}
			set
			{
				if ((this._ClientIp != value))
				{
					this.OnClientIpChanging(value);
					this.SendPropertyChanging();
					this._ClientIp = value;
					this.SendPropertyChanged("ClientIp");
					this.OnClientIpChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Url", DbType="NVarChar(2500)")]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				if ((this._Url != value))
				{
					this.OnUrlChanging(value);
					this.SendPropertyChanging();
					this._Url = value;
					this.SendPropertyChanged("Url");
					this.OnUrlChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Service")]
	public partial class Service : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ServiceId;
		
		private string _ServiceName;
		
		private string _ServiceURL;
		
		private string _UpdateUser;
		
		private System.DateTime _UpdateDateTime;
		
		private EntitySet<UserService> _UserServices;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnServiceIdChanging(int value);
    partial void OnServiceIdChanged();
    partial void OnServiceNameChanging(string value);
    partial void OnServiceNameChanged();
    partial void OnServiceURLChanging(string value);
    partial void OnServiceURLChanged();
    partial void OnUpdateUserChanging(string value);
    partial void OnUpdateUserChanged();
    partial void OnUpdateDateTimeChanging(System.DateTime value);
    partial void OnUpdateDateTimeChanged();
    #endregion
		
		public Service()
		{
			this._UserServices = new EntitySet<UserService>(new Action<UserService>(this.attach_UserServices), new Action<UserService>(this.detach_UserServices));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ServiceId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ServiceId
		{
			get
			{
				return this._ServiceId;
			}
			set
			{
				if ((this._ServiceId != value))
				{
					this.OnServiceIdChanging(value);
					this.SendPropertyChanging();
					this._ServiceId = value;
					this.SendPropertyChanged("ServiceId");
					this.OnServiceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ServiceName", DbType="NVarChar(50)")]
		public string ServiceName
		{
			get
			{
				return this._ServiceName;
			}
			set
			{
				if ((this._ServiceName != value))
				{
					this.OnServiceNameChanging(value);
					this.SendPropertyChanging();
					this._ServiceName = value;
					this.SendPropertyChanged("ServiceName");
					this.OnServiceNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ServiceURL", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
		public string ServiceURL
		{
			get
			{
				return this._ServiceURL;
			}
			set
			{
				if ((this._ServiceURL != value))
				{
					this.OnServiceURLChanging(value);
					this.SendPropertyChanging();
					this._ServiceURL = value;
					this.SendPropertyChanged("ServiceURL");
					this.OnServiceURLChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UpdateUser", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string UpdateUser
		{
			get
			{
				return this._UpdateUser;
			}
			set
			{
				if ((this._UpdateUser != value))
				{
					this.OnUpdateUserChanging(value);
					this.SendPropertyChanging();
					this._UpdateUser = value;
					this.SendPropertyChanged("UpdateUser");
					this.OnUpdateUserChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UpdateDateTime", DbType="DateTime NOT NULL")]
		public System.DateTime UpdateDateTime
		{
			get
			{
				return this._UpdateDateTime;
			}
			set
			{
				if ((this._UpdateDateTime != value))
				{
					this.OnUpdateDateTimeChanging(value);
					this.SendPropertyChanging();
					this._UpdateDateTime = value;
					this.SendPropertyChanged("UpdateDateTime");
					this.OnUpdateDateTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Service_UserService", Storage="_UserServices", ThisKey="ServiceId", OtherKey="ServiceId")]
		public EntitySet<UserService> UserServices
		{
			get
			{
				return this._UserServices;
			}
			set
			{
				this._UserServices.Assign(value);
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
		
		private void attach_UserServices(UserService entity)
		{
			this.SendPropertyChanging();
			entity.Service = this;
		}
		
		private void detach_UserServices(UserService entity)
		{
			this.SendPropertyChanging();
			entity.Service = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[User]")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserId;
		
		private string _Username;
		
		private string _Password;
		
		private string _Description;
		
		private string _UpdateUser;
		
		private System.DateTime _UpdateDateTime;
		
		private EntitySet<UserService> _UserServices;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnUpdateUserChanging(string value);
    partial void OnUpdateUserChanged();
    partial void OnUpdateDateTimeChanging(System.DateTime value);
    partial void OnUpdateDateTimeChanged();
    #endregion
		
		public User()
		{
			this._UserServices = new EntitySet<UserService>(new Action<UserService>(this.attach_UserServices), new Action<UserService>(this.detach_UserServices));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(150)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UpdateUser", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string UpdateUser
		{
			get
			{
				return this._UpdateUser;
			}
			set
			{
				if ((this._UpdateUser != value))
				{
					this.OnUpdateUserChanging(value);
					this.SendPropertyChanging();
					this._UpdateUser = value;
					this.SendPropertyChanged("UpdateUser");
					this.OnUpdateUserChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UpdateDateTime", DbType="DateTime NOT NULL")]
		public System.DateTime UpdateDateTime
		{
			get
			{
				return this._UpdateDateTime;
			}
			set
			{
				if ((this._UpdateDateTime != value))
				{
					this.OnUpdateDateTimeChanging(value);
					this.SendPropertyChanging();
					this._UpdateDateTime = value;
					this.SendPropertyChanged("UpdateDateTime");
					this.OnUpdateDateTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_UserService", Storage="_UserServices", ThisKey="UserId", OtherKey="UserId")]
		public EntitySet<UserService> UserServices
		{
			get
			{
				return this._UserServices;
			}
			set
			{
				this._UserServices.Assign(value);
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
		
		private void attach_UserServices(UserService entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_UserServices(UserService entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserService")]
	public partial class UserService : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _UserId;
		
		private int _ServiceId;
		
		private System.Nullable<int> _Status;
		
		private string _UpdateUser;
		
		private System.DateTime _UpdateDateTime;
		
		private string _Ips;
		
		private EntityRef<User> _User;
		
		private EntityRef<Service> _Service;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnServiceIdChanging(int value);
    partial void OnServiceIdChanged();
    partial void OnStatusChanging(System.Nullable<int> value);
    partial void OnStatusChanged();
    partial void OnUpdateUserChanging(string value);
    partial void OnUpdateUserChanged();
    partial void OnUpdateDateTimeChanging(System.DateTime value);
    partial void OnUpdateDateTimeChanged();
    partial void OnIpsChanging(string value);
    partial void OnIpsChanged();
    #endregion
		
		public UserService()
		{
			this._User = default(EntityRef<User>);
			this._Service = default(EntityRef<Service>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ServiceId", DbType="Int NOT NULL")]
		public int ServiceId
		{
			get
			{
				return this._ServiceId;
			}
			set
			{
				if ((this._ServiceId != value))
				{
					if (this._Service.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnServiceIdChanging(value);
					this.SendPropertyChanging();
					this._ServiceId = value;
					this.SendPropertyChanged("ServiceId");
					this.OnServiceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Int")]
		public System.Nullable<int> Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UpdateUser", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string UpdateUser
		{
			get
			{
				return this._UpdateUser;
			}
			set
			{
				if ((this._UpdateUser != value))
				{
					this.OnUpdateUserChanging(value);
					this.SendPropertyChanging();
					this._UpdateUser = value;
					this.SendPropertyChanged("UpdateUser");
					this.OnUpdateUserChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UpdateDateTime", DbType="DateTime NOT NULL")]
		public System.DateTime UpdateDateTime
		{
			get
			{
				return this._UpdateDateTime;
			}
			set
			{
				if ((this._UpdateDateTime != value))
				{
					this.OnUpdateDateTimeChanging(value);
					this.SendPropertyChanging();
					this._UpdateDateTime = value;
					this.SendPropertyChanged("UpdateDateTime");
					this.OnUpdateDateTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ips", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Ips
		{
			get
			{
				return this._Ips;
			}
			set
			{
				if ((this._Ips != value))
				{
					this.OnIpsChanging(value);
					this.SendPropertyChanging();
					this._Ips = value;
					this.SendPropertyChanged("Ips");
					this.OnIpsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_UserService", Storage="_User", ThisKey="UserId", OtherKey="UserId", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.UserServices.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.UserServices.Add(this);
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Service_UserService", Storage="_Service", ThisKey="ServiceId", OtherKey="ServiceId", IsForeignKey=true)]
		public Service Service
		{
			get
			{
				return this._Service.Entity;
			}
			set
			{
				Service previousValue = this._Service.Entity;
				if (((previousValue != value) 
							|| (this._Service.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Service.Entity = null;
						previousValue.UserServices.Remove(this);
					}
					this._Service.Entity = value;
					if ((value != null))
					{
						value.UserServices.Add(this);
						this._ServiceId = value.ServiceId;
					}
					else
					{
						this._ServiceId = default(int);
					}
					this.SendPropertyChanged("Service");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ConsumeLog")]
	public partial class ConsumeLog : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.DateTime _Date;
		
		private string _ClientIp;
		
		private string _Url;
		
		private string _Username;
		
		private string _Service;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnDateChanging(System.DateTime value);
    partial void OnDateChanged();
    partial void OnClientIpChanging(string value);
    partial void OnClientIpChanged();
    partial void OnUrlChanging(string value);
    partial void OnUrlChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnServiceChanging(string value);
    partial void OnServiceChanged();
    #endregion
		
		public ConsumeLog()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="DateTime NOT NULL")]
		public System.DateTime Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClientIp", DbType="NVarChar(100)")]
		public string ClientIp
		{
			get
			{
				return this._ClientIp;
			}
			set
			{
				if ((this._ClientIp != value))
				{
					this.OnClientIpChanging(value);
					this.SendPropertyChanging();
					this._ClientIp = value;
					this.SendPropertyChanged("ClientIp");
					this.OnClientIpChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Url", DbType="NVarChar(2500)")]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				if ((this._Url != value))
				{
					this.OnUrlChanging(value);
					this.SendPropertyChanging();
					this._Url = value;
					this.SendPropertyChanged("Url");
					this.OnUrlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="NVarChar(150)")]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Service", DbType="NVarChar(200)")]
		public string Service
		{
			get
			{
				return this._Service;
			}
			set
			{
				if ((this._Service != value))
				{
					this.OnServiceChanging(value);
					this.SendPropertyChanging();
					this._Service = value;
					this.SendPropertyChanged("Service");
					this.OnServiceChanged();
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
}
#pragma warning restore 1591
