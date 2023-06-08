using RAAMEN.DataSet;
using RAAMEN.Model;
using RAAMEN.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View
{
	public partial class Report : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			/*CrystalReport1 report = new CrystalReport1();

			CrystalReportViewer1.ReportSource = report;

			raamenEntities1 db = new raamenEntities1();
			DataSet1 data = getData(db.Headers.ToList<Header>());
			report.SetDataSource(data);*/
		}

		/*private DataSet1 getData(List<Header> headers)
        {
			DataSet1 data = new DataSet1();
			var header = data.Header;
			var detail = data.Detail;

			foreach(Header x in headers)
            {
				var hrow = header.NewRow();
				hrow["Id"] = x.Id;
				hrow["Date"] = x.Date;
				header.Rows.Add(hrow);
				foreach(Detail y in x.Details)
                {
					var drow = detail.NewRow();
					drow["HeaderId"] = y.HeaderId;
					drow["RamenId"] = y.RamenId;
					drow["Quantity"] = y.Quantity;
					detail.Rows.Add(drow);
                }
            }
			return data;
        }*/
	}
}