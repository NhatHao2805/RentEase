// BLL/PaymentBLL.cs
using System;
using System.Data;
using DAL;

namespace BLL
{
    public class PaymentBLL
    {
        public static DataTable GetAllPayments()
        {
            return PaymentAccess.GetAllPayments();
        }
    }
}