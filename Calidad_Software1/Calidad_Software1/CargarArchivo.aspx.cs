using CAPA_LOGICA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calidad_Software1
{
    public partial class CargarArchivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Boolean fileOK = false;
                String path = "C:\\Archivos\\";
                if (cargarExcel.HasFile)
                {
                    String fileExtension =
                        System.IO.Path.GetExtension(cargarExcel.FileName).ToLower();
                    String[] allowedExtensions =
                        {".xls", ".xlsx"};
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                        }
                    }
                }

                if (fileOK)
                {
                    try
                    {
                        if (System.IO.File.Exists(path + cargarExcel.FileName))
                        {
                            System.IO.File.Delete(path + cargarExcel.FileName);
                        }
                        cargarExcel.SaveAs(path + cargarExcel.FileName);
                        lblCargar.Text = "Archivo Cargado";
                        Asociado asoc = new Asociado();
                        asoc.insertarAsociado(cargarExcel.FileName); 
                        
                    }
                    catch (Exception ex)
                    {
                        lblCargar.Text = "No fue posible cargar el archivo " + ex.ToString();
                    }
                }
                else
                {
                    lblCargar.Text = "Extensión no permitida";
                }
            }
        }
    }
}