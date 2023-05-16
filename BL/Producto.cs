using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Producto
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.SanbornsContext context = new DL.SanbornsContext())
                {
                    var query = context.Productos.FromSqlRaw("ProductoGetAll").ToList();
                  
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.Sku = obj.Sku;
                            producto.Descripcion = obj.Descripcion;
                            producto.PrecioVenta = obj.Precioventa.Value;
                            producto.Descuento = obj.Descuento;
                            producto.Impuesto = obj.Impuesto;

                            producto.Division = new ML.Division();
                            producto.Division.IdDivision = obj.IdDivision.Value;
                            producto.Division.Descripcion = obj.Descripcion;
                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se puede mostrar la informacion";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
        public static  ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.SanbornsContext context = new DL.SanbornsContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"ProductoAdd '{producto.Descripcion}','{producto.PrecioVenta}','{producto.Descuento}','{producto.Impuesto}','{producto.Division.IdDivision}'");
                    if(query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se puede agregar";
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
        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.SanbornsContext context = new DL.SanbornsContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"ProductoUpdate '{producto.Sku}', '{producto.Descripcion}','{producto.PrecioVenta}','{producto.Descuento}','{producto.Impuesto}','{producto.Division.IdDivision}'");
                    if (query >= 1)
                    {
                        result.Correct = true;
                        result.Message = "Actualizado con éxito";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se puede modificar";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int? Sku)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.SanbornsContext context = new DL.SanbornsContext())
                {
                    var query = context.Productos.FromSqlRaw($"ProductoGetById '{Sku}'").AsEnumerable().FirstOrDefault();
                    result.Object = new List<object>();
                    if (query != null)
                    {
                        ML.Producto producto = new ML.Producto();
                        producto.Sku = query.Sku;
                        producto.Descripcion = query.Descripcion;
                        producto.PrecioVenta = query.Precioventa.Value;
                        producto.Descuento = query.Descuento;
                        producto.Impuesto = query.Impuesto;
                        producto.Division = new ML.Division();
                        producto.Division.IdDivision = query.IdDivision.Value;
                        producto.Division.Descripcion = query.NombreDivision;
                        result.Object = producto; // unboxing
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se puede mostrar la informacion";

                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}