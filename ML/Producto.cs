namespace ML
{
    public class Producto
    {
        public int Sku { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioVenta { get; set; }
        public string Descuento { get; set; }
        public string Impuesto { get; set; }
        public ML.Division Division { get; set; }
        public List <Object> Productos { get; set; }

    }
}