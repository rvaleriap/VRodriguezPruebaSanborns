using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace BL
{
    public class Division
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.SanbornsContext context = new DL.SanbornsContext())
                {
                    var query = context.Divisions.FromSqlRaw("DivisionGetAll").ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var obj in query)
                        {
                            ML.Division division = new ML.Division();
                            division.IdDivision = obj.IdDivision;
                            division.Descripcion = obj.Descripcion;
                            result.Objects.Add(division);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pueden mostrar";

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
