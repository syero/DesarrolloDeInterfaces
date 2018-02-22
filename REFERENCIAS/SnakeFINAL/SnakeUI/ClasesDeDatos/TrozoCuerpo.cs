namespace Snake.ClasesDeDatos
{
    public class TrozoCuerpo
    {
        public int x { get; set; }
        public int y { get; set; }
        public Direccion direccion { get; set; }

        public TrozoCuerpo(int x, int y, Direccion direccion) {
            this.x = x;
            this.y = y;
            this.direccion = direccion;
        }

    }
}
