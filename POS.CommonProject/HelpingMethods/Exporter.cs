using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.CommonProject
{
    public class Exporter
    {
        public void ExportToExcelAndText(DataTable dT, string filePath, string fileName, string fileExtension)
        {
            string _fullPath = filePath + "\\" + fileName + "\\" + fileExtension;
            if (File.Exists(_fullPath))
            {
                File.Delete(_fullPath);
            }
            StreamWriter _streamWriter = new StreamWriter(_fullPath);
            try
            {
                for (int i = 0; i < dT.Rows.Count; i++)
                {
                    for (int j = 0; j < dT.Columns.Count; j++)
                    {
                        if (dT.Rows[i][j] != null)
                        {
                            _streamWriter.Write(Convert.ToString(dT.Rows[i][j] + "\t"));
                        }
                        else
                        {
                            _streamWriter.Write("\t");
                        }
                    }
                    _streamWriter.WriteLine();
                }
                _streamWriter.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
