﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDataBaseControl
{
    public class ReportDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ReportDAO));

        private MySqlConnection _conn;

        private const string TABLE_ORDER = "tb_order";
        private const string TABLE_ORDER_DETAIL = "tb_order_detail";

        private void DatabaseOpen()
        {
            string connectionPath = ConfigurationManager.ConnectionStrings["SmoothDB"].ConnectionString;
            _conn = new MySqlConnection(connectionPath);
            _conn.Open();
        }

        private void DatabaseClose()
        {
            _conn.Close();
        }

        public int AddOrder(string OrderDT, int OrderType, int EmployeeID, int TableID, int OrderStatusID, int Payment_ID, int CustomerID)
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var ds = db.tb_order.Add(new tb_order()
                    {
                        order_at = DateTime.Parse(OrderDT),
                        order_type_id = OrderType,
                        employee_id = EmployeeID,
                        table = TableID,
                        order_status_id = OrderStatusID,
                        payment_id = Payment_ID,
                        customer_id = CustomerID
                    });

                    db.SaveChanges();
                    log.Info("SmoothDataLayer -- AddOrder Success");
                    return ds.order_id;
                }
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => AddOrder(): " + ex.Message);
                return -1;
            }
        }

        public int UpdateOrder(int OrderID, string OrderDT, int OrderType, int EmployeeID, int TableID, int OrderStatusID, int Payment_ID, int CustomerID)
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var update = db.tb_order.Where(o => (o.order_id == OrderID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.order_at = DateTime.Parse(OrderDT);
                        update.order_type_id = OrderType;
                        update.employee_id = EmployeeID;
                        update.table = TableID;
                        update.order_status_id = OrderStatusID;
                        update.payment_id = Payment_ID;
                        update.customer_id = CustomerID;
                    }

                    db.SaveChanges();
                }

                log.Info("SmoothDataLayer -- UpdateOrder Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => UpdateOrder(): " + ex.Message);
                return -1;
            }
        }

        public int DeleteOrder(int OrderID)
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var update = db.tb_order.Where(o => (o.order_id == OrderID)).FirstOrDefault();
                    if (update != null)
                    {
                        //TODO Add is_active in Order Table
                        update.is_active = 0;
                    }

                    db.SaveChanges();
                }

                log.Info("SmoothDataLayer -- DeleteOrder Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => DeleteOrder(): " + ex.Message);
                return -1;
            }
        }

        public List<tb_order> GetListOfOrder()
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var ds = (from c in db.tb_order
                              where c.is_active == 1
                              orderby c.order_id descending
                              select c).ToList();

                    // Assign to DataGridView
                    if (ds.Count() > 0)
                    {
                        log.Info("SmoothDataLayer -- GetListSection Success");
                        return ds;
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetListOfOrder(): " + ex.Message);
                return null;
            }
        }

        public List<tb_order> GetListOfOrder(int Top)
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var ds = (from c in db.tb_order
                              where c.is_active == 1
                              orderby c.order_id descending
                              select c).Take(Top).ToList();

                    // Assign to DataGridView
                    if (ds.Count() > 0)
                    {
                        log.Info("SmoothDataLayer -- GetListSection Success");
                        return ds;
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetListOfOrder(): " + ex.Message);
                return null;
            }
        }

        public DataTable GetListOfOrderByFilter(string Column, string Name)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("SELECT  order_id, order_at, order_type_id, employee_id, table, order_status_id, payment_id, customer_id ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_ORDER);
                stringSQL.Append(" WHERE @Column LIKE @Name");
                stringSQL.Append(" ORDER BY order_id DESC");


                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@Column", Column);
                cmd.Parameters.AddWithValue("@Name", Name);

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                

                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Dispose();
                DatabaseClose();
                log.Info("SmoothDataLayer -- GetListOfOrder Success");
                return dt;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetListOfOrder(): " + ex.Message);
                return null;
            }
        }

        public int AddOrderDetail(int ProductID, int PopupItemID, int OrderID, int ProductQty, float Amount, string Comment, int CookStatus)
        {
            try
            {

                using (var db = new smoothdbEntities())
                {
                    var ds = db.tb_order_detail.Add(new tb_order_detail()
                    {
                        product_id = ProductID,
                        popup_item_id = PopupItemID,
                        order_id = OrderID,
                        product_qty = ProductQty,
                        amount = Amount,
                        comment = Comment,
                        cook_status = CookStatus
                    });

                    db.SaveChanges();
                    log.Info("SmoothDataLayer -- AddOrderDetail Success");
                    return ds.order_detail_id;
                }

            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => AddOrder(): " + ex.Message);
                return -1;
            }
        }

        public int UpdateOrderDetailCookStatus(int OrderID, int ProductID, int CookStatus)
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var update = db.tb_order_detail.Where(o => (o.order_id == OrderID)).Where(o=> (o.product_id == ProductID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.cook_status = CookStatus;
                    }

                    db.SaveChanges();
                }

                log.Info("SmoothDataLayer -- UpdateOrder Success");
                return 1;

            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => UpdateSectionStable(): " + ex.Message);
                return -1;
            }
        }

        public int UpdateOrderDetail(int OrderDetailID, int ProductID, int PopupItemID, int OrderID, int ProductQty, float Amount, string Comment, int CookStatus)
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var update = db.tb_order_detail.Where(o => (o.order_detail_id == OrderDetailID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.cook_status = CookStatus;
                        update.product_id = ProductID;
                        update.popup_item_id = PopupItemID;
                        update.order_id = OrderID;
                        update.product_qty = ProductQty;
                        update.amount = Amount;
                        update.comment = Comment;

                    }

                    db.SaveChanges();
                }
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => UpdateSectionStable(): " + ex.Message);
                return -1;
            }
        }

        public int DeleteOrderDetail(int OrderDetailID)
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var update = db.tb_order_detail.Where(o => (o.order_detail_id == OrderDetailID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.is_active = 0;

                    }

                    db.SaveChanges();
                    return 1;
                }

            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => DeleteOrderDetail(): " + ex.Message);
                return -1;
            }
        }

    }
}
