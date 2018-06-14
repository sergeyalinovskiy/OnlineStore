namespace SA.OnlineStore.Common.Entity
{
    #region Usings
        using System.Drawing;
    #endregion
    public class Publicity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public byte[] Picture { get; set; }
    }
}
