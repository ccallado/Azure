﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region Metadatos de relaciones en EDM

[assembly: EdmRelationshipAttribute("northwindModel", "FK_Order_Details_Orders", "Orders", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(ServicioWCF.Order), "Order_Details", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(ServicioWCF.Order_Detail), true)]

#endregion

namespace ServicioWCF
{
    #region Contextos
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    public partial class northwindEntities : ObjectContext
    {
        #region Constructores
    
        /// <summary>
        /// Inicializa un nuevo objeto northwindEntities usando la cadena de conexión encontrada en la sección 'northwindEntities' del archivo de configuración de la aplicación.
        /// </summary>
        public northwindEntities() : base("name=northwindEntities", "northwindEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto northwindEntities.
        /// </summary>
        public northwindEntities(string connectionString) : base(connectionString, "northwindEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto northwindEntities.
        /// </summary>
        public northwindEntities(EntityConnection connection) : base(connection, "northwindEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Métodos parciales
    
        partial void OnContextCreated();
    
        #endregion
    
        #region Propiedades de ObjectSet
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        public ObjectSet<Order_Detail> Order_Details
        {
            get
            {
                if ((_Order_Details == null))
                {
                    _Order_Details = base.CreateObjectSet<Order_Detail>("Order_Details");
                }
                return _Order_Details;
            }
        }
        private ObjectSet<Order_Detail> _Order_Details;
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        public ObjectSet<Order> Orders
        {
            get
            {
                if ((_Orders == null))
                {
                    _Orders = base.CreateObjectSet<Order>("Orders");
                }
                return _Orders;
            }
        }
        private ObjectSet<Order> _Orders;

        #endregion

        #region Métodos AddTo
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet Order_Details. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToOrder_Details(Order_Detail order_Detail)
        {
            base.AddObject("Order_Details", order_Detail);
        }
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet Orders. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToOrders(Order order)
        {
            base.AddObject("Orders", order);
        }

        #endregion

    }

    #endregion

    #region Entidades
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="northwindModel", Name="Order")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Order : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto Order.
        /// </summary>
        /// <param name="orderID">Valor inicial de la propiedad OrderID.</param>
        public static Order CreateOrder(global::System.Int32 orderID)
        {
            Order order = new Order();
            order.OrderID = orderID;
            return order;
        }

        #endregion

        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                if (_OrderID != value)
                {
                    OnOrderIDChanging(value);
                    ReportPropertyChanging("OrderID");
                    _OrderID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("OrderID");
                    OnOrderIDChanged();
                }
            }
        }
        private global::System.Int32 _OrderID;
        partial void OnOrderIDChanging(global::System.Int32 value);
        partial void OnOrderIDChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                OnCustomerIDChanging(value);
                ReportPropertyChanging("CustomerID");
                _CustomerID = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("CustomerID");
                OnCustomerIDChanged();
            }
        }
        private global::System.String _CustomerID;
        partial void OnCustomerIDChanging(global::System.String value);
        partial void OnCustomerIDChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                OnEmployeeIDChanging(value);
                ReportPropertyChanging("EmployeeID");
                _EmployeeID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("EmployeeID");
                OnEmployeeIDChanged();
            }
        }
        private Nullable<global::System.Int32> _EmployeeID;
        partial void OnEmployeeIDChanging(Nullable<global::System.Int32> value);
        partial void OnEmployeeIDChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> OrderDate
        {
            get
            {
                return _OrderDate;
            }
            set
            {
                OnOrderDateChanging(value);
                ReportPropertyChanging("OrderDate");
                _OrderDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("OrderDate");
                OnOrderDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _OrderDate;
        partial void OnOrderDateChanging(Nullable<global::System.DateTime> value);
        partial void OnOrderDateChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> RequiredDate
        {
            get
            {
                return _RequiredDate;
            }
            set
            {
                OnRequiredDateChanging(value);
                ReportPropertyChanging("RequiredDate");
                _RequiredDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("RequiredDate");
                OnRequiredDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _RequiredDate;
        partial void OnRequiredDateChanging(Nullable<global::System.DateTime> value);
        partial void OnRequiredDateChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> ShippedDate
        {
            get
            {
                return _ShippedDate;
            }
            set
            {
                OnShippedDateChanging(value);
                ReportPropertyChanging("ShippedDate");
                _ShippedDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ShippedDate");
                OnShippedDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _ShippedDate;
        partial void OnShippedDateChanging(Nullable<global::System.DateTime> value);
        partial void OnShippedDateChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> ShipVia
        {
            get
            {
                return _ShipVia;
            }
            set
            {
                OnShipViaChanging(value);
                ReportPropertyChanging("ShipVia");
                _ShipVia = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ShipVia");
                OnShipViaChanged();
            }
        }
        private Nullable<global::System.Int32> _ShipVia;
        partial void OnShipViaChanging(Nullable<global::System.Int32> value);
        partial void OnShipViaChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> Freight
        {
            get
            {
                return _Freight;
            }
            set
            {
                OnFreightChanging(value);
                ReportPropertyChanging("Freight");
                _Freight = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Freight");
                OnFreightChanged();
            }
        }
        private Nullable<global::System.Decimal> _Freight;
        partial void OnFreightChanging(Nullable<global::System.Decimal> value);
        partial void OnFreightChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShipName
        {
            get
            {
                return _ShipName;
            }
            set
            {
                OnShipNameChanging(value);
                ReportPropertyChanging("ShipName");
                _ShipName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShipName");
                OnShipNameChanged();
            }
        }
        private global::System.String _ShipName;
        partial void OnShipNameChanging(global::System.String value);
        partial void OnShipNameChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShipAddress
        {
            get
            {
                return _ShipAddress;
            }
            set
            {
                OnShipAddressChanging(value);
                ReportPropertyChanging("ShipAddress");
                _ShipAddress = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShipAddress");
                OnShipAddressChanged();
            }
        }
        private global::System.String _ShipAddress;
        partial void OnShipAddressChanging(global::System.String value);
        partial void OnShipAddressChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShipCity
        {
            get
            {
                return _ShipCity;
            }
            set
            {
                OnShipCityChanging(value);
                ReportPropertyChanging("ShipCity");
                _ShipCity = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShipCity");
                OnShipCityChanged();
            }
        }
        private global::System.String _ShipCity;
        partial void OnShipCityChanging(global::System.String value);
        partial void OnShipCityChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShipRegion
        {
            get
            {
                return _ShipRegion;
            }
            set
            {
                OnShipRegionChanging(value);
                ReportPropertyChanging("ShipRegion");
                _ShipRegion = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShipRegion");
                OnShipRegionChanged();
            }
        }
        private global::System.String _ShipRegion;
        partial void OnShipRegionChanging(global::System.String value);
        partial void OnShipRegionChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShipPostalCode
        {
            get
            {
                return _ShipPostalCode;
            }
            set
            {
                OnShipPostalCodeChanging(value);
                ReportPropertyChanging("ShipPostalCode");
                _ShipPostalCode = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShipPostalCode");
                OnShipPostalCodeChanged();
            }
        }
        private global::System.String _ShipPostalCode;
        partial void OnShipPostalCodeChanging(global::System.String value);
        partial void OnShipPostalCodeChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShipCountry
        {
            get
            {
                return _ShipCountry;
            }
            set
            {
                OnShipCountryChanging(value);
                ReportPropertyChanging("ShipCountry");
                _ShipCountry = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShipCountry");
                OnShipCountryChanged();
            }
        }
        private global::System.String _ShipCountry;
        partial void OnShipCountryChanging(global::System.String value);
        partial void OnShipCountryChanged();

        #endregion

    
        #region Propiedades de navegación
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("northwindModel", "FK_Order_Details_Orders", "Order_Details")]
        public EntityCollection<Order_Detail> Order_Details
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Order_Detail>("northwindModel.FK_Order_Details_Orders", "Order_Details");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Order_Detail>("northwindModel.FK_Order_Details_Orders", "Order_Details", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="northwindModel", Name="Order_Detail")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Order_Detail : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto Order_Detail.
        /// </summary>
        /// <param name="orderID">Valor inicial de la propiedad OrderID.</param>
        /// <param name="productID">Valor inicial de la propiedad ProductID.</param>
        /// <param name="unitPrice">Valor inicial de la propiedad UnitPrice.</param>
        /// <param name="quantity">Valor inicial de la propiedad Quantity.</param>
        /// <param name="discount">Valor inicial de la propiedad Discount.</param>
        public static Order_Detail CreateOrder_Detail(global::System.Int32 orderID, global::System.Int32 productID, global::System.Decimal unitPrice, global::System.Int16 quantity, global::System.Single discount)
        {
            Order_Detail order_Detail = new Order_Detail();
            order_Detail.OrderID = orderID;
            order_Detail.ProductID = productID;
            order_Detail.UnitPrice = unitPrice;
            order_Detail.Quantity = quantity;
            order_Detail.Discount = discount;
            return order_Detail;
        }

        #endregion

        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                if (_OrderID != value)
                {
                    OnOrderIDChanging(value);
                    ReportPropertyChanging("OrderID");
                    _OrderID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("OrderID");
                    OnOrderIDChanged();
                }
            }
        }
        private global::System.Int32 _OrderID;
        partial void OnOrderIDChanging(global::System.Int32 value);
        partial void OnOrderIDChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                if (_ProductID != value)
                {
                    OnProductIDChanging(value);
                    ReportPropertyChanging("ProductID");
                    _ProductID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ProductID");
                    OnProductIDChanged();
                }
            }
        }
        private global::System.Int32 _ProductID;
        partial void OnProductIDChanging(global::System.Int32 value);
        partial void OnProductIDChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal UnitPrice
        {
            get
            {
                return _UnitPrice;
            }
            set
            {
                OnUnitPriceChanging(value);
                ReportPropertyChanging("UnitPrice");
                _UnitPrice = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UnitPrice");
                OnUnitPriceChanged();
            }
        }
        private global::System.Decimal _UnitPrice;
        partial void OnUnitPriceChanging(global::System.Decimal value);
        partial void OnUnitPriceChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int16 Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                OnQuantityChanging(value);
                ReportPropertyChanging("Quantity");
                _Quantity = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Quantity");
                OnQuantityChanged();
            }
        }
        private global::System.Int16 _Quantity;
        partial void OnQuantityChanging(global::System.Int16 value);
        partial void OnQuantityChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Single Discount
        {
            get
            {
                return _Discount;
            }
            set
            {
                OnDiscountChanging(value);
                ReportPropertyChanging("Discount");
                _Discount = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Discount");
                OnDiscountChanged();
            }
        }
        private global::System.Single _Discount;
        partial void OnDiscountChanging(global::System.Single value);
        partial void OnDiscountChanged();

        #endregion

    
        #region Propiedades de navegación
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("northwindModel", "FK_Order_Details_Orders", "Orders")]
        public Order Order
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Order>("northwindModel.FK_Order_Details_Orders", "Orders").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Order>("northwindModel.FK_Order_Details_Orders", "Orders").Value = value;
            }
        }
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Order> OrderReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Order>("northwindModel.FK_Order_Details_Orders", "Orders");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Order>("northwindModel.FK_Order_Details_Orders", "Orders", value);
                }
            }
        }

        #endregion

    }

    #endregion

    
}
