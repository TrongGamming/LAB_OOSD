namespace ThuVienSo.Forms
{
    /// <summary>Một lựa chọn trong ComboBox: giá trị lưu (Ma) và chữ hiển thị (Ten).</summary>
    public class Muc
    {
        public Muc(string ma, string ten)
        {
            Ma = ma;
            Ten = ten;
        }

        public string Ma { get; private set; }
        public string Ten { get; private set; }

        public override string ToString()
        {
            return Ten;
        }
    }
}
