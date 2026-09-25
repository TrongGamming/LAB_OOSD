using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using ThuVienSo.Data;

namespace ThuVienSo.Services
{
    public class BaoCaoService
    {
        /// <summary>UC-QT-03: 5 bảng kết quả của sp_ThongKeTongHop (KPI, theo chủ đề, quá hạn, top tải, đặt mua).</summary>
        public DataSet ThongKe(DateTime tu, DateTime den)
        {
            return Db.ExecProc("sp_ThongKeTongHop",
                new OracleParameter("TuNgay", tu.Date), new OracleParameter("DenNgay", den.Date));
        }
    }
}
