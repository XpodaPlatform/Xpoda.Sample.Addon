using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Xpoda.Sample.Addon
{
    public class TestClass
    {
        public static Dictionary<string, object> GetList(List<Dictionary<string, object>> parameters)

        {

            var result = new Dictionary<string, object>();

            var List = new List<Dictionary<string, object>>();

            // Bu Error keyi zorunlu. Boş da olsa döndürülmelidir.
            result["Error"] = "";

            try

            {
                var dt = new DataTable();
                dt.Clear();

                // Sütunları ekleyelim
                dt.Columns.Add("ID");
                dt.Columns.Add("NAME");


                // Verileri ekleyelim
                // Veriler veritabanı ya da harici bir servis çağrısı ile de doldurulabilir.
                var row = dt.NewRow();
                row["ID"] = "1";
                row["NAME"] = "Xpoda 1";

                dt.Rows.Add(row);
                
                
                var row1 = dt.NewRow();
                row1["ID"] = "2";
                row1["NAME"] = "Xpoda 2";

                dt.Rows.Add(row1);
                
                var row2 = dt.NewRow();
                row2["ID"] = "3";
                row2["NAME"] = "Xpoda 3";

                dt.Rows.Add(row2);

                foreach (DataRow dr in dt.Rows)
                {
                    //Dönüş tipimiz Dictionary olduğu için her bir satırı
                    // da bir Dictionary olarak döndürüyoruz.
                    var rows = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                        rows.Add(col.ColumnName, dr[col.ColumnName]);

                    List.Add(rows);
                }

                //List keyi ile doldurmamız gerekiyor.
                result["List"] = List;

            }

            catch (Exception ex)

            {

                result["Error"] = ex.Message;

            }

            return result;

        }

    }
}
