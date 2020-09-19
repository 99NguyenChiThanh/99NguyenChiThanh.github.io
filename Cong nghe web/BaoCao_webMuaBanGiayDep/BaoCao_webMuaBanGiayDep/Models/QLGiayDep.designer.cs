﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaoCao_webMuaBanGiayDep.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="MuaBanGiayDep")]
	public partial class QLGiayDepDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertChiTietDonDatHang(ChiTietDonDatHang instance);
    partial void UpdateChiTietDonDatHang(ChiTietDonDatHang instance);
    partial void DeleteChiTietDonDatHang(ChiTietDonDatHang instance);
    partial void InsertNhom(Nhom instance);
    partial void UpdateNhom(Nhom instance);
    partial void DeleteNhom(Nhom instance);
    partial void InsertChiTietSanPham(ChiTietSanPham instance);
    partial void UpdateChiTietSanPham(ChiTietSanPham instance);
    partial void DeleteChiTietSanPham(ChiTietSanPham instance);
    partial void InsertDonDatHang(DonDatHang instance);
    partial void UpdateDonDatHang(DonDatHang instance);
    partial void DeleteDonDatHang(DonDatHang instance);
    partial void InsertKhachHang(KhachHang instance);
    partial void UpdateKhachHang(KhachHang instance);
    partial void DeleteKhachHang(KhachHang instance);
    partial void InsertLoai(Loai instance);
    partial void UpdateLoai(Loai instance);
    partial void DeleteLoai(Loai instance);
    #endregion
		
		public QLGiayDepDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["MuaBanGiayDepConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public QLGiayDepDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QLGiayDepDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QLGiayDepDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QLGiayDepDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ChiTietDonDatHang> ChiTietDonDatHangs
		{
			get
			{
				return this.GetTable<ChiTietDonDatHang>();
			}
		}
		
		public System.Data.Linq.Table<Nhom> Nhoms
		{
			get
			{
				return this.GetTable<Nhom>();
			}
		}
		
		public System.Data.Linq.Table<ChiTietSanPham> ChiTietSanPhams
		{
			get
			{
				return this.GetTable<ChiTietSanPham>();
			}
		}
		
		public System.Data.Linq.Table<DonDatHang> DonDatHangs
		{
			get
			{
				return this.GetTable<DonDatHang>();
			}
		}
		
		public System.Data.Linq.Table<KhachHang> KhachHangs
		{
			get
			{
				return this.GetTable<KhachHang>();
			}
		}
		
		public System.Data.Linq.Table<Loai> Loais
		{
			get
			{
				return this.GetTable<Loai>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ChiTietDonDatHang")]
	public partial class ChiTietDonDatHang : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MaDonHang;
		
		private int _MaSP;
		
		private System.Nullable<int> _SoLuong;
		
		private System.Nullable<decimal> _DonGia;
		
		private EntityRef<ChiTietSanPham> _ChiTietSanPham;
		
		private EntityRef<DonDatHang> _DonDatHang;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaDonHangChanging(int value);
    partial void OnMaDonHangChanged();
    partial void OnMaSPChanging(int value);
    partial void OnMaSPChanged();
    partial void OnSoLuongChanging(System.Nullable<int> value);
    partial void OnSoLuongChanged();
    partial void OnDonGiaChanging(System.Nullable<decimal> value);
    partial void OnDonGiaChanged();
    #endregion
		
		public ChiTietDonDatHang()
		{
			this._ChiTietSanPham = default(EntityRef<ChiTietSanPham>);
			this._DonDatHang = default(EntityRef<DonDatHang>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaDonHang", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int MaDonHang
		{
			get
			{
				return this._MaDonHang;
			}
			set
			{
				if ((this._MaDonHang != value))
				{
					if (this._DonDatHang.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaDonHangChanging(value);
					this.SendPropertyChanging();
					this._MaDonHang = value;
					this.SendPropertyChanged("MaDonHang");
					this.OnMaDonHangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaSP", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int MaSP
		{
			get
			{
				return this._MaSP;
			}
			set
			{
				if ((this._MaSP != value))
				{
					if (this._ChiTietSanPham.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaSPChanging(value);
					this.SendPropertyChanging();
					this._MaSP = value;
					this.SendPropertyChanged("MaSP");
					this.OnMaSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoLuong", DbType="Int")]
		public System.Nullable<int> SoLuong
		{
			get
			{
				return this._SoLuong;
			}
			set
			{
				if ((this._SoLuong != value))
				{
					this.OnSoLuongChanging(value);
					this.SendPropertyChanging();
					this._SoLuong = value;
					this.SendPropertyChanged("SoLuong");
					this.OnSoLuongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DonGia", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> DonGia
		{
			get
			{
				return this._DonGia;
			}
			set
			{
				if ((this._DonGia != value))
				{
					this.OnDonGiaChanging(value);
					this.SendPropertyChanging();
					this._DonGia = value;
					this.SendPropertyChanged("DonGia");
					this.OnDonGiaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ChiTietSanPham_ChiTietDonDatHang", Storage="_ChiTietSanPham", ThisKey="MaSP", OtherKey="MaSP", IsForeignKey=true)]
		public ChiTietSanPham ChiTietSanPham
		{
			get
			{
				return this._ChiTietSanPham.Entity;
			}
			set
			{
				ChiTietSanPham previousValue = this._ChiTietSanPham.Entity;
				if (((previousValue != value) 
							|| (this._ChiTietSanPham.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ChiTietSanPham.Entity = null;
						previousValue.ChiTietDonDatHangs.Remove(this);
					}
					this._ChiTietSanPham.Entity = value;
					if ((value != null))
					{
						value.ChiTietDonDatHangs.Add(this);
						this._MaSP = value.MaSP;
					}
					else
					{
						this._MaSP = default(int);
					}
					this.SendPropertyChanged("ChiTietSanPham");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DonDatHang_ChiTietDonDatHang", Storage="_DonDatHang", ThisKey="MaDonHang", OtherKey="MaDonHang", IsForeignKey=true)]
		public DonDatHang DonDatHang
		{
			get
			{
				return this._DonDatHang.Entity;
			}
			set
			{
				DonDatHang previousValue = this._DonDatHang.Entity;
				if (((previousValue != value) 
							|| (this._DonDatHang.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._DonDatHang.Entity = null;
						previousValue.ChiTietDonDatHangs.Remove(this);
					}
					this._DonDatHang.Entity = value;
					if ((value != null))
					{
						value.ChiTietDonDatHangs.Add(this);
						this._MaDonHang = value.MaDonHang;
					}
					else
					{
						this._MaDonHang = default(int);
					}
					this.SendPropertyChanged("DonDatHang");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Nhom")]
	public partial class Nhom : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MaNhom;
		
		private string _TenNhom;
		
		private EntitySet<ChiTietSanPham> _ChiTietSanPhams;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaNhomChanging(int value);
    partial void OnMaNhomChanged();
    partial void OnTenNhomChanging(string value);
    partial void OnTenNhomChanged();
    #endregion
		
		public Nhom()
		{
			this._ChiTietSanPhams = new EntitySet<ChiTietSanPham>(new Action<ChiTietSanPham>(this.attach_ChiTietSanPhams), new Action<ChiTietSanPham>(this.detach_ChiTietSanPhams));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaNhom", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MaNhom
		{
			get
			{
				return this._MaNhom;
			}
			set
			{
				if ((this._MaNhom != value))
				{
					this.OnMaNhomChanging(value);
					this.SendPropertyChanging();
					this._MaNhom = value;
					this.SendPropertyChanged("MaNhom");
					this.OnMaNhomChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenNhom", DbType="NVarChar(50)")]
		public string TenNhom
		{
			get
			{
				return this._TenNhom;
			}
			set
			{
				if ((this._TenNhom != value))
				{
					this.OnTenNhomChanging(value);
					this.SendPropertyChanging();
					this._TenNhom = value;
					this.SendPropertyChanged("TenNhom");
					this.OnTenNhomChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Nhom_ChiTietSanPham", Storage="_ChiTietSanPhams", ThisKey="MaNhom", OtherKey="MaNhom")]
		public EntitySet<ChiTietSanPham> ChiTietSanPhams
		{
			get
			{
				return this._ChiTietSanPhams;
			}
			set
			{
				this._ChiTietSanPhams.Assign(value);
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
		
		private void attach_ChiTietSanPhams(ChiTietSanPham entity)
		{
			this.SendPropertyChanging();
			entity.Nhom = this;
		}
		
		private void detach_ChiTietSanPhams(ChiTietSanPham entity)
		{
			this.SendPropertyChanging();
			entity.Nhom = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ChiTietSanPham")]
	public partial class ChiTietSanPham : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MaSP;
		
		private string _TenSP;
		
		private string _Hinh;
		
		private string _MoTa;
		
		private string _Size;
		
		private System.Nullable<int> _MaLoai;
		
		private System.Nullable<int> _Gia;
		
		private System.Nullable<int> _MaNhom;
		
		private EntitySet<ChiTietDonDatHang> _ChiTietDonDatHangs;
		
		private EntityRef<Nhom> _Nhom;
		
		private EntityRef<Loai> _Loai;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaSPChanging(int value);
    partial void OnMaSPChanged();
    partial void OnTenSPChanging(string value);
    partial void OnTenSPChanged();
    partial void OnHinhChanging(string value);
    partial void OnHinhChanged();
    partial void OnMoTaChanging(string value);
    partial void OnMoTaChanged();
    partial void OnSizeChanging(string value);
    partial void OnSizeChanged();
    partial void OnMaLoaiChanging(System.Nullable<int> value);
    partial void OnMaLoaiChanged();
    partial void OnGiaChanging(System.Nullable<int> value);
    partial void OnGiaChanged();
    partial void OnMaNhomChanging(System.Nullable<int> value);
    partial void OnMaNhomChanged();
    #endregion
		
		public ChiTietSanPham()
		{
			this._ChiTietDonDatHangs = new EntitySet<ChiTietDonDatHang>(new Action<ChiTietDonDatHang>(this.attach_ChiTietDonDatHangs), new Action<ChiTietDonDatHang>(this.detach_ChiTietDonDatHangs));
			this._Nhom = default(EntityRef<Nhom>);
			this._Loai = default(EntityRef<Loai>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaSP", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MaSP
		{
			get
			{
				return this._MaSP;
			}
			set
			{
				if ((this._MaSP != value))
				{
					this.OnMaSPChanging(value);
					this.SendPropertyChanging();
					this._MaSP = value;
					this.SendPropertyChanged("MaSP");
					this.OnMaSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenSP", DbType="NVarChar(50)")]
		public string TenSP
		{
			get
			{
				return this._TenSP;
			}
			set
			{
				if ((this._TenSP != value))
				{
					this.OnTenSPChanging(value);
					this.SendPropertyChanging();
					this._TenSP = value;
					this.SendPropertyChanged("TenSP");
					this.OnTenSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hinh", DbType="NVarChar(MAX)")]
		public string Hinh
		{
			get
			{
				return this._Hinh;
			}
			set
			{
				if ((this._Hinh != value))
				{
					this.OnHinhChanging(value);
					this.SendPropertyChanging();
					this._Hinh = value;
					this.SendPropertyChanged("Hinh");
					this.OnHinhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MoTa", DbType="NVarChar(MAX)")]
		public string MoTa
		{
			get
			{
				return this._MoTa;
			}
			set
			{
				if ((this._MoTa != value))
				{
					this.OnMoTaChanging(value);
					this.SendPropertyChanging();
					this._MoTa = value;
					this.SendPropertyChanged("MoTa");
					this.OnMoTaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Size", DbType="NVarChar(50)")]
		public string Size
		{
			get
			{
				return this._Size;
			}
			set
			{
				if ((this._Size != value))
				{
					this.OnSizeChanging(value);
					this.SendPropertyChanging();
					this._Size = value;
					this.SendPropertyChanged("Size");
					this.OnSizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaLoai", DbType="Int")]
		public System.Nullable<int> MaLoai
		{
			get
			{
				return this._MaLoai;
			}
			set
			{
				if ((this._MaLoai != value))
				{
					if (this._Loai.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaLoaiChanging(value);
					this.SendPropertyChanging();
					this._MaLoai = value;
					this.SendPropertyChanged("MaLoai");
					this.OnMaLoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gia", DbType="Int")]
		public System.Nullable<int> Gia
		{
			get
			{
				return this._Gia;
			}
			set
			{
				if ((this._Gia != value))
				{
					this.OnGiaChanging(value);
					this.SendPropertyChanging();
					this._Gia = value;
					this.SendPropertyChanged("Gia");
					this.OnGiaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaNhom", DbType="Int")]
		public System.Nullable<int> MaNhom
		{
			get
			{
				return this._MaNhom;
			}
			set
			{
				if ((this._MaNhom != value))
				{
					if (this._Nhom.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaNhomChanging(value);
					this.SendPropertyChanging();
					this._MaNhom = value;
					this.SendPropertyChanged("MaNhom");
					this.OnMaNhomChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ChiTietSanPham_ChiTietDonDatHang", Storage="_ChiTietDonDatHangs", ThisKey="MaSP", OtherKey="MaSP")]
		public EntitySet<ChiTietDonDatHang> ChiTietDonDatHangs
		{
			get
			{
				return this._ChiTietDonDatHangs;
			}
			set
			{
				this._ChiTietDonDatHangs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Nhom_ChiTietSanPham", Storage="_Nhom", ThisKey="MaNhom", OtherKey="MaNhom", IsForeignKey=true)]
		public Nhom Nhom
		{
			get
			{
				return this._Nhom.Entity;
			}
			set
			{
				Nhom previousValue = this._Nhom.Entity;
				if (((previousValue != value) 
							|| (this._Nhom.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Nhom.Entity = null;
						previousValue.ChiTietSanPhams.Remove(this);
					}
					this._Nhom.Entity = value;
					if ((value != null))
					{
						value.ChiTietSanPhams.Add(this);
						this._MaNhom = value.MaNhom;
					}
					else
					{
						this._MaNhom = default(Nullable<int>);
					}
					this.SendPropertyChanged("Nhom");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Loai_ChiTietSanPham", Storage="_Loai", ThisKey="MaLoai", OtherKey="MaLoai", IsForeignKey=true)]
		public Loai Loai
		{
			get
			{
				return this._Loai.Entity;
			}
			set
			{
				Loai previousValue = this._Loai.Entity;
				if (((previousValue != value) 
							|| (this._Loai.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Loai.Entity = null;
						previousValue.ChiTietSanPhams.Remove(this);
					}
					this._Loai.Entity = value;
					if ((value != null))
					{
						value.ChiTietSanPhams.Add(this);
						this._MaLoai = value.MaLoai;
					}
					else
					{
						this._MaLoai = default(Nullable<int>);
					}
					this.SendPropertyChanged("Loai");
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
		
		private void attach_ChiTietDonDatHangs(ChiTietDonDatHang entity)
		{
			this.SendPropertyChanging();
			entity.ChiTietSanPham = this;
		}
		
		private void detach_ChiTietDonDatHangs(ChiTietDonDatHang entity)
		{
			this.SendPropertyChanging();
			entity.ChiTietSanPham = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DonDatHang")]
	public partial class DonDatHang : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MaDonHang;
		
		private System.Nullable<bool> _DaThanhToan;
		
		private System.Nullable<bool> _TinhTrangGiaoHang;
		
		private System.Nullable<System.DateTime> _NgayDat;
		
		private System.Nullable<System.DateTime> _NgayGiao;
		
		private System.Nullable<int> _MaKH;
		
		private EntitySet<ChiTietDonDatHang> _ChiTietDonDatHangs;
		
		private EntityRef<KhachHang> _KhachHang;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaDonHangChanging(int value);
    partial void OnMaDonHangChanged();
    partial void OnDaThanhToanChanging(System.Nullable<bool> value);
    partial void OnDaThanhToanChanged();
    partial void OnTinhTrangGiaoHangChanging(System.Nullable<bool> value);
    partial void OnTinhTrangGiaoHangChanged();
    partial void OnNgayDatChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayDatChanged();
    partial void OnNgayGiaoChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayGiaoChanged();
    partial void OnMaKHChanging(System.Nullable<int> value);
    partial void OnMaKHChanged();
    #endregion
		
		public DonDatHang()
		{
			this._ChiTietDonDatHangs = new EntitySet<ChiTietDonDatHang>(new Action<ChiTietDonDatHang>(this.attach_ChiTietDonDatHangs), new Action<ChiTietDonDatHang>(this.detach_ChiTietDonDatHangs));
			this._KhachHang = default(EntityRef<KhachHang>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaDonHang", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MaDonHang
		{
			get
			{
				return this._MaDonHang;
			}
			set
			{
				if ((this._MaDonHang != value))
				{
					this.OnMaDonHangChanging(value);
					this.SendPropertyChanging();
					this._MaDonHang = value;
					this.SendPropertyChanged("MaDonHang");
					this.OnMaDonHangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DaThanhToan", DbType="Bit")]
		public System.Nullable<bool> DaThanhToan
		{
			get
			{
				return this._DaThanhToan;
			}
			set
			{
				if ((this._DaThanhToan != value))
				{
					this.OnDaThanhToanChanging(value);
					this.SendPropertyChanging();
					this._DaThanhToan = value;
					this.SendPropertyChanged("DaThanhToan");
					this.OnDaThanhToanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TinhTrangGiaoHang", DbType="Bit")]
		public System.Nullable<bool> TinhTrangGiaoHang
		{
			get
			{
				return this._TinhTrangGiaoHang;
			}
			set
			{
				if ((this._TinhTrangGiaoHang != value))
				{
					this.OnTinhTrangGiaoHangChanging(value);
					this.SendPropertyChanging();
					this._TinhTrangGiaoHang = value;
					this.SendPropertyChanged("TinhTrangGiaoHang");
					this.OnTinhTrangGiaoHangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayDat", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayDat
		{
			get
			{
				return this._NgayDat;
			}
			set
			{
				if ((this._NgayDat != value))
				{
					this.OnNgayDatChanging(value);
					this.SendPropertyChanging();
					this._NgayDat = value;
					this.SendPropertyChanged("NgayDat");
					this.OnNgayDatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayGiao", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayGiao
		{
			get
			{
				return this._NgayGiao;
			}
			set
			{
				if ((this._NgayGiao != value))
				{
					this.OnNgayGiaoChanging(value);
					this.SendPropertyChanging();
					this._NgayGiao = value;
					this.SendPropertyChanged("NgayGiao");
					this.OnNgayGiaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaKH", DbType="Int")]
		public System.Nullable<int> MaKH
		{
			get
			{
				return this._MaKH;
			}
			set
			{
				if ((this._MaKH != value))
				{
					if (this._KhachHang.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaKHChanging(value);
					this.SendPropertyChanging();
					this._MaKH = value;
					this.SendPropertyChanged("MaKH");
					this.OnMaKHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DonDatHang_ChiTietDonDatHang", Storage="_ChiTietDonDatHangs", ThisKey="MaDonHang", OtherKey="MaDonHang")]
		public EntitySet<ChiTietDonDatHang> ChiTietDonDatHangs
		{
			get
			{
				return this._ChiTietDonDatHangs;
			}
			set
			{
				this._ChiTietDonDatHangs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="KhachHang_DonDatHang", Storage="_KhachHang", ThisKey="MaKH", OtherKey="MaKH", IsForeignKey=true)]
		public KhachHang KhachHang
		{
			get
			{
				return this._KhachHang.Entity;
			}
			set
			{
				KhachHang previousValue = this._KhachHang.Entity;
				if (((previousValue != value) 
							|| (this._KhachHang.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._KhachHang.Entity = null;
						previousValue.DonDatHangs.Remove(this);
					}
					this._KhachHang.Entity = value;
					if ((value != null))
					{
						value.DonDatHangs.Add(this);
						this._MaKH = value.MaKH;
					}
					else
					{
						this._MaKH = default(Nullable<int>);
					}
					this.SendPropertyChanged("KhachHang");
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
		
		private void attach_ChiTietDonDatHangs(ChiTietDonDatHang entity)
		{
			this.SendPropertyChanging();
			entity.DonDatHang = this;
		}
		
		private void detach_ChiTietDonDatHangs(ChiTietDonDatHang entity)
		{
			this.SendPropertyChanging();
			entity.DonDatHang = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.KhachHang")]
	public partial class KhachHang : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MaKH;
		
		private string _HoTen;
		
		private string _GioiTinh;
		
		private string _DienThoai;
		
		private string _TaiKhoan;
		
		private string _MatKhau;
		
		private string _Email;
		
		private string _DiaChi;
		
		private EntitySet<DonDatHang> _DonDatHangs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaKHChanging(int value);
    partial void OnMaKHChanged();
    partial void OnHoTenChanging(string value);
    partial void OnHoTenChanged();
    partial void OnGioiTinhChanging(string value);
    partial void OnGioiTinhChanged();
    partial void OnDienThoaiChanging(string value);
    partial void OnDienThoaiChanged();
    partial void OnTaiKhoanChanging(string value);
    partial void OnTaiKhoanChanged();
    partial void OnMatKhauChanging(string value);
    partial void OnMatKhauChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnDiaChiChanging(string value);
    partial void OnDiaChiChanged();
    #endregion
		
		public KhachHang()
		{
			this._DonDatHangs = new EntitySet<DonDatHang>(new Action<DonDatHang>(this.attach_DonDatHangs), new Action<DonDatHang>(this.detach_DonDatHangs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaKH", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MaKH
		{
			get
			{
				return this._MaKH;
			}
			set
			{
				if ((this._MaKH != value))
				{
					this.OnMaKHChanging(value);
					this.SendPropertyChanging();
					this._MaKH = value;
					this.SendPropertyChanged("MaKH");
					this.OnMaKHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HoTen", DbType="NVarChar(50)")]
		public string HoTen
		{
			get
			{
				return this._HoTen;
			}
			set
			{
				if ((this._HoTen != value))
				{
					this.OnHoTenChanging(value);
					this.SendPropertyChanging();
					this._HoTen = value;
					this.SendPropertyChanged("HoTen");
					this.OnHoTenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GioiTinh", DbType="NVarChar(3)")]
		public string GioiTinh
		{
			get
			{
				return this._GioiTinh;
			}
			set
			{
				if ((this._GioiTinh != value))
				{
					this.OnGioiTinhChanging(value);
					this.SendPropertyChanging();
					this._GioiTinh = value;
					this.SendPropertyChanged("GioiTinh");
					this.OnGioiTinhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DienThoai", DbType="VarChar(50)")]
		public string DienThoai
		{
			get
			{
				return this._DienThoai;
			}
			set
			{
				if ((this._DienThoai != value))
				{
					this.OnDienThoaiChanging(value);
					this.SendPropertyChanging();
					this._DienThoai = value;
					this.SendPropertyChanged("DienThoai");
					this.OnDienThoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaiKhoan", DbType="VarChar(50)")]
		public string TaiKhoan
		{
			get
			{
				return this._TaiKhoan;
			}
			set
			{
				if ((this._TaiKhoan != value))
				{
					this.OnTaiKhoanChanging(value);
					this.SendPropertyChanging();
					this._TaiKhoan = value;
					this.SendPropertyChanged("TaiKhoan");
					this.OnTaiKhoanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MatKhau", DbType="NVarChar(50)")]
		public string MatKhau
		{
			get
			{
				return this._MatKhau;
			}
			set
			{
				if ((this._MatKhau != value))
				{
					this.OnMatKhauChanging(value);
					this.SendPropertyChanging();
					this._MatKhau = value;
					this.SendPropertyChanged("MatKhau");
					this.OnMatKhauChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(50)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiaChi", DbType="NChar(10)")]
		public string DiaChi
		{
			get
			{
				return this._DiaChi;
			}
			set
			{
				if ((this._DiaChi != value))
				{
					this.OnDiaChiChanging(value);
					this.SendPropertyChanging();
					this._DiaChi = value;
					this.SendPropertyChanged("DiaChi");
					this.OnDiaChiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="KhachHang_DonDatHang", Storage="_DonDatHangs", ThisKey="MaKH", OtherKey="MaKH")]
		public EntitySet<DonDatHang> DonDatHangs
		{
			get
			{
				return this._DonDatHangs;
			}
			set
			{
				this._DonDatHangs.Assign(value);
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
		
		private void attach_DonDatHangs(DonDatHang entity)
		{
			this.SendPropertyChanging();
			entity.KhachHang = this;
		}
		
		private void detach_DonDatHangs(DonDatHang entity)
		{
			this.SendPropertyChanging();
			entity.KhachHang = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Loai")]
	public partial class Loai : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MaLoai;
		
		private string _TenLoai;
		
		private EntitySet<ChiTietSanPham> _ChiTietSanPhams;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaLoaiChanging(int value);
    partial void OnMaLoaiChanged();
    partial void OnTenLoaiChanging(string value);
    partial void OnTenLoaiChanged();
    #endregion
		
		public Loai()
		{
			this._ChiTietSanPhams = new EntitySet<ChiTietSanPham>(new Action<ChiTietSanPham>(this.attach_ChiTietSanPhams), new Action<ChiTietSanPham>(this.detach_ChiTietSanPhams));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaLoai", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MaLoai
		{
			get
			{
				return this._MaLoai;
			}
			set
			{
				if ((this._MaLoai != value))
				{
					this.OnMaLoaiChanging(value);
					this.SendPropertyChanging();
					this._MaLoai = value;
					this.SendPropertyChanged("MaLoai");
					this.OnMaLoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenLoai", DbType="NVarChar(50)")]
		public string TenLoai
		{
			get
			{
				return this._TenLoai;
			}
			set
			{
				if ((this._TenLoai != value))
				{
					this.OnTenLoaiChanging(value);
					this.SendPropertyChanging();
					this._TenLoai = value;
					this.SendPropertyChanged("TenLoai");
					this.OnTenLoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Loai_ChiTietSanPham", Storage="_ChiTietSanPhams", ThisKey="MaLoai", OtherKey="MaLoai")]
		public EntitySet<ChiTietSanPham> ChiTietSanPhams
		{
			get
			{
				return this._ChiTietSanPhams;
			}
			set
			{
				this._ChiTietSanPhams.Assign(value);
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
		
		private void attach_ChiTietSanPhams(ChiTietSanPham entity)
		{
			this.SendPropertyChanging();
			entity.Loai = this;
		}
		
		private void detach_ChiTietSanPhams(ChiTietSanPham entity)
		{
			this.SendPropertyChanging();
			entity.Loai = null;
		}
	}
}
#pragma warning restore 1591
