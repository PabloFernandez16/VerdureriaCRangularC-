namespace Api_Verdureria.Models.Response
{
    public class Respuesta
    {
        public int Succes { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }

        public Respuesta()
        {
            Succes = 0;
        }
    }
}
