using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeVanThang_01
{
    class NhanVien
    {
        private string maso;
        private string hoten;
        private int luongcung;
        public NhanVien()
        {
        }
        public NhanVien(string maso, string hoten, int luongcung)
        {
            this.maso = maso;
            this.hoten = hoten;
            this.luongcung = luongcung;
        }
        public string MaSo
        {
            set { this.maso = value; }
            get { return this.maso; }
        }
        public string HoTen
        {
            set { this.hoten = value; }
            get { return this.hoten; }
        }
        public int LuongCung
        {
            set { this.luongcung = value; }
            get { return this.luongcung; }
        }
        public virtual void Nhap()
        {
            Console.Write("Nhap ma so:");
            this.maso = Console.ReadLine();
            Console.Write("Nhap ho ten:");
            this.hoten = Console.ReadLine();
            Console.Write("Nhap luong cung:");
            this.luongcung = int.Parse(Console.ReadLine());
        }
        public virtual int tinhluong()
        {
            return 0;
        }
    }
    class NhanVienBC : NhanVien
    {
        private string mucxeploai;
        public NhanVienBC() : base()
        { }
        public NhanVienBC(string maso, string hoten, int luongcung, string mucxeploai) : base(maso, hoten, luongcung)
        {
            this.mucxeploai = mucxeploai;
        }
        public string MucXephang
        {
            set { this.mucxeploai = value; }
            get { return mucxeploai; }
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap muc xep loai:");
            this.mucxeploai = Console.ReadLine();
        }
        public override int tinhluong()
        {
            int luong;
            if (mucxeploai == "A")
                return luong = (int)1.8 * LuongCung;
            if (mucxeploai == "B")
                return luong = (int)1.0 * LuongCung;
            else return luong = (int)0.5 * LuongCung;
        }
        class NhanVienHD : NhanVien
        {
            private int doanhthu;
            public NhanVienHD() : base()
            { }
            public NhanVienHD(string maso, string hoten, int luongcung, int doanhthu) : base(maso, hoten, luongcung)
            {
                this.doanhthu = doanhthu;
            }
            public int DoanhThu
            {
                set { this.doanhthu = value; }
                get { return doanhthu; }
            }
            public override void Nhap()
            {
                base.Nhap();
                Console.Write("Nhap doanh thu:");
                this.doanhthu = int.Parse(Console.ReadLine());
            }
            public override int tinhluong()
            {
                double luong = doanhthu * 0.1;
                return (int)luong;
            }
        }
    
        class QuanLyNV
        {
            private List<NhanVien> dsNV;
            public QuanLyNV()
            {
                dsNV = new List<NhanVien>();
            }
            public void NhapDS()
            {
                string tieptuc = "y";
                int chon;
                NhanVien nv;
                do
                {
                    Console.Write("Chon loai nhan vien [1:Nhan vien bien che, 2:Nhan vien hop dong]:");
                    chon = int.Parse(Console.ReadLine());
                    switch (chon)
                    {
                        case 1:
                            nv = new NhanVienBC();
                            nv.Nhap();
                            dsNV.Add(nv);
                            break;
                        case 2:
                            nv = new NhanVienHD();
                            nv.Nhap();
                            dsNV.Add(nv);
                            break;
                        default:
                            Console.WriteLine("Ban chon sai. Vui long chon lai 1 hoac 2.");
                            break;
                    }
                    Console.Write("Ban co muon tiep tuc khong? Y/N:");
                    tieptuc = Console.ReadLine();
                } while (tieptuc.ToLower() == "Y");
            }

        }




        class Program
    {
        static void Main(string[] args)
        {
            menu();
        }
    static void menu()
    {
        QuanLyNV ql = new QuanLyNV();
        int chon = 0;
        do
        {
            //in thuc don ra man hinh
            Console.WriteLine("***CHUONG TRINH QUAN LY NHAN VIEN***");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1.Nhap danh sach nhan vien.");
            Console.WriteLine("2.Xuat thong tin nhan vien.");
            Console.WriteLine("3.Thong ke tong luong phai tra cho nhan vien.");
            Console.WriteLine("0.Thoat chuong trinh.");
            Console.WriteLine("--------------------------------");
            Console.Write("Ban chon chuc nang:");
            chon = int.Parse(Console.ReadLine());

            switch (chon)
            {
                case 1:
                    ql.NhapDS();
                    break;

                case 2:
                    ql.XuatDS();
                    break;
                case 3:
                    Console.WriteLine($"Tong tien luong phai tra: {ql.tinhTongLuong():#,##0 vnd}");
                    break;
                case 0:
                    Console.WriteLine("GoodBye.");
                    Console.ReadLine();
                    break;
            }

        } while (chon != 0);

    }
}

